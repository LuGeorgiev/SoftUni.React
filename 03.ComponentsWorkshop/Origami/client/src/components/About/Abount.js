import { Redirect, Route, Switch } from 'react-router-dom';

const About = ({
    match,
    location,
    history,
}) =>{

    console.log(match);
    if (Math.random() > 0.5){

        //return <Redirect to="/contact-us" />

        history.push("/contact-us");
        return null;
    } 

    return(
        <main className="main-wrapper">
            <h1>About image for {match.params.name}</h1>
            <Switch>
                <Route path="about/pesho">
                    <h2>Peshp is teh best</h2>
                </Route>
            </Switch>
        </main>
    );
}

export default About;