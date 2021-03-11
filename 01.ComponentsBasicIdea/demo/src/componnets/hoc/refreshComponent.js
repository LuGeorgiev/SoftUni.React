import {Component}  from 'react';

function refreshComponnet(WrappedComponnet){
    return class extends Component {
        constructor(props){
            super(props);
            this.state = {
                refreshCount: 0
            }
        }

        componentDidMount(){
            setTimeout(()=>{
                this.setState({refreshCount: this.state.refreshCount + 1})
            }, 3000)
        }

        render(){
            return <WrappedComponnet {...this.props} refreshCount={this.state.refreshCount} />;
        }
    }
}

export default refreshComponnet;