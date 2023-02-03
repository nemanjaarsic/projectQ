import axios from 'axios'
import {BASE_URL} from './apiConstants'

async function saveEmail(data){
    const resp = await axios.post(`${BASE_URL}/Email/send`, data)
                            .then(resp => {return resp})
                            .catch(err => {return err.response})
    return resp
}

async function getEmailHistory(email){
    const resp = await axios.get(`${BASE_URL}/Email/history/${email}`)
                      .then(resp => {return resp})
                      .catch(err => {return err.response})
    return resp
}

const emailRequests = {
    saveEmail,
    getEmailHistory
}

export default emailRequests