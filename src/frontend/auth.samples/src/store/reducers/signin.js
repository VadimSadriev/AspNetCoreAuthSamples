
const initialState = {
    isLoading: false
}

const signinReducer = (state=initialState, action) => {
    switch(action.type){
        case "SIGIN_START": {
            return {
                ...state,
                isLoading: true
            };
        }
        case "SIGIN_SUCCESS": {
            return {
                ...state,
                isLoading: false
            };
        }
        case "SIGIN_FAIL": {
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