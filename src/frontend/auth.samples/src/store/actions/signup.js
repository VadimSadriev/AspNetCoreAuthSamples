import axios from 'axios';


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

        const instance = axios.create({
            baseURL: `${process.env.REACT_APP_API_URL}/api`,
            headers: {
                'Content-Type': 'application/json',
                'Accept': 'application/json'
            },
        })

        instance({
            method: 'POST',
            url: `/account/signup`,
            data: {
                userName: userName,
                email: email,
                password: password
            }
        })
        .then(res => {
            alert(res.data);
        })
        .catch(res => {
            alert(res.data);
        });

        // instance({
        //     method: 'POST',
        //     url: `/account/signup`,
        //     data: {
        //         userName: userName,
        //         email: email,
        //         password: password
        //     }
        // })
        // .then(res => {
        //     console.log('success', res);
        // })
        // .catch(res => {
        //     console.log('fail', res);
        // });
    }
}