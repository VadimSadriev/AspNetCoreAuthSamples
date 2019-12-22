
const initialState = {
    isOpen: false
}

const globalBackdropReducer = (state = initialState, action) => {
    switch (action.type) {
        case "GLOBALBACKDROP_OPEN": {
            return {
                ...state,
                isOpen: true
            }
        }
        case "GLOBALBACKDROP_CLOSE": {
            return {
                ...state,
                isOpen: false
            }
        }
        default:
            return state;
    }
}

export default globalBackdropReducer;