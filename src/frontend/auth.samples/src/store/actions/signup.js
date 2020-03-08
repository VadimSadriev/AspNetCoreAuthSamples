import { http, errorMessages } from '../../shared/utils/http';
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

const signupFail = () => {
    return {
        type: "SIGNUP_FAIL"
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
                dispatch(layoutSnackbarActions.enqueueSnackbarSuccess('Account has been created successfully'));
                dispatch(push('/'));
            })
            .catch(res => {
                console.log(res)
                dispatch(layoutBackdropActions.close())
                if (res.response && res.response.data && res.response.data.errors){
                    res.response.data.errors.forEach(error => dispatch(layoutSnackbarActions.enqueueSnackbarError(error.message)))
                }
                else{
                   dispatch(layoutSnackbarActions.enqueueSnackbarError(errorMessages.network));
                }
                dispatch(signupFail());
            });
    }
}