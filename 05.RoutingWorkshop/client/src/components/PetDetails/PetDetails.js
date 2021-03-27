import { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
import * as petService from '../../service/petsService';

const PetDetails = ({
    match
}) => {
    let [pet, setPet] = useState({});

    useEffect(() => {
        //console.log(`from details: ${match.params.petId}`)

        petService.getOne(match.params.petId)
            .then(res => setPet(res));
    }, [match])

    const onPetButtonClickHandler = () => {
        let incrementedLikes = Number(pet.likes) + 1;

        petService.petLiked(match.params.petId, incrementedLikes)
        .then((updatedPet) => {
            //setPet(state => ({...state, likes: incrementedLikes}))
            setPet(updatedPet);
        })
    }

    return (
        <section className="detailsOtherPet">
            <h3>{pet.name}</h3>
            <p>Pet counter: {pet.likes} 
                <a href="#">
                    <button className="button" onClick={onPetButtonClickHandler}><i className="fas fa-heart"></i>
                        Pet
                    </button>
                </a>
            </p>
            <p className="img"><img src={pet.imageURL} /></p>
            <p className="description">{pet.description}</p>
            <div className="pet-info">
                <Link to={`/pets/details/${pet.id}/edit`}><button className="button">Edit</button></Link>
                <Link to="#"><button className="button">Delete</button></Link>
            </div>
        </section>
    );
}

export default PetDetails;