export interface ArticleModel{
    id: number,
    title: string,
    content: string,
    likesCount: number,
    dislikesCount: number,
    isLiked: boolean | null
}