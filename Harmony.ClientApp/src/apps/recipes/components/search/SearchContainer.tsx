import * as React from 'react';
import { ISearchContainerProps } from './ISearchContainerProps';
import styles from './SearchContainer.module.scss';

export const SearchContainer = (props: ISearchContainerProps): JSX.Element => {
    return (
        <div className={styles.container}>
            <div className={styles.filters_column}>
                <h2>Filters</h2>
                <ul>
                    <li>Filter 1</li>
                    <li>Filter 2</li>
                    <li>Filter 3</li>
                    <li>Filter 4</li>
                    <li>Filter 5</li>
                </ul>
            </div>
            <div className={styles.results_column}>
                <div className={styles.search_container}>
                    <div className={styles.search_field}>Search</div>
                </div>
                <div className={styles.special_filters}>
                    <ul>
                        <li>All</li>
                        <li>Breakfast</li>
                        <li>Lunch</li>
                        <li>Dinner</li>
                        <li>Snacks</li>
                    </ul>
                </div>
            </div>
        </div>
    );
}