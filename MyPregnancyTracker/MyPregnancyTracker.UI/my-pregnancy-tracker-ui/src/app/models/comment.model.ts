import { ReactionModel } from "./reaction.model";

export interface CommentModel{
    id: number,
    content: string,
    createdOn: string,
    userId: string,
    userName: string,
    reactions: ReactionModel[],
}