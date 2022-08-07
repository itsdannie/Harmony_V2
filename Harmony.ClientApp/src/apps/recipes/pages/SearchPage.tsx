import React from "react";
import { useEffect, useState } from "react";
import { httpGet } from "../../../services/HttpService";
import { RecipesApiEndpoints } from "../RecipesApiEndpoints";
import { IRecipeViewDto } from '../models/IRecipeViewDto';
import { SearchContainer } from "../components/search/SearchContainer";

export const SearchPage = (): JSX.Element => {
    const [recipes, setRecipes] = useState<IRecipeViewDto[]>([]);

    useEffect(() => {
        loadRecipes();
    }, []);

    const loadRecipes = async () => {
        const result = await httpGet<IRecipeViewDto[]>(RecipesApiEndpoints.GET_ALL);
        setRecipes(result ?? []);
    }

    return (
        <SearchContainer items={recipes}
        />);
}