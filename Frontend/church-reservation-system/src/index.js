import React from "react";
import ReactDOM from "react-dom";
import "./index.css";
import App from "./App";
import Login from "./Components/Login/Login";
import Reservation from "./Components/Reservation/Reservation";
import {
  Route,
  Link,
  BrowserRouter as Router,
  Switch,
  Routes,
} from "react-router-dom";
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
    <App />
  </Router>,
  document.getElementById('root')
);
// ReactDOM.render(routes, document.getElementById("root"));
