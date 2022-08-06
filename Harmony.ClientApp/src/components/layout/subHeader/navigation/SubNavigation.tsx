import { Link } from 'react-router-dom';
import { ISubNavigationProps } from './ISubNavigationProps';
import styles from './SubNavigation.module.scss';

export const SubNavigation = (props: ISubNavigationProps): JSX.Element => {
    return (
        <div className={styles.sub_header_nav}>
            <ul>
                {props.links?.map(l => (
                    <li><Link to={l.path}>{l.text}</Link></li>
                ))}
            </ul>
        </div>
    );
}