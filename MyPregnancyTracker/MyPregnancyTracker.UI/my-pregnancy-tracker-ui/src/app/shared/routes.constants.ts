import { environment } from "src/environments/environment";

export const LOGIN_ENDPOINT = `${environment.baseUrlApi}/api/accounts/login`;
export const REGISTER_ENDPOINT = `${environment.baseUrlApi}/api/accounts/register`;
export const CONFIRM_EMAIL_ENDPOINT = `${environment.baseUrlApi}/api/accounts/confirm-email`;