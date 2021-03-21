
const url = 'http://localhost:3001/pets';

export const getAll = (category='') => {

    let petUrl = url + ((category && category != 'All')
        ? `?category=${category}`
        :'');
    console.log(petUrl)
    return fetch(petUrl)
            .then(res=> res.json())
            .catch(err=> console.log(err));
}

export const getOne = (petId) => {

    console.log(petId)
    return fetch(`${url}/${petId}`)
            .then(res=> res.json())
            .catch(err=> console.log(err));
}