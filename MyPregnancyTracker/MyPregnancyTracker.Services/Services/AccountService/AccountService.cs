using AutoMapper;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MyPregnancyTracker.Data.Models;
using MyPregnancyTracker.Data.Repositories;
using MyPregnancyTracker.Services.Models.AccountsModels;
using MyPregnancyTracker.Services.Services.EmailService;
using SendGrid.Helpers.Errors.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using static MyPregnancyTracker.Services.Constants.Constants.Error;

namespace MyPregnancyTracker.Services.Services.AccountService
{
    public class AccountService : IAccountService
    {
        private readonly IEmailService _emailService;
        private readonly IDataProtector _dataProtector;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IRepository<ApplicationUser> _usersRepository;
        private readonly IMapper _mapper;

        public AccountService(
            UserManager<ApplicationUser> userManager,
            IConfiguration configuration,
            IRepository<ApplicationUser> usersRepository,
            IMapper mapper,
            IEmailService emailService,
            IDataProtectionProvider dataProtectionProvider)
        {
            _userManager = userManager;
            _configuration = configuration;
            _usersRepository = usersRepository;
            _mapper = mapper;
            _emailService = emailService;
            _dataProtector = dataProtectionProvider.CreateProtector(this._configuration["DataProtectorKey"]);        }

        public async Task<IdentityResult> SignUpUserAsync(RegisterDto registerDto)
        {
            var user = _mapper.Map<ApplicationUser>(registerDto);

            var result = await _userManager.CreateAsync(user, registerDto.Password);
            //await _userManager.AddToRoleAsync(user, "user");

            return result;
        }

        public async Task<LoginResponseDto> SignInUserAsync(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            if (user == null)
            {
                throw new BadRequestException(USER_NOT_FOUND);
            }

            bool isEmailConfirmed = await _userManager.IsEmailConfirmedAsync(user);

            if (!isEmailConfirmed)
            {
                throw new UnauthorizedAccessException(EMAIL_NOT_CONFIRMED);
            }

            bool isPasswordCorrect = await _userManager.CheckPasswordAsync(user, loginDto.Password);

            if (!isPasswordCorrect)
            {
                throw new UnauthorizedAccessException(INCORRECT_PASSWORD);
            }

            var userRoles = await _userManager.GetRolesAsync(user);

            var claims = new List<Claim>
            {
                new Claim("FirstName", user.FirstName),
                new Claim("LastName", user.LastName),
                new Claim(ClaimTypes.Email, user.Email),
            };

            foreach (var role in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var accessToken = GenerateAccessToken(claims);
            var refreshToken = GenerateRefreshToken();

            user.AccessToken = accessToken;
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpirationDate = DateTime.UtcNow.AddMinutes(90);

            _usersRepository.Update(user);
            await _usersRepository.SaveChangesAsync();

            var mappedUser = _mapper.Map<LoginResponseDto>(user);
            mappedUser.Id = this._dataProtector.Protect(mappedUser.Id);

            return mappedUser;
        }

        public async Task<RefreshAccessTokenResponseDto> RefreshAccessTokenAsync(RefreshAccessTokenDto refreshAccessTokenDto)
        {
            var userId = this._dataProtector.Unprotect(refreshAccessTokenDto.UserId);
            var user = await _userManager.FindByIdAsync(userId);

            if (user.RefreshTokenExpirationDate < DateTime.UtcNow)
            {
                throw new UnauthorizedAccessException(SESSION_EXPIRED);
            }

            //TODO: Test if claims exists when access token is expired.
            var claims = await _userManager.GetClaimsAsync(user);

            var accessToken = GenerateAccessToken(claims);
            var refreshToken = GenerateRefreshToken();

            user.AccessToken = accessToken;
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpirationDate = DateTime.UtcNow.AddMinutes(90);

            _usersRepository.Update(user);
            await _usersRepository.SaveChangesAsync();

            var response = new RefreshAccessTokenResponseDto
            {
                RefreshToken = refreshToken,
                AccessToken = accessToken
            };

            return response;
        }
        public async Task<ApplicationUser> GetUserByEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            return user;
        }

        public Task<string> GenerateEmailConfirmationTokenAsync(ApplicationUser user)
        {
            var token = _userManager.GenerateEmailConfirmationTokenAsync(user);

            return token;
        }

        public async Task<IdentityResult> ConfirmEmailAsync(string emailToken, string userId)
        {
            userId = this._dataProtector.Unprotect(userId);
            emailToken = this._dataProtector.Unprotect(emailToken);

            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                throw new NullReferenceException(USER_NOT_FOUND);
            }

            var isEmailConfirmed = await _userManager.ConfirmEmailAsync(user, emailToken);

            return isEmailConfirmed;
        }

        public async Task<IdentityResult> ResetPasswordAsync(ResetPasswordDto resetPasswordDto)
        {
            var email = this._dataProtector.Unprotect(resetPasswordDto.ProtectedEmail);
            var token = this._dataProtector.Unprotect(resetPasswordDto.ProtectedToken);
            var user = await GetUserByEmailAsync(email);
            var result = await _userManager.ResetPasswordAsync(user, token, resetPasswordDto.NewPassword);

            return result;
        }

        public async Task SendResetPasswordEmailAsync(ResetPasswordEmailDto resetPasswordEmailDto)
        {
            var user = await GetUserByEmailAsync(resetPasswordEmailDto.Email);

            if (user == null)
            {
                throw new BadRequestException(INVALID_REQUEST);
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            await _emailService.SendResetPasswordEmailAsync(user, token);
        }

        public async Task UpdateUserProfileDataAsync(UpdateUserProfileRequest updateUserProfileRequest)
        {
            var userId = this._dataProtector.Unprotect(updateUserProfileRequest.UserId);
            var user = await this._userManager.FindByIdAsync(userId);

            if(user == null)
            {
                throw new BadRequestException();
            }

            user.FirstName = updateUserProfileRequest.FirstName;
            user.LastName = updateUserProfileRequest.LastName;
            user.BirthDate = updateUserProfileRequest.BirthDate;
            user.Weight = updateUserProfileRequest.Weight;
            user.Height = updateUserProfileRequest.Height;

            if (updateUserProfileRequest.DueDate.HasValue)
            {
                user.DueDate = updateUserProfileRequest.DueDate.Value;
            }

            this._usersRepository.Update(user);
            await this._usersRepository.SaveChangesAsync();           
        }

        public async Task<GetUserProfileDataResponse> GetUserProfileDataAsync(string userId)
        {
            var user = await this._userManager.FindByIdAsync(userId);

            if(user == null)
            {
                throw new BadRequestException();
            }

            var response = new GetUserProfileDataResponse
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                BirthDate = user.BirthDate,
                Height = user.Height,
                Weight = user.Weight,
                DueDate = user.DueDate,
            };

            return response;
        }

        private string GenerateAccessToken(IEnumerable<Claim> claims)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSecretKey"]));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokenOptions = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(60),
                SigningCredentials = signinCredentials,
                IssuedAt = DateTime.UtcNow,
            };

            var handler = new JwtSecurityTokenHandler();

            var token = handler.CreateToken(tokenOptions);
            string tokenString = handler.WriteToken(token);

            return tokenString;
        }

        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

       
    }
}
