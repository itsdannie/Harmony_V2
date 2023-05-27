import { Route } from "react-router-dom";
import { FitnessTrackerLayout } from "./layout/FitnessTrackerLayout";

export const fitnessTrackerBaseRoute = '/apps/fitness';

export const FitnesTrackerRoutes = {
    home: 'home'
}

export const registerFitnessTrackerRoutes = (): JSX.Element => {
    return (
        <Route path={fitnessTrackerBaseRoute} element={<FitnessTrackerLayout />}>
        </Route>)
}