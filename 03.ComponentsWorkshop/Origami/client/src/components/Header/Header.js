import style from './Header.module.css';
import NavigationItem from './NavigationItem';
import { Link } from 'react-router-dom';

const Header = () => {
    return (
        <nav className={style.navigation}>
            <ul >
                <li className={style.listItem}><img src="/white-origami-bird.png" alt="white-origami"/></li>                
                <Link to="/"><NavigationItem>Home</NavigationItem></Link>
                <Link to="/about"><NavigationItem>About</NavigationItem></Link>
                <Link to="/contact-us"><NavigationItem>Contacts</NavigationItem></Link>
                <Link to="/"><NavigationItem>Going #4</NavigationItem></Link>
                <Link to="/"><NavigationItem>Going #5</NavigationItem></Link>
                <Link to="/"><NavigationItem>Going #6</NavigationItem></Link>
                <Link to="/"><NavigationItem>Going #7</NavigationItem></Link>
                <Link to="/"><NavigationItem>Going #8</NavigationItem></Link>
                <Link to="/"><NavigationItem>Going #9</NavigationItem></Link>
                <Link to="/"><NavigationItem>Going #10</NavigationItem></Link>
                
            </ul>  
        </nav>
    );
}
export default Header;