export interface AddReactionToArticleRequest{
    isLiked: boolean | null,
    articleId: number,
    userId: string
}