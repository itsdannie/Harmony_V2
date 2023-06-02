import { Route } from "react-router-dom";
import { FitnessTrackerLayout } from "./layout/FitnessTrackerLayout";
import { HomePage } from "./pages/HomePage";

export const fitnessTrackerBaseRoute = '/apps/fitness';

export const FitnessTrackerRoutes = {
    home: 'home'
}

export const registerFitnessTrackerRoutes = (): JSX.Element => {
    return (
        <Route path={fitnessTrackerBaseRoute} element={<FitnessTrackerLayout />}>
            <Route path={FitnessTrackerRoutes.home} element={<HomePage />} />
        </Route>);
}