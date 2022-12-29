import * as React from 'react';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';

export default function EmailHistoryTable({data}) {
    let key = 0
  return (
    <TableContainer component={Paper}>
      <Table sx={{ minWidth: 650 }} aria-label="simple table">
        <TableHead>
          <TableRow>
            <TableCell>From</TableCell>
            <TableCell>To</TableCell>
            <TableCell>CC</TableCell>
            <TableCell>Subject</TableCell>
            <TableCell>Importance</TableCell>
            <TableCell>Content</TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {data.map((row) => (
            <TableRow
              key={key++}
              sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
            >
              <TableCell>{row.from}</TableCell>
              <TableCell>{row.to}</TableCell>
              <TableCell>{ row.cc.length > 1 ? row.cc.map((email => (<>{email} <br/></>))) : row.cc}</TableCell>
              <TableCell>{row.subject}</TableCell>
              <TableCell>{row.importance}</TableCell>
              <TableCell>{row.content}</TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </TableContainer>
  );
}