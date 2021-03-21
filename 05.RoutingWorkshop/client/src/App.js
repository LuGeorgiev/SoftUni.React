import { Route, Switch } from 'react-router-dom';

import './App.css';
import Categories from './components/Categories/Categories';
import Footer from './components/Footer/Footer';
import Header from './components/Header/Header';
import PetDetails from './components/PetDetails/PetDetails';

function App() {
    return (
        <div className="container">
            <Header/>
            <Switch>
                <Route path="/" exact component={Categories}/>
                <Route path="/categories/:category" component={Categories}/>
                <Route path="/pets/details/:petId" component={PetDetails}/>
            </Switch>
            <Footer/>
        </div>
    );
}

export default App;
