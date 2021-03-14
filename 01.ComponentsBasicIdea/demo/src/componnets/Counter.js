import {Component} from 'react';
import { Button, Box } from '@material-ui/core';
import ClearIcon from '@material-ui/icons/Clear';
import { AccessAlarm,  } from '@material-ui/icons';
import CancelPresentationRoundedIcon from '@material-ui/icons/CancelPresentationRounded';

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
                <Box component="span" m={1} color="text.primary">
                    <Button 
                        variant="outlined"
                        onClick={(e) => this.decrementCounter(e)}
                    />
                </Box>
                <span>{this.state.count}</span>
                <button onClick={(e) => this.setState({count:this.state.count + 1})}>+</button>
                <Button 
                    variant="outlined" 
                    color="primary" 
                    onClick={this.resetCounter.bind(this)}
                    size="small"
                    startIcon={<ClearIcon/>}
                >
                    Reset
                </Button>
            </div>
        );
    }
}

export default Counter;