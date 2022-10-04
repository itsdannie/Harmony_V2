export interface ITextFieldProps {
    label: string;
    value: string;
    name: string;
    onChange: (fieldName: any, value: string) => void;
}