import React, { useState, useEffect, useCallback } from "react";
import Styles from "./Reservation.module.css";
import EventsList from "../Events/EventsList";
const Reservation = () => {
  const url = "http://localhost:62962/api/Masses";
  const [content, setContent] = useState(<p>No items found</p>);
  let tempEvents = [];
  const fetchHandler = useCallback(async () => {
    setContent(<p>Loading ...</p>);
    try {
      let response = await fetch(url, {
        headers: {
          "Content-Type": "application/json",
        },
      });
      if (!response.ok) throw new Error("something went wrong dear");
      let data = await response.json();
      console.log(data);
      tempEvents = data.map((event) => {
        return {
          id: event.massId,
          name: event.name,
          maxCapacity: event.maxCapacity,
          currentSeats: event.currentSeats,
          date: event.date,
          duration: event.duration,
        };
      });
      setContent(<EventsList events={tempEvents} />);
      //   massId: 1, name: 'عشية الاحد', maxCapacity: 100, 
      //currentSeats: 99, date,duration
    } catch (error) {
      setContent(<p>{error.message}</p>);
    } finally {
      //write your code that you want to be executed in both cases
    }
  }, []);
  useEffect(() => {
    fetchHandler();
  }, [fetchHandler]);
  return (
    <div className="">
      <section>{content}</section>
    </div>
  );
};

export default Reservation;
