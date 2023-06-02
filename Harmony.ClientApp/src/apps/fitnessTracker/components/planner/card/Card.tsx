import { DaysOfWeek } from '../../../strings/DaysOfWeek';
import styles from './Card.module.scss';
import { ICardProps } from './ICardProps';
import { CardItem } from './cardItem/CardItem';

export const Card = (props: ICardProps): JSX.Element => {
    const { isLoading, workout } = props;

    const getDayString = (): string => {
        if (workout && workout.weekday) {
            return DaysOfWeek[workout.weekday];
        }
        return '';
    }

    const noWorkoutBody = (<div>No planned workout for today.</div>);
    const loadingBody = (<div>Loading...</div>)

    return <div className={styles.card}>
        {isLoading ? loadingBody :
            !workout ?
                noWorkoutBody :
                <>
                    <div className={styles.header}>
                        <div className={styles.day}>{getDayString()}</div>
                        <div className={styles.title}>
                            {workout.title}
                            <i className="pi pi-pencil"></i>
                        </div>
                    </div>
                    <div className={styles.items}>
                        {workout.exercises?.map(e =>
                            <CardItem exercise={e} />
                        )}
                    </div>
                </>
        }
    </div>
}