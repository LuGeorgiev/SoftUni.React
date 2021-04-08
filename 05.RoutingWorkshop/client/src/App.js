import { Redirect, Route, Switch } from 'react-router-dom';

import './App.css';
import Categories from './components/Categories/Categories';
import Footer from './components/Footer/Footer';
import Login from './components/Login/Login';
import Register from './components/Register/Register';
import Header from './components/Header/Header';
import PetDetails from './components/PetDetails/PetDetails';
import PetEdit from './components/PetEdit/PetEdit';
import CreatePet from './components/CreatePet/CreatePet';
import DemoPage from './components/Demo/Demo';

import AdvancedTechniques from './components/AdvancedTechniques/AdvancedTechniques';
import AdvancedRight from './components/AdvancedRight/AdvancedRight';

import { auth } from './utils/firebase';
import { useEffect, useState } from 'react';
import AdvancedRightSecond from './components/AdvancedRightSecond/AdvancedRightSecond';
import AdvancedRightThird from './components/AdvancedRightThird/AdvancedRightSecond';

function App() {
    // console.log(process.env.NODE_ENV);
    // console.log(process.env.REACT_APP_CUSTOM_ENV_VARIABLE);

    const [user, setUser] = useState(null);

    useEffect(() => {
        auth.onAuthStateChanged((authUser) => {
            if (authUser) {
                var uid = authUser.uid;
                console.log('logged in');
                console.log(uid);
                setUser(authUser);
            } else {
                console.log('logged out');
                setUser(null);

            }
        });
    }, [])

    return (
        <div className="container">
            <Header username={user?.email} isAuthenticated={Boolean(user)} />
            <Switch>
                <Route path="/" exact component={Categories} />
                <Route path="/categories/:category" component={Categories} />
                <Route path="/pets/details/:petId" exact component={PetDetails} />
                <Route path="/pets/details/:petId/edit" component={PetEdit} />
                <Route path="/pets/create" component={CreatePet} />
                <Route path="/login" component={Login} />
                <Route path="/register" component={Register} />
                <Route path="/logout" render={props => {
                    auth.signOut();
                    return <Redirect to="/" />
                }} />

                <Route path="/demo" component={DemoPage} />
                <Route path="/advanced-right-third" component={AdvancedRightThird} />
                <Route path="/advanced-right-second" component={AdvancedRightSecond} />
                <Route path="/advanced-right" component={AdvancedRight} />
                <Route path="/advanced" component={AdvancedTechniques} />

            </Switch>
            <Footer />
        </div>
    );
}

export default App;
