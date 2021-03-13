import style from './Header.module.css';
import NavigationItem from './NavigationItem';

const Header = () => {
    return (
        <nav className={style.navigation}>
            <ul >
                <li className={style.listItem}><img src="/white-origami-bird.png" alt="white-origami"/></li>                
                <NavigationItem>Going #1</NavigationItem>
                <NavigationItem>Going #2</NavigationItem>
                <NavigationItem>Going #3</NavigationItem>
                <NavigationItem>Going #4</NavigationItem>
                <NavigationItem>Going #5</NavigationItem>
                <NavigationItem>Going #6</NavigationItem>
                <NavigationItem>Going #7</NavigationItem>
                <NavigationItem>Going #8</NavigationItem>
                <NavigationItem>Going #9</NavigationItem>
                <NavigationItem>Going #10</NavigationItem>
            </ul>  
        </nav>
    );
}
export default Header;