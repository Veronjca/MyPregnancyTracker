export interface AddReactionToArticleRequest{
    isLiked: boolean | null,
    skip: number,
    take: number,
    articleId: number,
    userId: string
}