import { ArticleModel } from "./article.model";

export interface GetAllArticlesResponse{
   articles: ArticleModel[],
   articlesCount: number
}