import React from 'react';

class Home extends React.Component {

    constructor(props){
        super(props);
    }

    componentDidMount(){
        document.title = this.props.title;
    }

    render() {
        return (
            <div>
                Home
            </div>
        )
    }
}

export default Home;