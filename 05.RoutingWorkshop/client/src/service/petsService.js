
const url = 'http://localhost:3001/pets';

export const getAll = (category = '') => {

    let petUrl = url + ((category && category !== 'All')
        ? `?category=${category}`
        : '');
    console.log(petUrl)
    return fetch(petUrl)
        .then(res => res.json())
        .catch(err => console.log(err));
}

export const getOne = (petId) => {

    console.log(petId)
    return fetch(`${url}/${petId}`)
        .then(res => res.json())
        .catch(err => console.log(err));
}

export const create = (petName, description, imageURL, category) => {
    let pet = {
        name: petName,
        description: description,
        imageURL,
        category,
        likes:1
    }

    return fetch(`${url}`, {
        method: 'POST',
        headers: {
            'content-type': 'application/json'
        },
        body: JSON.stringify(pet)
    });
};

export const update = (petId, pet) => {
    return fetch(`${url}/${petId}`, {
        method: 'PUT',
        headers: {
            'content-type': 'application/json'
        },
        body: JSON.stringify(pet)
    })
}

export const petLiked = (petId, likes) => {
    return fetch(`${url}/${petId}`,{
        method: 'PATCH',
        headers: {
            'content-type': 'application/json'
        },
        body: JSON.stringify({likes})
    })
}