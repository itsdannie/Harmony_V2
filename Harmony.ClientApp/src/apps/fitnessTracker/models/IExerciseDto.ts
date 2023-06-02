import { IExercisePropertyDto } from "./IExercisePropertyDto";

export interface IExerciseDto {
    id: number;
    name: string;
    isDone: boolean;
    properties: IExercisePropertyDto[];
}

export const defaultExercise: IExerciseDto = {
    id: 0,
    name: '',
    properties: [],
    isDone: false
}