export interface GetAllTopicsRequest{
    category: number,
    isDescendingOrder: boolean,
    skip: number,
    take: number
}