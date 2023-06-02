import styles from './CardItem.module.scss';
import { ICardItemProps } from './ICardItemProps';

export const CardItem = (props: ICardItemProps) => {
    const { exercise } = props;

    return <div className={styles.item}>
        <div className={styles.info}>
            <div className={styles.title}>
                {exercise.name}
            </div>
            <div className={styles.sub_title}>
                {exercise.properties?.map(p =>
                    <>
                        <span className={styles.value}>{p.value}</span>
                        <span className={styles.unit}>{p.unit}</span>
                    </>
                )}
            </div>
        </div>
        <div className={styles.checklist}>
            {exercise.isDone ?
                <i className="pi pi-check-square"></i>
                : <i className="pi pi-stop"></i>
            }
            <i className="pi pi-ellipsis-v"></i>
        </div>
    </div>
}