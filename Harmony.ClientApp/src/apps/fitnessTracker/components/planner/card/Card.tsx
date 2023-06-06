import { useState } from 'react';
import { DaysOfWeek } from '../../../strings/DaysOfWeek';
import styles from './Card.module.scss';
import { ICardProps } from './ICardProps';
import { CardItem } from './cardItem/CardItem';
import { httpPost, httpPut } from '../../../../../services/HttpService';
import { FitnessTrackerApiEndpoints } from '../../../FitnessTrackerApiEndpoints';
import { ProgressSpinner } from 'primereact/progressspinner';
import sharedStyles from '../../../FitnessTrackerSharedStyles.module.scss';
import { IWorkoutDto } from '../../../models/IWorkoutDto';
import { Button } from 'primereact/button';
import { css } from '../../../../../shared/utility';

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

    const create = async () => {
        setIsSaving(true)
        let workout: IWorkoutDto = await httpPost(
            FitnessTrackerApiEndpoints.CREATE_WORKOUT,
            JSON.stringify({ date: new Date() }));
        props.updateWorkoutState(workout);
        setIsSaving(false);
    }

    const noWorkoutBody = (
        <div className={styles.empty_workout}>
            <div className={styles.text}>No planned workout for today.</div>
            <div>
                <Button
                    label="Add workout"
                    className={css(sharedStyles.primary_button, 'p-button-rounded', 'p-button-lg')}
                    icon="pi pi-plus"
                    onClick={create}
                    loading={isSaving}
                />
            </div>
        </div>
    );

    const loadingBody = (
        <div className={styles.spinner_container}>
            <ProgressSpinner
                className={sharedStyles.custom_progress_spinner}
                strokeWidth="5"
            />
        </div>)

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
                                    {workout.title && workout.title.length > 0 ? workout.title : '(Set title)'}
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