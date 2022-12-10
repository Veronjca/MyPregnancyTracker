import { CommentModel } from "./comment.model";

export interface GetAllCommentsResponse{
    comments: CommentModel[],
    commentsCount: number
}