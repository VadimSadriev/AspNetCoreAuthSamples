import { http, errorMessages } from '../../shared/utils/http';
import { push } from 'connected-react-router';
import * as layoutBackdropActions from './layoutBackdrop';
import * as layoutSnackbarActions from './layoutSnackbar';

const signinStart = () => {
    return {
        type: "SIGNIN_START"
    }
}

const signinSuccess = () => {
    return {
        type: "SIGNIN_SUCCESS"
    }
}

const signinFail = () => {
    return {
        type: "SIGNIN_FAIL"
    }
}

export const signin = (userName, email, password) => {
    return dispatch => {
        dispatch(signinStart());
        dispatch(layoutBackdropActions.open());

        http({
            url: 'api/account/signin',
            method: 'POST',
            data: {
                userName: userName,
                email: email,
                password: password
            }
        })
            .then(res => {
                dispatch(layoutBackdropActions.close())
                dispatch(signinSuccess());
                dispatch(push('/'));
            })
            .catch(res => {
                dispatch(layoutBackdropActions.close())
                if (res.response && res.response.data && res.response.data.errors){
                    res.response.data.errors.forEach(error => dispatch(layoutSnackbarActions.enqueueSnackbarError(error.message)))
                }
                else{
                   dispatch(layoutSnackbarActions.enqueueSnackbarError(errorMessages.network));
                }
                dispatch(signinFail());
            });
    }
}