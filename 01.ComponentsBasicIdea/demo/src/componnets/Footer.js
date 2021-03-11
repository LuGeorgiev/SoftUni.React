import {Component} from 'react';
import Message from './Message';
import refreshComponnet from './hoc/refreshComponent';

class Footer extends Component {
    constructor(props){
        super(props);

        // this.state = {
        //     showFooter: true
        // }
    }

    // componentDidMount() {
    //     setTimeout(()=>{
    //         this.setState({showFooter: false})
    //     }, 3000)
    // }

    render(){        
        console.log(this.props.refreshCount);
        //return this.state.showFooter && <Message text="All rights reserved &copy;"/>        
        return this.props.refreshCount ? <Message text="All rights reserved &copy;"/> : null;       
    }
}

export default refreshComponnet(Footer);