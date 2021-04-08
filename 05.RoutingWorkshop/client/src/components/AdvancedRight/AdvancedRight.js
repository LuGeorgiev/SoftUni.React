import React from 'react';
import { useContext } from 'react';

const ThemeContext = React.createContext('dark');

class AdvancedRight extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            currentTheme: 'dark'
        };
    }

    onChangeThemeClickHandler() {
        // this.setState(oldState => oldState.currentTheme == 'dark' 
        //     ? {currentTheme: 'light'}
        //     : {currentTheme: 'dark'});
        this.setState(x => ({ currentTheme: x.currentTheme == 'dark' ? 'light' : 'dark' }))
    }

    render() {
        return (
            <ThemeContext.Provider value={{
                theme: this.state.currentTheme,
                onChangeThemeClickHandler: this.onChangeThemeClickHandler.bind(this)
            }}>
                <Toolbar />
            </ThemeContext.Provider>
        );
    }
}

function Toolbar(props) {
    return (
        <div>
            <ThemeButton />
        </div>
    )
}

class ThemeButton extends React.Component {
    componentDidMount() {
        //console.log(this.context);
    }

    render() {
        return (
            <>
                <HeaderButton />
                <Button
                    theme={this.context.theme}
                    buttonClicked={this.context.onChangeThemeClickHandler} />
            </>
        );
    }
}
ThemeButton.contextType = ThemeContext;



const HeaderButton = ({
}) => {

    const themeContext = useContext(ThemeContext);
    console.log('In button header',themeContext);

    return (
        <headre>
            <h1 style={{color:themeContext.theme == 'dark'? 'red': 'green'}}>Best title ever!</h1>
            <p>Lorem ipsum dolor sit amet consectetur adipisicing elit.
            Consectetur, odit error eum facilis quidem aut tempore dicta
            cumque molestias earum minus animi recusandae modi excepturi
                adipisci dolorem reiciendis, hic quod!</p>
        </headre>
    );
}



function Button({
    theme,
    buttonClicked
}) {
    return (
        <button
            onClick={buttonClicked}
            style={{ backgroundColor: theme == 'dark' ? 'darkgrey' : 'pink' }}
        >
            {theme}
        </button>
    );
}

export default AdvancedRight