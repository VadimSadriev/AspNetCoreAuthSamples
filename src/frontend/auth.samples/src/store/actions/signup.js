
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
    }
}