import { useState } from 'react';
import { DaysOfWeek } from '../../../strings/DaysOfWeek';
import styles from './Card.module.scss';
import { ICardProps } from './ICardProps';
import { CardItem } from './cardItem/CardItem';
import { httpGet, httpPut } from '../../../../../services/HttpService';
import { FitnessTrackerApiEndpoints } from '../../../FitnessTrackerApiEndpoints';
import { IWorkoutDto } from '../../../models/IWorkoutDto';

export const Card = (props: ICardProps): JSX.Element => {
    const { isLoading, workout, updateWorkoutState } = props;
    const [title, setTitle] = useState<string>('');
    const [isEditingTitle, setIsEditingTitle] = useState<boolean>(false);
    const [isSaving, setIsSaving] = useState<boolean>(false);

    const getDayString = (): string => {
        if (workout && workout.weekday) {
            return DaysOfWeek[workout.weekday];
        }
        return '';
    }

    const noWorkoutBody = (<div>No planned workout for today.</div>);
    const loadingBody = (<div>Loading...</div>)

    const enableEdit = () => {
        setTitle(workout?.title ?? '');
        setIsEditingTitle(true);
    }
    const save = async () => {
        setIsSaving(true);
        try {
            await httpPut(
                FitnessTrackerApiEndpoints.UPDATE_TITLE + workout!.id,
                JSON.stringify({ title: title }));

            let workoutClone: IWorkoutDto = { ...workout! };
            workoutClone.title = title;
            updateWorkoutState(workoutClone);
            setTitle('');
            setIsEditingTitle(false);
        } catch (ex) {
            console.error(ex);
        }
        setIsSaving(false);

    }

    const cancel = () => {
        setTitle('');
        setIsEditingTitle(false);
    }

    const titleEditor: JSX.Element = (
        <div className={styles.title_editor}>
            <input
                disabled={isSaving}
                type="text" 
                value={title}
                onChange={e => setTitle(e.target.value?.toUpperCase())}
            />
            <div className={styles.edit_actions}>
                <i className="pi pi-check" onClick={save}></i>
                <i className="pi pi-times" onClick={cancel}></i>
            </div>
        </div>
    );

    return <div className={styles.card}>
        {isLoading ? loadingBody :
            !workout ?
                noWorkoutBody :
                <>
                    <div className={styles.header}>
                        <div className={styles.day}>{getDayString()}</div>
                        <div className={styles.title}>
                            {isEditingTitle ? titleEditor :
                                <>
                                    {workout.title.length > 0 ? workout.title : '(Set title)'}
                                    <i className="pi pi-pencil"
                                        onClick={enableEdit}></i>
                                </>
                            }
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