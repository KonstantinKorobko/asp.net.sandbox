import React, { useState } from "react";
import ControllerPost from './ControllerPost';
import HelperGetResponseObj from './HelperGetResponseObj';

const SignUp = () => {
    const [UserName, setUserName] = useState('');
    const [UserNameStatus, setUserNameStatus] = useState("");
    const [Email, setEmail] = useState("a1@mail.com");
    const [EmailStatus, setEmailStatus] = useState("");
    const [FirstMidName, setFirstMidName] = useState("");
    const [LastName, setLastName] = useState("");
    const [Password, setPassword] = useState("12345");
    const [PasswordStatus, setPasswordStatus] = useState("");
    const [ConfirmPassword, setConfirmPassword] = useState("");

    const isNameUrl = 'https://localhost:7129/api/Register/isname';
    const isEmailUrl = 'https://localhost:7129/api/Register/isemail';
    const isPasswordUrl = 'https://localhost:7129/api/Register/ispassword';

    const handleAddUserName = (input) => {
        setUserName(input.target.value);
    }
    const handleAddEmail = (input) => {
        setEmail(input.target.value);
    }
    const handleFirstMidName = (input) => {
        setFirstMidName(input.target.value);
    }
    const handleLastName = (input) => {
        setLastName(input.target.value);
    }
    const handlePassword = (input) => {
        setPassword(input.target.value);
    }
    const handleConfirmPassword = (input) => {
        setConfirmPassword(input.target.value);
    }

    const handleOnClickCreate = async () => {
        if (UserName.length > 0) {
            const userNameObj = {UserName: UserName};
            const resultUserName = await HelperGetResponseObj(ControllerPost(isNameUrl, userNameObj));
            setUserNameStatus(resultUserName.userName);            
        }
        else
        {
            setUserNameStatus("The Login field is required.");
        }


        const emailObj = {Email: Email};
        const resultEmail = await HelperGetResponseObj(ControllerPost(isEmailUrl, emailObj));
        setEmailStatus(resultEmail.email);

        const passwordObj = {Password: Password};
        const resultPassword = await HelperGetResponseObj(ControllerPost(isPasswordUrl, passwordObj));
        setPasswordStatus(resultPassword.Password);
    }

    return (
        <div>
            <h2>Register</h2>
            <form >
                Login:      <input type="text" value={UserName} onChange={handleAddUserName} name="login" />
                <p>{UserNameStatus}</p>
                <br></br>
                E-mail:     <input type="text" value={Email} onChange={handleAddEmail} name="email" />
                <p>{EmailStatus}</p>
                <br></br>
                FirstMidName:   <input type="text" value={FirstMidName} onChange={handleFirstMidName} name="first_mid_name" />
                <br></br>
                <br></br>
                LastName:   <input type="text" value={LastName} onChange={handleLastName} name="last_name" />
                <br></br>
                <br></br>
                Password:   <input type="password" value={Password} onChange={handlePassword} name="password" />
                <p>{PasswordStatus}</p>
                <br></br>
                Confirm password:   <input type="password" value={ConfirmPassword} onChange={handleConfirmPassword} name="confirm_password" />
                <br></br>
                <br></br>
                Create new account: <input type="button" onClick={handleOnClickCreate} name="create" value="create" />
            </form>
        </div>
    )
}

export default SignUp;
