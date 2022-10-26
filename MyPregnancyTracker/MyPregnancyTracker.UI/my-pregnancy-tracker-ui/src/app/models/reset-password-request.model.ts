export interface ResetPasswordRequest{
    encodedEmail: string,
    encodedToken: string,
    newPassword: string,
    confirmNewPassword: string
}