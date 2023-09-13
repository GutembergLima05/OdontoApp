import React, { useEffect, useState } from "react";
import api from './services/api';
import './App.css'

function App() {
  const [user, setUser] = useState();

  useEffect(() => {
    api
      .get('/api/Paciente')
      .then((response) => setUser(response.data.dados))
      .catch((err) => {
        console.error("ops! ocorreu um erro" + err);
      });
  }, []);

  return (
    <div className="App">
      {
        user && user.map((item,index)=> (
          <div key = {index} >
            <p>Usuário: {item.name}</p>
            <p>Biografia: {item.email}</p>
          </div>
        ))
      }
      
    </div>
  );
}

export default App
