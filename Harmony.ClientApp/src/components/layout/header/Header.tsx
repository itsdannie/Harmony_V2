import * as React from 'react';
import styles from './Header.module.scss';
import leaf from '../../../assets/leaf.svg';
import { css } from '../../../shared/utility';
import { Link } from 'react-router-dom';

export const Header = (): JSX.Element => {
    return (
        <div className={styles.header_container}>
            <div className={css(styles.nav_container, styles.content_container)}>
                <ul className={styles.left}>
                    <li><Link to="/apps/recipes">HOME</Link></li>
                    <li><Link to="/apps/recipes">RECIPES</Link></li>
                </ul>
                <div className={styles.logo_container}>
                    <img className={styles.flip} src={leaf} />
                    <div className={styles.logo}>HARMONY</div>
                    <img src={leaf} />
                </div>
                <ul>
                    <li><Link to="/apps/fitness">FITNESS</Link></li>
                    <li><Link to="/apps/recipes">OTHER</Link></li>
                </ul>
            </div>
        </div>
    )
}