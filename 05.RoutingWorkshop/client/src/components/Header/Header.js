import {Link} from 'react-router-dom'; 
import AuthContext from '../../contexts/AuthContext';

const Header = ({
    username,
    isAuthenticated,
}) => {
    const user = useContext(AuthContext); // right wau is with context

    return (
        <header id="site-header">
            <nav className="navbar">
                <section className="navbar-dashboard">
                    <div className="first-bar">
                        <Link to="/">Dashboard</Link>
                        <a className="button" href="#">My Pets</a>
                        <Link to="pets/create" className="button">Add Pet</Link>
                    </div>
                    <div className="second-bar">
                        <ul>
                            {isAuthenticated
                                ? <li>Welcome, {username}</li>
                                : <li>Welcome, Guest</li>
                            }                            
                            <li><Link to="/logout"><i className="fas fa-sign-out-alt"></i> Logout</Link></li>
                        </ul>
                    </div>
                </section>
                <section className="navbar-anonymous">
                    <ul>
                        <li><Link to="/register"><i className="fas fa-user-plus"></i> Register</Link></li>
                        <li><Link to="/login"><i className="fas fa-sign-in-alt"></i> Login</Link></li>
                    </ul>
                </section>
            </nav>
            <style jsx>{`
                
            `}</style>
        </header>
    );
};

export default Header;