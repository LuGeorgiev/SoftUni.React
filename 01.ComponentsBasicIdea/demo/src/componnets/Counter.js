import {Component} from 'react';

class Counter extends Component{
    constructor(props){
        super(props);

        this.state = {
            count: 11
        }
    }

    decrementCounter(){
        this.setState(prevState => ({count: prevState.count -1 }));
    }

    resetCounter(e){
        this.setState({count:0});
    }

    render(){
        return (
            <div className="counter">
                <h3>Book Counter</h3>
                <button onClick={(e) => this.decrementCounter(e)}>-</button>
                <span>{this.state.count}</span>
                <button onClick={(e) => this.setState({count:this.state.count + 1})}>+</button>
                <button onClick={this.resetCounter.bind(this)}>Reset</button>
            </div>
        );
    }
}

export default Counter;