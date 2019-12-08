
export const signupStart = () => {
    return {
        type: "SIGNUP_START"
    }
}

export const signupSuccess = () => {
    return {
        type: "SIGNUP_SUCCESS"
    }
}

export const signupFail = (message) => {
    return {
        type: "SIGNUP_FAIL",
        payload: {
            message
        }
    }
}

export const signup = (userName, email, password) => {
    return dispatch => {
        dispatch(signupStart());

        fetch(`${process.env.REACT_APP_API_URL}/signup`, {
           method: 'POST',
           body: {
               userName: userName,
               email: email,
               password: password
           } 
        }).then(res => {
            // set token
            const response = res.json();

            dispatch(signupSuccess());
        }).catch(res => {
            const response = res.json();
            dispatch(signupFail(response.error));
        });
    }
}