export interface ISecondaryFoodFilters {
    cuisine: string[],
    time: string[],
    rating: number[]
}

export const defaultSecondaryFoodFilters: ISecondaryFoodFilters = {
    cuisine: [],
    time: [],
    rating: []
}