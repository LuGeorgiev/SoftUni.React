import * as petsService from '../../service/petsService';
import { useEffect, useState } from 'react';
import InputError from '../shared/InputError/InputError';

const PetEdit = ({
    match,
    history
}) => {
    const[pet, setPet] = useState({});
    const [errorMessage, setErrorMessage]= useState('');

    useEffect(() => {
        petsService.getOne(match.params.petId)
        .then(res => setPet(res))
    },[])

    const onDescriptionChange = (e) =>{
        //console.log(e.target.value);

        if (e.target.value.length < 5) {
            setErrorMessage('Description should be greater than 5 ');
        } else {
            setErrorMessage('');
        }
    }

    const onDescriptionSaveSubmit =(e) =>{
        e.preventDefault();
        // console.log(e.target);
        // console.log(e.target.description.value);

        let updatedPet = {...pet, description: e.target.description.value};
        let petId = match.params.petId
        petsService.update(petId, updatedPet)
        .then(()=> {
            history.push(`/pets/details/${petId}`);
        })
    }
    //console.log(pet);

    return (<section className="detailsMyPet">
        <h3>{pet.name}</h3>
        <p>Pet counter: <i className="fas fa-heart"></i> {pet.likes}</p>
        <p className="img"><img src={pet.imageURL} /></p>
        <form onSubmit={onDescriptionSaveSubmit}>
            <textarea 
                type="text" 
                name="description" 
                defaultValue={pet.description}
                onBlur={onDescriptionChange}
            ></textarea>
            <InputError>{errorMessage}</InputError>
            <button className="button">Save</button>
        </form>
    </section>);
};

export default PetEdit;