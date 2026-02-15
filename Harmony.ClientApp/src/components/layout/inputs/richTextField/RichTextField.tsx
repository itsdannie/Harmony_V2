import { Editor } from 'primereact/editor';
import { IRichTextFieldProps } from './IRichTextFieldProps';
import styles from './RichTextField.module.scss';

export const RichTextField = (props: IRichTextFieldProps) => {
    return (
        <div className={styles.container}>
            <label htmlFor={props.name}>{props.label}</label>
            <Editor
                id={props.name}
                value={props.value}
                onTextChange={(e) => props.onChange(props.name, e.htmlValue)}
            />
        </div >
    )
}