import { IWorkoutDto } from "../../../models/IWorkoutDto";

export interface ICardProps {
    isLoading?: boolean;
    workout?: IWorkoutDto;
    updateWorkoutState(workout: IWorkoutDto): void;
}