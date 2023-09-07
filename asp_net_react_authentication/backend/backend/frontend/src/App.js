import './App.css';
import {
  Routes, Route
} from "react-router-dom";
import React, { useRef, useState} from "react";

import Home from './Home';
import SignIn from './SignIn';
import SignUp from './SignUp';
import SignOut from './SignOut';
import HelperResponse from './HelperResponse';
import ControllerPost from './ControllerPost';

function App() {
  const accessJWT = useRef("JWT");
  const refreshRT = useRef("RT");

  const [appState, setAppState] = useState(401);
  const [appRole, setAppRole] = useState("");

  const setAccessJWT = (new_jwt) => {
    accessJWT.current = new_jwt;
  }
  const getAccessJWT = () => {
    return accessJWT.current;
  }

  const setRefreshRT = (new_jwt) => {
    refreshRT.current = new_jwt;
  }
  const getRefreshRT = () => {
    return refreshRT.current;
  }

  const handleSetAppState = (state) => {
    setAppState(state);
  }
  const handleGetAppState = () => {
    return appState;
  }

  const handleSetAppRole = (role) => {
    setAppRole(role);
  }
  const handleGetAppRole = () => {
    return appRole;
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
    getAccessJWT,
    setRefreshRT,
    getRefreshRT,
    handleSetAppState,
    handleGetAppState,
    handleSetAppRole,
    handleGetAppRole
  };

  return (
      <Routes>
        <Route path="/spaApp" element={<Home api={api} />} />
        <Route path="/spaApp/login" element={<SignIn api={api} />} />
        <Route path="/spaApp/register" element={<SignUp api={api} />} />
        <Route path="/spaApp/logout" element={<SignOut api={api} />} />
      </Routes>
  )
}

export default App;
