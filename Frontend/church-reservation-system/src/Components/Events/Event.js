import React from "react";
import classes from "./Event.module.css";

const Event = (props) => {
  return (
    <li className={classes.event}>
      <h2>{props.name}</h2>
      <h3>{props.date}</h3>
      <p>{props.duration}</p>
      <span className="d-block">{props.maxCapacity}</span>
      <span className="d-block">{props.currentSeats}</span>
    </li>
  );
};

export default Event;
