import * as React from 'react';
import { Header } from './components/layout/header/Header';
import { SubHeader } from './components/layout/subHeader/SubHeader';
import styles from './App.module.scss';
import { Route, Routes } from 'react-router-dom';
import { registerRecipesRoutes } from './apps/recipes/RecipesRoutes';

export const App = (): JSX.Element => {
    return (
        <div>
            <Header />
            <Routes>
                {registerRecipesRoutes()}
            </Routes>
        </div>
    )
}