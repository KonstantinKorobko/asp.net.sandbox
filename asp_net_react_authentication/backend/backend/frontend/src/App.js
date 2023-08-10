//import './App.css';
//import TestCORS from "./TestCORS";
import {
  BrowserRouter as Router,
  Routes, Route, Link
} from "react-router-dom";

import Home from './Home';
import SignIn from './SignIn';

function App() {
  return (
    <Router>
      <div className="links_box">        
        <Link className="links" to="/login">login</Link>  
      </div>

      <Routes>
        <Route path="/spaApp" element={<Home />} />
        <Route path="/login" element={<SignIn />} />
      </Routes>
    </Router>
  )
}

export default App;
