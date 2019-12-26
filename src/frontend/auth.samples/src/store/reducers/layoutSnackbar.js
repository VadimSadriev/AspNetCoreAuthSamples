
const initialState = {
    messages: []
}

const layoutSnackbarReducer = (state = initialState, action) => {
    switch (action.type) {
        case "LAYOUTBACKDROP_ADD": {
            return {
                ...state,
                isOpen: true
            }
        }
        case "LAYOUTBACKDROP_REMOVE": {
            return {
                ...state,
            }
        }
        default:
            return state;
    }
}

export default layoutSnackbarReducer;