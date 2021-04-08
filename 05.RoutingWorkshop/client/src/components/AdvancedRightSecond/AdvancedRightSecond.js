import React from 'react';
import { useContext, useState } from 'react';

const ThemeContext = React.createContext('dark');

const AdvancedRightSecond = ({ }) => {

    const [theme, setTheme] = useState('dark');
    

    return (
        <ThemeContext.Provider value={[theme, setTheme]}>
            <Toolbar />
        </ThemeContext.Provider>
    );

}

function Toolbar(props) {
    return (
        <div>
            <ThemeButton />
        </div>
    )
}

const ThemeButton = () => {
    const [theme, setTheme] = useContext(ThemeContext);

    const onChangeThemeClickHandler = () => {
        setTheme(x => x == 'dark' ? 'light' : 'dark' )
    }

    return (
        <>
            <HeaderButton />
            <Button
                buttonClicked={onChangeThemeClickHandler} />
        </>
    );
}



const HeaderButton = ({
}) => {

    const [theme, setTheme] = useContext(ThemeContext);
    console.log('In button header second', theme);

    return (
        <headre>
            <h1 style={{ color: theme == 'dark' ? 'red' : 'green' }}>Best title ever!</h1>
            <p>Lorem ipsum dolor sit amet consectetur adipisicing elit.
            Consectetur, odit error eum facilis quidem aut tempore dicta
            cumque molestias earum minus animi recusandae modi excepturi
                adipisci dolorem reiciendis, hic quod!</p>
        </headre>
    );
}



function Button({   
    buttonClicked
}) {
    return (
        <ThemeContext.Consumer>
            {([theme]) =>
                <button
                    onClick={buttonClicked}
                    style={{ backgroundColor: theme == 'dark' ? 'darkgrey' : 'pink' }}
                >
                    {theme}
                </button>
            }
        </ThemeContext.Consumer>
    );
}

export default AdvancedRightSecond