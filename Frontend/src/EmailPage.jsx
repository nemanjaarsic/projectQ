import React, { useState } from 'react';
import Button from '@mui/material/Button';
import TextField from '@mui/material/TextField';
import Radio from '@mui/material/Radio';
import RadioGroup from '@mui/material/RadioGroup';
import FormControlLabel from '@mui/material/FormControlLabel';
import FormControl from '@mui/material/FormControl';
import FormLabel from '@mui/material/FormLabel';
import Modal from '@mui/material/Modal';
import EmailHistoryTable from './EmailHistoryTable';
import Box from '@mui/material/Box';
import Typography from '@mui/material/Typography';
import Alert from '@mui/material/Alert'
import Snackbar from '@mui/material/Snackbar'
import emailRequests from './api/emailRequests';

const style = {
  position: 'absolute',
  top: '50%',
  left: '50%',
  transform: 'translate(-50%, -50%)',
  width: 400,
  bgcolor: 'background.paper',
  border: '2px solid #000',
  boxShadow: 24,
  p: 4,
};

const EmailForm = () => {
  const [fromEmail, setFromEmail] = useState('');
  const [toEmail, setToEmail] = useState('');
  const [cc, setCc] = useState([]);
  const [priority, setPriority] = useState(1);
  const [subject, setSubject] = useState('');
  const [content, setContent] = useState('');
  const [emailHistory, setEmailHistory] = useState([]);
  const [error, setError] = useState('');
  const [userEmail, setUserEmail] = useState('')
  const [openEmailHistory, setOpenEmailHistory] = useState(false)

  const [openModal, setOpenModal] = useState(false);
  const handleOpenModal = () => setOpenModal(true);
  const handleCloseModal = () => setOpenModal(false);
  const [openAlert, setOpenAlert] = useState(false);
  const handleCloseAlert = (event, reason) => {
    if (reason === 'clickaway') {
      return;
    }
    setOpenAlert(false);
  };

  const handleCc = (value) => {
    if(value !== ''){
      setCc(value.split(','))
    }
    else{
      setCc([])
    }
  }

  async function handleSubmit(event) {
    event.preventDefault();
    const data = { 
      from: fromEmail, 
      to: toEmail, 
      cc: cc, 
      importance: parseInt(priority),  
      subject: subject, 
      content: content
    }
    const resp = await emailRequests.saveEmail(data)
    if(resp.status >= 300){
      setError(resp.data)
      setOpenAlert(true)
    }
  }

  async function getHistory(event) {
    event.preventDefault();
    const resp = await emailRequests.getEmailHistory(userEmail)
    if(resp.status >= 200 && resp.status < 300){
      setEmailHistory(resp.data)
      setOpenEmailHistory(true)
    } else if (resp.status === 404) {
      setEmailHistory([])
      setOpenEmailHistory(false)
      setError("Please enter an email address.")
      setOpenAlert(true)
    } else {
      setEmailHistory([])
      setOpenEmailHistory(false)
      setError(resp.data)
      setOpenAlert(true)
    }
  }

  function handleCancel(){
    setFromEmail('')
    setToEmail('')
    setCc('')
    setPriority(1)
    setSubject('')
    setContent('')
    setOpenModal(false)
  }

  return (
    <div>
      <form onSubmit={handleSubmit}>
        <div>
          <TextField
            required
            id="outlined-required"
            label="From"
            value={fromEmail}
            onInput={ e=>setFromEmail(e.target.value)}
          />
        </div>
        <div>
           <TextField
              required
              id="outlined-required"
              label="To"
              value={toEmail}
              onInput={ e=>setToEmail(e.target.value)}
            />
        </div>
        <div>
          <TextField
            id="outlined"
            label="CC"
            value={cc}
            onInput={ e=>handleCc(e.target.value)}
            helperText="Use [,] as email separator"
          />
        </div>
        <div>
          <FormControl>
            <FormLabel id="demo-row-radio-buttons-group-label">Priority</FormLabel>
            <RadioGroup
              row
              aria-labelledby="demo-radio-buttons-group-label"
              name="radio-buttons-group"
              defaultValue="1"
              onInput={ e=>setPriority(e.target.value)}
            >
              <FormControlLabel value="1" control={<Radio />} label="Low" />
              <FormControlLabel value="2" control={<Radio />} label="Medium" />
              <FormControlLabel value="3" control={<Radio />} label="High" />
            </RadioGroup>
          </FormControl>
        </div>
        <div>
          <TextField
            id="outlined"
            label="Subject"
            value={subject}
            onInput={ e=>setSubject(e.target.value)}
          />
        </div>
        <div>
          <TextField
            id="outlined"
            label="Content"
            value={content}
            onInput={ e=>setContent(e.target.value)}
          />
        </div>
        <Button type="submit" variant="contained">Send</Button>
        <div>
          <Button variant="contained" onClick={handleOpenModal}>Cancel</Button>
          <Modal
            open={openModal}
            onClose={handleCloseModal}
            aria-labelledby="modal-modal-title"
            aria-describedby="modal-modal-description"
          >
            <Box sx={style}>
              <Typography id="modal-modal-title" variant="h6" component="h2">
                Are you sure you want to cancel?
              </Typography>
              <Button onClick={handleCancel}>Yes</Button>
              <Button onClick={handleCloseModal}>No</Button>
            </Box>
          </Modal>
        </div>
      </form>
      <br/>
        <div>
          <>
            <TextField
              id="outlined"
              label="Get users email history"
              value={userEmail}
              onInput={ e=>setUserEmail(e.target.value)}
            />
          </>
          <Button onClick={e => getHistory(e)} >History</Button>
          {openEmailHistory ? <EmailHistoryTable data={emailHistory}/> : <></> }
        </div>
        <Snackbar open={openAlert} autoHideDuration={6000} onClose={handleCloseAlert}>
          <Alert severity="error" sx={{ width: '100%' }}>
            {error}
          </Alert>
        </Snackbar>
    </div>  
  )
}

export default EmailForm;