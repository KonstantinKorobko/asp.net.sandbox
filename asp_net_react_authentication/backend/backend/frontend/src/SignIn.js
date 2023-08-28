import React, { useState } from "react";
import { useNavigate } from 'react-router-dom';
import ControllerPost from './ControllerPost';
import HelperGetResponseObj from './HelperGetResponseObj';

const SignIn = (props) => {
    const [UserName, setUserName] = useState("");
    const [Password, setPassword] = useState("");
    const [Result, setResult] = useState("");

    const navigate = useNavigate();

    const loginUrl = 'https://localhost:7129/api/Login';

    const handleAddUserName = (input) => {
        setUserName(input.target.value);
    }

    const handlePassword = (input) => {
        setPassword(input.target.value);
    }

    const handleOnClickLogin = async () =>{
        const loginData = {
            UserName: UserName,
            Password: Password
        };
        const result = await HelperGetResponseObj(ControllerPost(loginUrl, loginData));
        setResult(result.Data);
    }

    return (
        <div>
            <h2>SignIn</h2>
            <form >
                Login:    <input type="text" value={UserName} onChange={handleAddUserName} name="login" />
                Password: <input type="password" value={Password} onChange={handlePassword} name="password" />
                <input type="button" onClick={handleOnClickLogin} name="sign_in" value="sign in" />
                <p className="errorText">{Result}</p>
                <br></br>
                Create new account: <input type="button"name="sign_up" value="sign up" />
            </form>    
        </div>
    )
}

export default SignIn;
