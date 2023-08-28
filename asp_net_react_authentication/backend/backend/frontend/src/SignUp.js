import React, { useState } from "react";
import { useNavigate } from 'react-router-dom';
import ControllerPost from './ControllerPost';
import HelperGetResponseObj from './HelperGetResponseObj';

const SignUp = () => {
    const [UserName, setUserName] = useState('Mino');
    const [UserNameStatus, setUserNameStatus] = useState("");
    const [Email, setEmail] = useState("a1@mail.com");
    const [EmailStatus, setEmailStatus] = useState("");
    const [FirstMidName, setFirstMidName] = useState("");
    const [FirstMidNameStatus, setFirstMidNameStatus] = useState("");
    const [LastName, setLastName] = useState("");
    const [LastNameStatus, setLastNameStatus] = useState("");
    const [Password, setPassword] = useState("");
    const [PasswordStatus, setPasswordStatus] = useState("");
    const [ConfirmPassword, setConfirmPassword] = useState("");
    const [ConfirmPasswordStatus, setConfirmPasswordStatus] = useState("");

    const navigate = useNavigate();

    const isNameUrl = 'https://localhost:7129/api/Register/isname';
    const isEmailUrl = 'https://localhost:7129/api/Register/isemail';
    const isFirstMidNameUrl = 'https://localhost:7129/api/Register/isfirstmidname';
    const isLastNameUrl = 'https://localhost:7129/api/Register/islastname';
    const isPasswordUrl = 'https://localhost:7129/api/Register/ispassword';
    const createNewUserUrl = 'https://localhost:7129/api/User';

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
        const userNameObj = {Data: UserName};
        const resultUserName = await HelperGetResponseObj(ControllerPost(isNameUrl, userNameObj));
        if (resultUserName.Data === "The Data field is required.") {
            setUserNameStatus("The User name field is required!");
            return;
        }
        else if (resultUserName.data === "User name already exists.")
        {
            setUserNameStatus("User name already exists.");
            return;
        }
        else{
            setUserNameStatus("");
        }

        const emailObj = {Data: Email};
        const resultEmail = await HelperGetResponseObj(ControllerPost(isEmailUrl, emailObj));
        if (resultEmail.Data === "The Data field is required.") {
            setEmailStatus("The E-mail field is required!");
            return;
        }
        else if (resultEmail.data === "Email already registered.")
        {
            setEmailStatus("Email already registered.");
            return;
        }
        else{
            setEmailStatus("");
        }

        const firstMidNameObj = {Data: FirstMidName};
        const resultFirstMidName = await HelperGetResponseObj(ControllerPost(isFirstMidNameUrl, firstMidNameObj));
        if (resultFirstMidName.Data === "The Data field is required.") {
            setFirstMidNameStatus("The FirstMidName field is required!");
            return;
        }
        else{
            setFirstMidNameStatus("");
        }

        const lastNameObj = {Data: LastName};
        const resultLastName = await HelperGetResponseObj(ControllerPost(isLastNameUrl, lastNameObj));
        if (resultLastName.Data === "The Data field is required.") {
            setLastNameStatus("The Last Name field is required!");
            return;
        }
        else{
            setLastNameStatus("");
        }        

        const passwordObj = {Data: Password};
        const resultPassword = await HelperGetResponseObj(ControllerPost(isPasswordUrl, passwordObj));
        if (resultPassword.Data === "The Data field is required.") {
            setPasswordStatus("The Password field is required!");
            return;
        }
        else{
            setPasswordStatus("");
        }

        if (Password !== ConfirmPassword) {
            setConfirmPasswordStatus("The Password not same!");
            return;
        }

        const userObj = {
            UserName: UserName,
            Email: Email,
            Password: Password,
            FirstMidName: FirstMidName,
            LastName: LastName
        };        

        const resultNewUser = await HelperGetResponseObj(ControllerPost(createNewUserUrl, userObj));
        if (resultNewUser.data === "New user successfully created.") {
            navigate('/spaApp/login');
        }
        else
        {
            return;
        }
    }

    return (
            <div>
                <h2>Register</h2>
                <form >
                    User name:      <input type="text" value={UserName} onChange={handleAddUserName} name="login" />
                    <p className="errorText">{UserNameStatus}</p>
                    <br></br>
                    E-mail:     <input type="text" value={Email} onChange={handleAddEmail} name="email" />
                    <p className="errorText">{EmailStatus}</p>
                    <br></br>
                    FirstMidName:   <input type="text" value={FirstMidName} onChange={handleFirstMidName} name="first_mid_name" />
                    <p className="errorText">{FirstMidNameStatus}</p>
                    <br></br>
                    LastName:   <input type="text" value={LastName} onChange={handleLastName} name="last_name" />
                    <p className="errorText">{LastNameStatus}</p>
                    <br></br>
                    Password:   <input type="password" value={Password} onChange={handlePassword} name="password" />
                    <p className="errorText">{PasswordStatus}</p>
                    <br></br>
                    Confirm password:   <input type="password" value={ConfirmPassword} onChange={handleConfirmPassword} name="confirm_password" />
                    <p className="errorText">{ConfirmPasswordStatus}</p>
                    <br></br>
                    Create new account: <input type="button" onClick={handleOnClickCreate} name="create" value="create" />
                </form>
            </div>
    )
}

export default SignUp;
