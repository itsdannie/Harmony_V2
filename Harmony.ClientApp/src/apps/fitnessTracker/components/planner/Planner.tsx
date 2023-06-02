import styles from './Planner.module.scss';
import { IWorkoutDto } from '../../models/IWorkoutDto';
import { useEffect, useState } from 'react';
import { httpGet } from '../../../../services/HttpService';
import { FitnessTrackerApiEndpoints } from '../../FitnessTrackerApiEndpoints';
import { Card } from './card/Card';

export const Planner = (): JSX.Element => {
    const [focusedWorkout, setFocusedWorkout] = useState<IWorkoutDto | undefined>(undefined);
    const [isLoading, setIsLoading] = useState<boolean>(false);

    useEffect(() => {
        if (!focusedWorkout && !isLoading) {
            setWorkoutForToday();
        }
    }, []);

    const setWorkoutForToday = async () => {
        setIsLoading(true);
        let workout: IWorkoutDto | undefined = await httpGet(FitnessTrackerApiEndpoints.GET_TODAY_WORKOUT);
        setFocusedWorkout(workout);
        setIsLoading(false);
    }

    return (
        <div className={styles.container}>
            <div className={styles.focused_workout}>
                <Card
                    workout={focusedWorkout}
                    isLoading={isLoading}
                />
            </div>
            <div className={styles.calendar_container}>
                Calendar
            </div>
        </div>
    )
}