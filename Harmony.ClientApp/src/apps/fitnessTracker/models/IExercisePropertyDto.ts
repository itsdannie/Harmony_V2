export interface IExercisePropertyDto {
    id: number;
    unit: string;
    value: number;
}

export const defaultExerciseProperty: IExercisePropertyDto = {
    id: 0,
    unit: "",
    value: 0
}
