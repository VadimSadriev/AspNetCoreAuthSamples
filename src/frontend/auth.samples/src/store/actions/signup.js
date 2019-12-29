import http from '../../shared/utils/http';
import { push } from 'connected-react-router';
import * as layoutBackdropActions from './layoutBackdrop';
import * as layoutSnackbarActions from './layoutSnackbar';

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
        dispatch(layoutBackdropActions.open());

        http({
            url: 'api/account/signup',
            method: 'POST',
            data: {
                userName: userName,
                email: email,
                password: password
            }
        })
            .then(res => {
                dispatch(layoutBackdropActions.close())
                dispatch(signupSuccess());
                dispatch(push('/'));
            })
            .catch(res => {
                dispatch(layoutBackdropActions.close())
                dispatch(layoutSnackbarActions.enqueueSnackbar({
                    message: 'Failed fetching data.',
                    options: {
                        key: new Date().getTime() + Math.random(),
                        variant: 'error'
                    }
                }))
                dispatch(signupFail(res.message));
            });
    }
}