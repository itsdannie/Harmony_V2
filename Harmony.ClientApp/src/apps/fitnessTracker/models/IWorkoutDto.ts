import { IExerciseDto } from "./IExerciseDto";

export interface IWorkoutDto {
    id: number;
    title: string;
    weekday: number;
    date?: Date;
    exercises: IExerciseDto[]
}

export const defaultWorkout: IWorkoutDto = {
    id: 0,
    title: "",
    weekday: 0,
    date: undefined,
    exercises: []
}