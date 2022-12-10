import { GetAllCommentsResponse } from "./get-all-comments-response.model";
import { ReactionModel } from "./reaction.model";

export interface AddDeleteReactionResponse{
    userReactions: ReactionModel[],
    topicComments: GetAllCommentsResponse
}