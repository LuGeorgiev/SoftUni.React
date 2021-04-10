import React from 'react';

class CustomErrorBoundry extends React.Component {
    constructor(props) {
        super(props)

        this.state = {
            hasError: false
        }
    }

    componentDidCatch(error, errorInfo){
        console.log('error form component did catch', error);
    }

    static getDerivedStateFromError(error){
        return {
            hasError: true
        }
    }

    render() {
        if (this.state.hasError) {
            return <h1>I'm so sorry for this error</h1>
        }
        
        return this.props.children;
    }
}

export default CustomErrorBoundry;