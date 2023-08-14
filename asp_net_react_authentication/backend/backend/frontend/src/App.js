import './App.css';
//import TestCORS from "./TestCORS";
import {
  Routes, Route
} from "react-router-dom";

import Home from './Home';
import SignIn from './SignIn';
import SignUp from './SignUp';

function App() {
  return (
      <Routes>
        <Route path="/spaApp" element={<Home />} />
        <Route path="/spaApp/login" element={<SignIn />} />
        <Route path="/spaApp/register" element={<SignUp />} />
      </Routes>
  )
}

export default App;
