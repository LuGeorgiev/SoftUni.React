import React, { useReducer } from 'react';
import { useContext, useState } from 'react';

const ThemeContext = React.createContext('dark');

const AdvancedRightThird = ({ }) => {

    // const [theme, setTheme] = useState({
    //     color: 'dark',
    //     size: 'normal',
    //     font: 'default'
    // });

    const themeReducer = (state, action) => {
        return { ...state, color: action }
    };

    const [theme, dspatch] = useReducer(themeReducer, {
        color: 'dark',
        size: 'normal',
        font: 'default'
    });

    return (
        <ThemeContext.Provider value={[theme, dspatch]}>
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
    const [theme, dispatch] = useContext(ThemeContext);

    const onChangeThemeClickHandler = () => {
        dispatch(theme.color == 'dark'? 'light': 'dark');
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

    const [theme] = useContext(ThemeContext);
    console.log('In button header third', theme);

    return (
        <headre>
            <h1 style={{ color: theme.color == 'dark' ? 'red' : 'green' }}>Best title ever!</h1>
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
                    style={{ backgroundColor: theme[0].color[0] == 'dark' ? 'darkgrey' : 'pink' }}
                >
                    {theme[0].color}
                </button>
            }
        </ThemeContext.Consumer>
    );
}

export default AdvancedRightThird