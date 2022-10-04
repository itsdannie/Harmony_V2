import { InputText } from 'primereact/inputtext';
import { ITextFieldProps } from './ITextFieldProps';
import styles from './TextField.module.scss';

export const TextField = (props: ITextFieldProps) => {
    return (
        <div className={styles.container}>
            <label htmlFor={props.name}>{props.label}</label>
            <InputText
                id={props.name}
                value={props.value}
                onChange={(e) => props.onChange(props.name, e.target.value)}
            />
        </div >
    )
}