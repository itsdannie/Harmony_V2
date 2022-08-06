import { Route } from "react-router-dom";
import { RecipesLayout } from "./layout/RecipesLayout";
import { GroceryListPage } from "./pages/GroceryListPage";

export const recipesBaseRoute = '/apps/recipes';

export const RecipesRoutes = {
    create: 'create',
    search: recipesBaseRoute + '/search',
    groceryList: recipesBaseRoute + '/grocery-list'
}

export const registerRecipesRoutes = (): JSX.Element => {
    return (
        <Route path={recipesBaseRoute} element={<RecipesLayout />}>
            <Route path={RecipesRoutes.create} element={<div>Create</div>} />
            <Route path={RecipesRoutes.search} element={<div> Search </div>} />
            <Route path={RecipesRoutes.groceryList} element={<GroceryListPage/>} />
        </Route>)
}