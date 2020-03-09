import React, { useEffect} from 'react';

function Signin(props){

    useEffect(() => {
        document.title = props.title;
    })

    return (
        <React.Fragment>
           <p>Signin component</p>
        </React.Fragment>
    )
}

export default Signin;