export interface IRecipeDto {
    id: number;
    title: string;
    rating?: number;
    description: string;
}

export const defaultRecipe: IRecipeDto = {
    id: 0,
    title: "",
    description: ""
}