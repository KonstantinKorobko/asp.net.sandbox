import React, { useState } from "react";
import { useNavigate } from 'react-router-dom';

const SignIn = (props) => {
    const [UserName, setUserName] = useState("Nino");
    const [Password, setPassword] = useState("12345");
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
        const requestObj = {
            method: "post",
            url: loginUrl,
            data: loginData
        };
        const result = await props.api.controller(requestObj);

        props.api.handleSetAppState(result.status);

        if (result.status === 201) {
            props.api.setAccessJWT(result.data.data);
            navigate('/spaApp');
        }
        else if (result.status === 401) {
            console.log(result);
            setResult(result.Data);
        }
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
