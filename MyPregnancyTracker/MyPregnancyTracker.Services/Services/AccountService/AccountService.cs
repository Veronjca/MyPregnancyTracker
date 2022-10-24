using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MyPregnancyTracker.Data.Models;
using MyPregnancyTracker.Data.Repositories;
using MyPregnancyTracker.Services.Models;
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
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IRepository<ApplicationUser> _usersRepository;
        private readonly IMapper _mapper;

        public AccountService(
            UserManager<ApplicationUser> userManager,
            IConfiguration configuration,
            IRepository<ApplicationUser> usersRepository,
            IMapper mapper,
            IEmailService emailService)
        {
            _userManager = userManager;
            _configuration = configuration;
            _usersRepository = usersRepository;
            _mapper = mapper;
            _emailService = emailService; 
        }

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
                new Claim(ClaimTypes.Name, user.FirstName + " " + user.LastName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim("FDoLM", user.FirstDayOfLastMenstruation.ToString()),
                new Claim("DueDate", user.DueDate.ToString()),
                new Claim("GW", user.GestationalWeek.ToString())
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
            mappedUser.Id = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(mappedUser.Id));

            return mappedUser;
        }

        public async Task<RefreshAccessTokenResponseDto> RefreshAccessTokenAsync(RefreshAccessTokenDto refreshAccessTokenDto)
        {
            var userId = Encoding.Default.GetString(WebEncoders.Base64UrlDecode(refreshAccessTokenDto.UserId));
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
            var email = Encoding.Default.GetString(WebEncoders.Base64UrlDecode(resetPasswordDto.EncodedEmail));
            var token = Encoding.Default.GetString(WebEncoders.Base64UrlDecode(resetPasswordDto.EncodedToken));
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
