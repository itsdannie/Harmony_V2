import styles from './CardItem.module.scss';

export const CardItem = () => {
    return <div className={styles.item}>
        <div className={styles.info}>
            <div className={styles.title}>Crunches</div>
            <div className={styles.sub_title}>1 sets x 20 reps</div>
        </div>
        <div className={styles.checklist}>
            {/* <i className="pi pi-stop"></i> */}
            <i className="pi pi-check-square"></i>
            <i className="pi pi-ellipsis-v"></i>
        </div>
    </div>
}