import { Button } from "primereact/button";
import { Rating } from "primereact/rating";
import { useState } from "react";
import { useNavigate } from "react-router-dom";
import { TextField } from "../../../../../components/layout/inputs/textField/TextField";
import { httpPost } from "../../../../../services/HttpService";
import { nameof } from "../../../../../shared/utility";
import { defaultRecipe, IRecipeDto } from "../../../models/IRecipeDto";
import { RecipesApiEndpoints } from "../../../RecipesApiEndpoints";
import { RecipesRoutes } from "../../../RecipesRoutes";
import { IRecipeFormProps } from "./IRecipeFormProps";
import styles from './RecipeForm.module.scss';

export const RecipeForm = (props: IRecipeFormProps) => {
    const [recipe, setRecipe] = useState<IRecipeDto>(defaultRecipe);
    const [showErrors, setShowErrors] = useState<boolean>(false);
    const navigate = useNavigate();

    const isValid = (): boolean => {
        return true;
    }

    const saveRecipe = async (e: any) => {
        e.preventDefault();
        if (!isValid()) {
            setShowErrors(true);
            return;
        }

        setShowErrors(false);

        try {
            await httpPost(RecipesApiEndpoints.CREATE, JSON.stringify(recipe));
            navigate(RecipesRoutes.search)
        } catch (ex) {
            console.error(ex);
        }

    }

    const handleChange = (fieldName: keyof IRecipeDto, value: any) => {
        setRecipe(r => ({ ...r, [fieldName]: value }));
    }
    
    return (
        <form className={styles.form_container}>
            <h1>New Recipe</h1>
            <Rating
                value={recipe.rating}
                onChange={(e) => handleChange('rating', e.value)}
                cancel={false}
            />
            <TextField
                label="Title"
                value={recipe.title}
                name={nameof<IRecipeDto>('title')}
                onChange={handleChange}
            />
            <br />
            <Button
                label="Save"
                onClick={saveRecipe}
            />
        </form>
    )
}