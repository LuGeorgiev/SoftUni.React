import CategoryNavigation from "./CategoryNavigation/CategoryNavigation";
import { Component } from "react";
import PetCard from "../PetCard/PetCard";

import * as petsService from '../../service/petsService';

class Categories extends Component {
    constructor(props){
        super(props);

        this.state = {
            pets:[],
            currentCategory:'all'
        }
    }

    componentDidMount(){
        petsService.getAll()
            .then(res => this.setState({pets:res}));
    }

    componentDidUpdate(prevProps){
        const category = this.props.match.params.category;

        if (prevProps.match.params.category == category) {
            return;
        }

        petsService.getAll(category)
            .then(res=>this.setState({
                pets:res,
                currentCategory:category
            }));
    }

    render() {
        //console.log(this.state.pets);
        return (
            <section className="dashboard">
                <h1>Dashboard</h1>

                <CategoryNavigation></CategoryNavigation>

                <ul className="other-pets-list">                   
                   {this.state.pets.map(x => 
                    <PetCard 
                        key={x.id}
                        // id={x.id}
                        // name={x.name}
                        {...x}
                    />)}
                </ul>
            </section>
        );
    }
}

export default Categories;