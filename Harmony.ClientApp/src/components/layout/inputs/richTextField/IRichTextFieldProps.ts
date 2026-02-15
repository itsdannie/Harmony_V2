export interface IRichTextFieldProps {
    label: string;
    value: string;
    name: string;
    onChange: (fieldName: any, value: string | null) => void;
}