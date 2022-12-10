export interface ResetPasswordRequest{
    protectedEmail: string,
    protectedToken: string,
    newPassword: string,
    confirmNewPassword: string
};