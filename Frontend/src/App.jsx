import './App.css';
import React, { Component } from 'react';
import EmailForm from './EmailPage';

class App extends Component {
  
  render() {
    return (
      <div className="App">
        <header className="App-header">
          <EmailForm/>
        </header>
      </div>
    );
  }
}

export default App;
