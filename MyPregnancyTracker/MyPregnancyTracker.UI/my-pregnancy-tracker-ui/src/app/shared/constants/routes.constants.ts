import { environment } from "src/environments/environment";

//Accounts controller endpoints.
export const LOGIN_ENDPOINT = `${environment.baseUrlApi}/api/accounts/login`;
export const REGISTER_ENDPOINT = `${environment.baseUrlApi}/api/accounts/register`;
export const CONFIRM_EMAIL_ENDPOINT = `${environment.baseUrlApi}/api/accounts/confirm-email`;
export const RESEND_CONFIRMATION_EMAIL_ENDPOINT = `${environment.baseUrlApi}/api/accounts/resend-confirmation-email`;
export const SEND_RESET_PASSWORD_EMAIL_ENDPOINT = `${environment.baseUrlApi}/api/accounts/send-reset-password-email`;
export const RESET_PASSWORD_ENDPOINT = `${environment.baseUrlApi}/api/accounts/reset-password`;
export const REFRESH_ACCESS_TOKEN_ENDPOINT = `${environment.baseUrlApi}/api/accounts/refresh-access-token`;
export const DELETE_ACCOUNT_ENDPOINT = `${environment.baseUrlApi}/api/accounts/delete-account`;

//Tasks controller endpoints.
export const GET_ALL_TASKS_ENDPOINT = `${environment.baseUrlApi}/api/tasks/get-all-tasks`;

//User controller endpoints.
export const SET_DUE_DATE_ENDPOINT = `${environment.baseUrlApi}/api/user/set-due-date`;
export const RESET_DUE_DATE_ENDPOINT = `${environment.baseUrlApi}/api/user/reset-due-date`;
export const UPDATE_USER_PROFILE_ENDPOINT = `${environment.baseUrlApi}/api/user/update-user-profile`;
export const GET_USER_PROFILE_DATA_ENDPOINT = `${environment.baseUrlApi}/api/user/get-user-profile-data`;
export const ADD_TASK_ENDPOINT = `${environment.baseUrlApi}/api/user/add-task`;
export const REMOVE_TASK_ENDPOINT = `${environment.baseUrlApi}/api/user/remove-task`;
export const SET_GESTATIONAL_WEEK_ENDPOINT = `${environment.baseUrlApi}/api/user/set-gestational-week`;

//Gestational week controller endpoints.
export const GET_ALL_ENDPOINT = `${environment.baseUrlApi}/api/gestational-week/get-all`;

//Topics controller endpoints.
export const GET_ALL_TOPICS_ENDPOINT = `${environment.baseUrlApi}/api/topics/get-all`;
export const GET_TOPIC_ENDPOINT = `${environment.baseUrlApi}/api/topics/get-one`;
export const ADD_TOPIC_ENDPOINT = `${environment.baseUrlApi}/api/topics/add-topic`;
export const GET_USER_TOPICS_ENDPOINT = `${environment.baseUrlApi}/api/topics/get-user-topics`;
export const DELETE_TOPIC_ENDPOINT = `${environment.baseUrlApi}/api/topics/delete-topic`;
export const EDIT_TOPIC_ENDPOINT = `${environment.baseUrlApi}/api/topics/edit-topic`;

//Comments controller endpoints.
export const GET_ALL_COMMENTS_ENDPOINT = `${environment.baseUrlApi}/api/comments/get-all`;
export const ADD_COMMENT_ENDPOINT = `${environment.baseUrlApi}/api/comments/add-comment`;