import './App.css';
//import TestCORS from "./TestCORS";
import {
  Routes, Route
} from "react-router-dom";
import React, { useRef } from "react";

import Home from './Home';
import SignIn from './SignIn';
import SignUp from './SignUp';
import HelperResponse from './HelperResponse';
import ControllerPost from './ControllerPost';

function App() {
  const accessJWT = useRef("");
  const setAccessJWT = (new_jwt) => {
    accessJWT.current = new_jwt;
  }
  const getAccessJWT = () => {
    return accessJWT.current;
  }

  const  controller = async (request_obj) => {
    switch (request_obj.method) {
      case "post":
        const requestObj = {
          accessJWT: getAccessJWT(),
          method: request_obj.method,
          url: request_obj.url,
          data: request_obj.data
        };
        return await HelperResponse(api, ControllerPost(requestObj));
    
      default:
        break;
    }
    
  }

  const api = {
    controller,
    setAccessJWT,
    getAccessJWT
  };

  return (
      <Routes>
        <Route path="/spaApp" element={<Home />} />
        <Route path="/spaApp/login" element={<SignIn api={api} />} />
        <Route path="/spaApp/register" element={<SignUp api={api} />} />
      </Routes>
  )
}

export default App;
