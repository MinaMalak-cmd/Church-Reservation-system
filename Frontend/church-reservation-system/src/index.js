import React from "react";
import ReactDOM from "react-dom";
import "./index.css";
import Login from "./Components/Login/Login";
import Reservation from "./Components/Reservation/Reservation";
import "bootstrap/dist/css/bootstrap.min.css";
import Dashboard from "./Components/Dashboard/Dashboard";
import {
  Route,
  BrowserRouter as Router,
  Routes,
} from "react-router-dom";

ReactDOM.render(
  <Router>
    <Routes>
      <Route exact path="/" element={<Login />} />
      <Route path="/reservation" element={<Reservation />} />     
      <Route path="/dashboard" element={<Dashboard />} />     
    </Routes>
  </Router>,
  document.getElementById("root")
);
