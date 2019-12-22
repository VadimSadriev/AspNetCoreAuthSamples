import http from '../../shared/utils/http';
import { push } from 'connected-react-router';
import * as globalBackdropActions from './globalBackdrop';

const signupStart = () => {
    return {
        type: "SIGNUP_START"
    }
}

const signupSuccess = () => {
    return {
        type: "SIGNUP_SUCCESS"
    }
}

const signupFail = (message) => {
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
        dispatch(globalBackdropActions.open());

        http.post({
            url: `/api/account/signup`,
            data: {
                userName: userName,
                email: email,
                password: password
            }
        })
            .then(res => {
                dispatch(globalBackdropActions.close())
                dispatch(signupSuccess());
                dispatch(push('/'));
            })
            .catch(res => {
                dispatch(globalBackdropActions.close())
                dispatch(signupFail(res.message));
            });
    }
}