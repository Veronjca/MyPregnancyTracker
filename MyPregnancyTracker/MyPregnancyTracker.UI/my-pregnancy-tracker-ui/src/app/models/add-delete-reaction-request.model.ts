export interface AddDeleteReactionRequest{
    commentId: number,
    userId: string,
    reactionType: string,
    topicId: number,
    skip: number,
    take: number
}