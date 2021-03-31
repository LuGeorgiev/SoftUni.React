import { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import useFetch from '../../hooks/useFetch';

const Demo = () => {

    //const [count, setCount] = useState(0);
    const [state, setState] = useState({
        count: 11,
        step: 1
    });

    // const onCounterButtonClickHandler = () => {
    //     setCount(x => x + 1)
    // }


    const[charackter, isCharLoading] = useFetch(`https://swapi.dev/api/people/${state.step}`, 'Gruio');

    //const [charackter, setCharackter] = useState({ name: 'nobody' });
    // useEffect(() => {
    //     fetch(`https://swapi.dev/api/people/${state.step}`)
    //         .then(res => res.json())
    //         .then(charackter => setCharackter(charackter));

    //         return () =>{ // componnet will unmount
    //             console.log('ComponentWillUnmount');
    //         }
    // }, [state.step])  //[] -> component did mount

    const onCounterButtonClickHandler = () => {
        setState(x => ({ ...x, count: x.count + x.step }))
    }

    const onStepSelectChangeHandler = (e) => {
        const stepValue = Number(e.target.value)
        setState(x => ({ ...x, step: stepValue }))
    };

    return (
        <div>
            <h1>{isCharLoading ? `${charackter?.name}'s - Counter`: 'Loading.....'} </h1>
            <div>{state.count}</div>
            <button onClick={onCounterButtonClickHandler}>Increment</button>
            <div>
                <label htmlFor="step">Step</label>
                <select name="step" id="step" onChange={onStepSelectChangeHandler}>
                    <option value="1">1</option>
                    <option value="2">2</option>
                    <option value="3">3</option>
                    <option value="4">4</option>
                </select>
            </div>
            <div>
                <Link to="/">Home</Link>
            </div>
        </div>
    );
}

export default Demo;