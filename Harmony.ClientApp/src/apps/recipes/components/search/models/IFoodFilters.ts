import { defaultSecondaryFoodFilters, ISecondaryFoodFilters } from "./ISecondaryFoodFilters";
import { PrimaryFilter } from "./PrimaryFilter";

export interface IFoodFilters {
    primary: PrimaryFilter;
    secondary: ISecondaryFoodFilters;
}

export const defaultFoodFilters: IFoodFilters = {
    primary: PrimaryFilter.All,
    secondary: defaultSecondaryFoodFilters
}