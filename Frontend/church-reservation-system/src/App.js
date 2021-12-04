import React, { useEffect } from "react";
import "./App.css";
import Login from "./Components/Login/Login";

const App = () => {
    const SaveDataHandler = (data) => {
     //some logic
    };
  return (
    <div className="">
      <Login onSaveData={SaveDataHandler} />
    </div>
  );
};
export default App;