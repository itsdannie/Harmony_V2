import { ISecondaryFoodFilters } from "../models/ISecondaryFoodFilters";

export interface IFilterGroupProps {
    label: string;
    name: string;
    options: string[];
    selected: string[];
    onChange: (filterName: keyof ISecondaryFoodFilters, value: any, isChecked: boolean) => void;
}