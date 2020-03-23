
const initialState = {
    isLoading: false
}

const signinReducer = (state=initialState, action) => {
    switch(action.type){
        case "SIGNIN_START": {
            return {
                ...state,
                isLoading: true
            };
        }
        case "SIGNIN_SUCCESS": {

            const { token, refreshToken} = action.payload;

            localStorage.setItem('token', token);
            localStorage.setItem('refreshToken', refreshToken);

            return {
                ...state,
                isLoading: false
            };
        }
        case "SIGNIN_FAIL": {
            return {
                ...state,
                isLoading: false
            };
        }
        default:
            return state;
    }
}

export default signinReducer;