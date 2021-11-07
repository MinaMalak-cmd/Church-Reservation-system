import React from "react";
import ReactDOM from "react-dom";
import "./index.css";
import App from "./App";
import Login from "./Components/Login/Login";
import Reservation from "./Components/Reservation/Reservation";
import {
  Route,
  BrowserRouter as Router,
  Routes,
} from "react-router-dom";
import EventsList from "./Components/Events/EventsList";
const routes = (
  <Router>
    <div>
      <Route exact path="/" component={Login} />
      <Route path="/reservation" component={Reservation} />
    </div>
  </Router>
);
ReactDOM.render(
  <Router>
    <Routes>
      <Route exact path="/" element={<Login />} />
      <Route path="/reservation" element={<Reservation />} />
      {/*
      needed to send prop to it
      <Route path="/e" element={<EventsList />} /> */}
    </Routes>
  </Router>,
  document.getElementById("root")
);
