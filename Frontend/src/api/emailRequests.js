import axios from 'axios'

async function saveEmail(data){
    const resp = await axios.post('https://localhost:7049/api/Email/send', data)
                            .then(resp => {return resp})
                            .catch(err => {return err.response})
    return resp
}

async function getEmailHistory(email){
    const resp = await axios.get(`https://localhost:7049/api/Email/history/${email}`)
                      .then(resp => {return resp})
                      .catch(err => {return err.response})
    return resp
}

const emailRequests = {
    saveEmail,
    getEmailHistory
}

export default emailRequests