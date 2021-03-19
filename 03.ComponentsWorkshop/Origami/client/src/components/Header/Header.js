import style from './Header.module.css';
import NavigationItem from './NavigationItem';
import { Link, NavLink } from 'react-router-dom';

const Header = () => {
    return (
        <nav className={style.navigation}>
            <ul >
                <li className={style.listItem}><img src="/white-origami-bird.png" alt="white-origami"/></li>                
                <Link to="/"><NavigationItem>Home</NavigationItem></Link>
                <Link to="/about"><NavigationItem>About</NavigationItem></Link>
                <Link to="/contact-us"><NavigationItem>Contacts</NavigationItem></Link>
                <Link to="/about/pesho"><NavigationItem>Going #4</NavigationItem></Link>
                <Link to="/about/ivan"><NavigationItem>Going #5</NavigationItem></Link>
                <NavLink activeStyle={{backgroundColor:'red'}} exact={true} to="/about/gruio"><NavigationItem>Going #6</NavigationItem></NavLink>
                <NavLink activeStyle={{backgroundColor:'red'}} exact={true} to="/about/stamat"><NavigationItem>Going #7</NavigationItem></NavLink>
                <NavLink activeStyle={{backgroundColor:'red'}} exact={true} to="/about/dancno"><NavigationItem>Going #8</NavigationItem></NavLink>
                <NavLink activeStyle={{backgroundColor:'red'}} exact={true} to="/about/maia"><NavigationItem>Going #9</NavigationItem></NavLink>
                <NavLink activeStyle={{backgroundColor:'red'}} exact={true} to="/about/neli"><NavigationItem>Going #10</NavigationItem></NavLink>                
            </ul>  
        </nav>
    );
}
export default Header;