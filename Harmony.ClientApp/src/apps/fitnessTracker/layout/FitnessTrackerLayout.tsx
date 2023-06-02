import { IFitnessTrackerLayoutProps } from "./IFitnessTrackerLayoutProps";
import styles from './FitnessTrackerLayout.module.scss';
import { Outlet } from "react-router-dom";

export const FitnessTrackerLayout = (props: IFitnessTrackerLayoutProps) => {
    return (
        <div className={styles.container}>
            <div className={styles.content}>
                <Outlet />
            </div>
        </div>
    )
}