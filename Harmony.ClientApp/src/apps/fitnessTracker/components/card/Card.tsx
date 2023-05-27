import styles from './Card.module.scss';
import { CardItem } from './cardItem/CardItem';

export const Card = () => {
    return <div className={styles.card}>
        <div className={styles.header}>
            <div className={styles.day}>Wednesday</div>
            <div className={styles.title}>ABS + ARMS</div>
        </div>
        <div className={styles.items}>
            <CardItem />
            <CardItem />
            <CardItem />
        </div>
    </div>
}