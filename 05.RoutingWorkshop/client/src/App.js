import { Route, Switch } from 'react-router-dom';

import './App.css';
import Categories from './components/Categories/Categories';
import Footer from './components/Footer/Footer';
import Header from './components/Header/Header';
import PetDetails from './components/PetDetails/PetDetails';
import PetEdit from './components/PetEdit/PetEdit';
import CreatePet from './components/CreatePet/CreatePet';
import DemoPage from './components/Demo/Demo';

function App() {
    return (
        <div className="container">
            <Header/>
                <Switch>
                    <Route path="/" exact component={Categories}/>
                    <Route path="/categories/:category" component={Categories}/>
                    <Route path="/pets/details/:petId" exact component={PetDetails}/>
                    <Route path="/pets/details/:petId/edit" component={PetEdit}/>
                    <Route path="/pets/create" component={CreatePet}/>
                    <Route path="/demo" component={DemoPage}/>
                </Switch>
            <Footer/>
        </div>
    );
}

export default App;
