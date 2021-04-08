import React from 'react';

class AdvancedApp extends React.Component {
    constructor(props){
        super(props);
        this.state = {
            currentTheme: 'dark'
        };
    }

    onChangeThemeClickHandler(){
        // this.setState(oldState => oldState.currentTheme == 'dark' 
        //     ? {currentTheme: 'light'}
        //     : {currentTheme: 'dark'});
        this.setState(x =>({currentTheme: x.currentTheme == 'dark'? 'light': 'dark'}))
    }

    render() {
        return <Toolbar     
            theme={this.state.currentTheme} 
            onChangeThemeClickHandler={this.onChangeThemeClickHandler.bind(this)}
        />
    }
}

function Toolbar(props) {
    return (
        <div>
            <ThemeButton 
                theme={props.theme} 
                onChangeThemeClickHandler={props.onChangeThemeClickHandler}/>
        </div>
    )
}

class ThemeButton extends React.Component {
    render() {
        return <Button 
            theme={this.props.theme} 
            buttonClicked={this.props.onChangeThemeClickHandler}
        />
    }
}

function Button({
    theme,
    buttonClicked
}) {
    return (
        <button 
            onClick={buttonClicked} 
            style={{backgroundColor: theme == 'dark' ? 'darkgrey' : 'lightgreen'}}
        >
            {theme}
        </button>
    );
}

export default AdvancedApp