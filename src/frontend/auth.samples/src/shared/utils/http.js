import axios from 'axios';

export const http = axios.create({
    method: 'GET',
    baseURL: `${process.env.REACT_APP_API_URL}`,
    headers: {
        'Content-Type': 'application/json',
        'Accept': 'application/json'
    },
})

export const errorMessages = {
    network: "Unknown error occured during your request."
}