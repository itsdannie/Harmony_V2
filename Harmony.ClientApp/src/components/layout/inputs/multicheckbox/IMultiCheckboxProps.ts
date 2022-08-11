import { CheckboxChangeParams } from "primereact/checkbox";
import { ICheckbox } from "./models/ICheckbox";

export interface IMultiCheckboxProps {
    name: string;
    options: ICheckbox[];
    selected: ICheckbox[];
    onChange: (e: CheckboxChangeParams) => void;
}