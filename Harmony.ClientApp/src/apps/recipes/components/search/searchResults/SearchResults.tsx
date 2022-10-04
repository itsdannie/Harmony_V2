import { ISearchResultsProps } from "./ISearchResultsProps"
import styles from './SearchResults.module.scss';
import { useEffect, useState } from 'react';
import { httpGet } from "../../../../../services/HttpService";
import { IRecipeViewDto } from "../../../models/IRecipeViewDto";
import { RecipesApiEndpoints } from "../../../RecipesApiEndpoints";

export const SearchResults = (props: ISearchResultsProps) => {
    const [recipes, setRecipes] = useState<IRecipeViewDto[]>([]);
    
    const filter = async() => {
        const results = await httpGet<IRecipeViewDto[]>(RecipesApiEndpoints.GET_ALL);
        setRecipes(results);
    }
    
    useEffect(() => {
        filter();
    }, [props.filters]);

    return (<div className={styles.container}>
        {recipes.map(r => (
            <div>
                <h3>{r.title}</h3>
                <h3>{r.rating}</h3>
            </div>
        ))}
    </div>)
}