import { IFilterGroupProps } from "./IFIlterGroupProps";
import styles from './FilterGroup.module.scss';
import { MultiCheckbox } from "../../../../../components/layout/inputs/multicheckbox/MultiCheckbox";
import { CheckboxChangeParams } from "primereact/checkbox";
import { ICheckbox } from "../../../../../components/layout/inputs/multicheckbox/models/ICheckbox";
import { ISecondaryFoodFilters } from "../models/ISecondaryFoodFilters";

export const FilterGroup = (props: IFilterGroupProps): JSX.Element => {
    const options: ICheckbox[] = props.options.map(o => {
        return { key: o.replaceAll(' ', '_'), value: o }
    });

    const selected = options
        .filter(o => props.selected.some(s => s === o.value))

    const onChange = (e: CheckboxChangeParams) => {
        console.log(e);
        props.onChange(e.target.name as keyof ISecondaryFoodFilters,
             e.value.value,
              e.checked);
    }
    return (
        <div className={styles.filter_group_container}>
            <h3>{props.label}</h3>
            <MultiCheckbox
                name={props.name}
                options={options}
                selected={selected}
                onChange={onChange}
            />
        </div>
    )
}