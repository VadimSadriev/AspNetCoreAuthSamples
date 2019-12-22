import axios from 'axios';

export default axios.create({
    method: 'GET',
    baseURL: `${process.env.REACT_APP_API_URL}`,
    headers: {
        'Content-Type': 'application/json',
        'Accept': 'application/json'
    },
})