import { Categories } from "./categories.enum";

export interface TopicModel{
    id: string,
    title: string,
    userName: string,
    createdOn: string,
    content: string,
    userId: string,
    category: number
}