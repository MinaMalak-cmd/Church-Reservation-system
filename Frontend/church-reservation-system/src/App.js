import React, { useEffect } from "react";
import {
  Route,
  BrowserRouter as Router,
  Routes,
} from "react-router-dom";
import "./App.css";
import Login from "./Components/Login/Login";
import Dashboard from "./Components/Dashboard/Dashboard";
import Reservation from "./Components/Reservation/Reservation";
import RoleContext from "./Components/RoleContext/RoleContext";

const App = () => {
  const RoleProvider = RoleContext.Provider;
  let role = localStorage.getItem("role") == undefined ? "user" : localStorage.getItem("role");
  let data = JSON.parse(localStorage.getItem("data")) == undefined ? {name:"",phone:""} : JSON.parse(localStorage.getItem("data"));
  // contains data & role
  let counter = 0;
  const user = {
    role : role,
    data : data
  }
  useEffect (()=>{
    counter++;
    console.log(counter);
  })
  return (
    <div className="">
      <RoleProvider value={user}>
        <Router>
          <Routes>
            {user.role==="user" && 
              <Route exact path="/" element={<Login />} />
            }
            {(user.role==="alreadyRegistered")&&
              <Route path="/reservation" element={<Reservation />} />  
            }
            {(user.role==="admin"&& user.data.name==="admin123" && user.data.phone==="01234556789") &&
              <Route path="/dashboard" element={<Dashboard />} />     
            }   
          </Routes>
        </Router>
      </RoleProvider>
    </div>
  );
};
export default App;