import {Component} from 'react';

class Message extends Component {
    constructor(props){
        super(props);
        console.log('Constructor');
    }

    componentDidMount(){
        console.log('Component did mount');

        setTimeout(() => {
            this.forceUpdate()//DO NOT USE!!
        }, 2000)
    }

    componentDidUpdate(){
        console.log('Did update!');
    }

    componentWillUnmount(){
        console.log('Will unmount')
    }

    render(){
        //Inline CSS
        // let style = {
        //     backgroundColor: '#CCC',
        //     fontSize: 23
        // }

        //Dynamic classes
        let classes = [];
        if (true) {
            classes.push('some-class')
        }

        console.log('Render');
        return(            
            //<span style={style}>{this.props.text}</span>        
            <span className={classes.join(' ')}> {this.props.text}</span>        
        )            
    }
}

export default Message;