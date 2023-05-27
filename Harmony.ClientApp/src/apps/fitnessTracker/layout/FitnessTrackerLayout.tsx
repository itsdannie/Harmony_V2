import { IFitnessTrackerLayoutProps } from "./IFitnessTrackerLayoutProps";
import styles from './FitnessTrackerLayout.module.scss';
import { Card } from "../components/card/Card";

export const FitnessTrackerLayout = (props: IFitnessTrackerLayoutProps) => {
    return (
        <div className={styles.container}>
            <div className={styles.content}>
                <div className={styles.schedule}>
                    <Card />
                </div>
            </div>
        </div>
    )
}