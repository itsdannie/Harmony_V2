import * as React from 'react';
import { ISearchContainerProps } from './ISearchContainerProps';
import styles from './SearchContainer.module.scss';
import { FilterGroup } from './filterGroup/FIlterGroup';
import { useState } from 'react';
import { defaultFoodFilters, IFoodFilters } from './models/IFoodFilters';
import { ISecondaryFoodFilters } from './models/ISecondaryFoodFilters';

export const SearchContainer = (props: ISearchContainerProps): JSX.Element => {
    const [selectedFilters, setSelectedFilters] = useState<IFoodFilters>(defaultFoodFilters);

    const onSecondaryFilterChange = (filterName: keyof ISecondaryFoodFilters, value: any, isChecked: boolean) => {
        const filters = { ...selectedFilters }
        if (isChecked) {
            //@ts-ignore
            filters.secondary[filterName].push(value);
        } else {
            //@ts-ignore
            filters.secondary[filterName] = filters.secondary[filterName].filter(f => f != value);
        }

        setSelectedFilters(filters);
    }

    return (
        <div className={styles.container}>
            <div className={styles.filters_column}>
                <h2>Filters</h2>
                <FilterGroup
                    label="Time"
                    name="time"
                    options={['≤ 10 minutes', '≤ 30 minutes', '≤ 60 minutes', '> 1 hour']}
                    selected={selectedFilters.secondary.time}
                    onChange={onSecondaryFilterChange}
                />
                <FilterGroup
                    label="Cuisine"
                    name="cuisine"
                    options={['Japanese', 'Korean', 'Chinese', 'Bulgarian']}
                    selected={selectedFilters.secondary.cuisine}
                    onChange={onSecondaryFilterChange}
                />
                <FilterGroup
                    label="Rating"
                    name="Rating"
                    options={['5 Stars', '4 Stars', '3 Stars', '2 Stars', '1 Star']}
                    selected={selectedFilters.secondary.time}
                    onChange={onSecondaryFilterChange}
                />
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
                        <li>Drinks</li>
                        <li>Surprise me</li>
                    </ul>
                </div>
            </div>
        </div>
    );
}