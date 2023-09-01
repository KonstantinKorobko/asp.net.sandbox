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
  const sessionJWT = useRef("my JWT");
  const setSessionJWT = (new_jwt) => {
    sessionJWT.current = new_jwt;
  }
  const getSessionJWT = () => {
    return sessionJWT.current;
  }

  const  Controller = async (request_obj) => {
    switch (request_obj.method) {
      case "post":
        const requestObj = {
          sessionJWT: getSessionJWT(),
          method: request_obj.method,
          url: request_obj.url,
          data: request_obj.data
        };
        return await HelperResponse(sessionInterface, ControllerPost(requestObj));
    
      default:
        break;
    }
    
  }

  const appInterface = {
    Controller
  };
  const sessionInterface = {
    setSessionJWT,
    getSessionJWT
  };

  return (
      <Routes>
        <Route path="/spaApp" element={<Home />} />
        <Route path="/spaApp/login" element={<SignIn appInterface={appInterface} />} />
        <Route path="/spaApp/register" element={<SignUp />} />
      </Routes>
  )
}

export default App;
