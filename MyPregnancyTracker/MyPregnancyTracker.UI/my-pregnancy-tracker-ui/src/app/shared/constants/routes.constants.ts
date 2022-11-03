import { environment } from "src/environments/environment";

export const LOGIN_ENDPOINT = `${environment.baseUrlApi}/api/accounts/login`;
export const REGISTER_ENDPOINT = `${environment.baseUrlApi}/api/accounts/register`;
export const CONFIRM_EMAIL_ENDPOINT = `${environment.baseUrlApi}/api/accounts/confirm-email`;
export const RESEND_CONFIRMATION_EMAIL_ENDPOINT = `${environment.baseUrlApi}/api/accounts/resend-confirmation-email`;
export const SEND_RESET_PASSWORD_EMAIL_ENDPOINT = `${environment.baseUrlApi}/api/accounts/send-reset-password-email`;
export const RESET_PASSWORD_ENDPOINT = `${environment.baseUrlApi}/api/accounts/reset-password`;
export const REFRESH_ACCESS_TOKEN_ENDPOINT = `${environment.baseUrlApi}/api/accounts/refresh-access-token`;