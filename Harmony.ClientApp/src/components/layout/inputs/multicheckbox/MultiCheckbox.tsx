import { IMultiCheckboxProps } from "./IMultiCheckboxProps"
import { Checkbox } from 'primereact/checkbox';
import styles from './MultiCheckbox.module.scss';

export const MultiCheckbox = (props: IMultiCheckboxProps): JSX.Element => {
    return (
        <div className={styles.checkbox_container}>
            {props.options?.map(o => {
                return (
                    <div key={o.key} className="field-checkbox">
                        <Checkbox 
                        inputId={o.key} 
                        name={props.name} 
                        value={o} 
                        onChange={props.onChange} 
                        checked={props.selected.some((item) => item.key === o.key)} />
                        <label htmlFor={o.key}>{o.value}</label>
                    </div>
                )
            })}
        </div>
    )
}