import React, { useState, useEffect, useCallback } from "react";
import "./App.css";
import Login from "./Components/Login/Login";
import Reservation from "./Components/Reservation/Reservation";
import "bootstrap/dist/css/bootstrap.min.css";
const App = () => {
  let expenseData ={};
    const SaveDataHandler = (data) => {
      expenseData = {
        ...data,
        id: Math.random().toString(),
      };
      console.log(expenseData);
    };
    useEffect(() => {    
    }, [expenseData]);
  return (
    <div className="">
      <Login onSaveData={SaveDataHandler} />
      {/* <Reservation /> */}
    </div>
  );
};
export default App;