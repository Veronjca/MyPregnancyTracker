import { TopicModel } from "./topic.model";

export interface GetAllTopicsResponse{
    topics: TopicModel[],
    topicsCount: number
}