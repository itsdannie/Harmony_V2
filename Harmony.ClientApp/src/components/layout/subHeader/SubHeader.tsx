
import styles from './SubHeader.module.scss';
import { css } from '../../../shared/utility';
import backgroundFruit from '../../../assets/fruit_background.png';
import foregroundFruit from '../../../assets/fruit_foreground.png';
import recipeBook from '../../../assets/recipe_book.svg';
import { SubNavigation } from './navigation/SubNavigation';
import { ISubHeaderProps } from './ISubHeaderProps';

export const SubHeader = (props: ISubHeaderProps): JSX.Element => {
    return (
        <div className={styles.sub_header_container}>
            <div className={styles.overlay}>
                <img src={backgroundFruit} className={styles.background_img} />
                <img src={foregroundFruit} className={styles.foreground_img} />
            </div>
            <div className={css(styles.sub_header_content, styles.content_container)}>
                <h1>Recipes<img src={recipeBook}/></h1>
                <SubNavigation links={props.links}/>
            </div>
        </div>
    )
}