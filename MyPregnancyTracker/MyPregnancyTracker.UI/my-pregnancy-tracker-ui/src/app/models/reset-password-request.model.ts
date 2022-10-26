export interface ResetPasswordReques{
    encodedEmail: string,
    encodedToken: string,
    newPassword: string,
    confirmNewPassword: string
}