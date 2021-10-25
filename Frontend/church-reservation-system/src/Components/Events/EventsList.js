import React from "react";
import Event from "./Event";
import classes from "./EventsList.module.css";

const EventsList = (props) => {
  return (
    <ul className={classes["events-list"]}>
      {props.events.map((event) => (
        <Event
          key={event.id}
          name={event.name}
          maxCapacity={event.maxCapacity}
          currentSeats={event.currentSeats}
          date={event.date}
          duration={event.duration}        
        />
      ))}
    </ul>
  );
};

export default EventsList;
