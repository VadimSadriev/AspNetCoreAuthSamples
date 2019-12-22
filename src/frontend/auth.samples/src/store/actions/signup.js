import http from '../../shared/utils/http';
import { push } from 'connected-react-router';

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

        http.post({
            url: `/api/account/signup`,
            data: {
                userName: userName,
                email: email,
                password: password
            }
        })
            .then(res => {
                dispatch(signupSuccess());
            })
            .catch(res => {
                dispatch(signupFail(res.message));
            });
    }
}