import { Outlet } from "react-router-dom";
import { css } from "../../../../shared/utility";
import { ISubNavLink } from "../../../layout/subHeader/navigation/models/ISubNavLink";
import { SubHeader } from "../../../layout/subHeader/SubHeader"
import { RecipesRoutes } from "../RecipesRoutes";
import styles from './RecipesLayout.module.scss';

export const RecipesLayout = (): JSX.Element => {
    const links: ISubNavLink[] = [
        { text: 'Create', path: RecipesRoutes.create },
        { text: 'Search', path: RecipesRoutes.search },
        { text: 'Grocery List', path: RecipesRoutes.groceryList },
    ]

    return (
        <div>
            <SubHeader links={links} />
            <div className={css(styles.content_container, styles.center)}>
                <div className={styles.content}>
                    <Outlet />
                </div>
            </div>
        </div>
    )
}