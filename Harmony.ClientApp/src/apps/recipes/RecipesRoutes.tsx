import React from "react";
import { Route } from "react-router-dom";
import { RecipesLayout } from "./layout/RecipesLayout";
import { GroceryListPage } from "./pages/GroceryListPage";
import { SearchPage } from "./pages/SearchPage";
import { CreatePage } from "./pages/CreatePage";


export const recipesBaseRoute = '/apps/recipes';

export const RecipesRoutes = {
    create: 'create',
    search: recipesBaseRoute + '/search',
    groceryList: recipesBaseRoute + '/grocery-list'
}

export const registerRecipesRoutes = (): JSX.Element => {
    return (
        <Route path={recipesBaseRoute} element={<RecipesLayout />}>
            <Route path={RecipesRoutes.create} element={<CreatePage/>} />
            <Route path={RecipesRoutes.search} element={<SearchPage/>} />
            <Route path={RecipesRoutes.groceryList} element={<GroceryListPage/>} />
        </Route>)
}