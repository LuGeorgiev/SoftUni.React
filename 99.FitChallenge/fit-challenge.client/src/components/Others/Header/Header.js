import Button from 'react-bootstrap/Button'
import { Link, Route, Switch } from 'react-router-dom';

import Register from '../../Core/Register/Register';
import Login from '../../Core/Login/Login';
import ChangePassword from '../../Core/ChangePassword/ChangePassword';
import Greetings from '../../Core/Greetings/Greetings';

const Header = () => {
    return (
        <>
        <Link to="/register">
            <Button variant="outline-primary">Register</Button>{' '}
        </Link>
        <Link to="/login">
            <Button variant="outline-success">Login</Button>{' '}
        </Link>
        <Link to="change-password">
            <Button variant="outline-dark">Change Password</Button>
        </Link>
            <Switch>
                <Route path="/" exact component={Greetings} />
                <Route path="/register" component={Register} />
                <Route path="/login" component={Login} />
                <Route path="/change-password" component={ChangePassword} />
            </Switch>
        </>
    );
}

export default Header;