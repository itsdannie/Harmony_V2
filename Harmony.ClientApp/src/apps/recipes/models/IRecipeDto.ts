export interface IRecipeDto {
    id: number;
    title: string;
    rating?: number;
}

export const defaultRecipe: IRecipeDto = {
    id: 0,
    title: ""
}