import { http, errorMessages } from '../../shared/utils/http';
import { push } from 'connected-react-router';
import * as layoutBackdropActions from './layoutBackdrop';
import * as layoutSnackbarActions from './layoutSnackbar';

const signinStart = () => {
    return {
        type: "SIGNIN_START"
    }
}

const signinSuccess = (token, refreshToken) => {
    return {
        type: "SIGNIN_SUCCESS",
        payload: {
            token,
            refreshToken
        }
    }
}

const signinFail = () => {
    return {
        type: "SIGNIN_FAIL"
    }
}

export const signin = (userNameOrEmail, password) => {
    return dispatch => {
        dispatch(signinStart());
        dispatch(layoutBackdropActions.open());

        http({
            url: 'api/account/jwt/signin',
            method: 'POST',
            data: {
                userNameOrEmail: userNameOrEmail,
                password: password
            }
        })
            .then(res => {
                dispatch(layoutBackdropActions.close());
                const { token, refreshToken } = res.data;
                dispatch(signinSuccess(token, refreshToken));
                dispatch(push('/'));
            })
            .catch(res => {
                dispatch(layoutBackdropActions.close())
                if (res.response && res.response.data && res.response.data.errors) {
                    res.response.data.errors.forEach(error => dispatch(layoutSnackbarActions.enqueueSnackbarError(error.message)))
                }
                else {
                    dispatch(layoutSnackbarActions.enqueueSnackbarError(errorMessages.network));
                }
                dispatch(signinFail());
            });
    }
}