import React, { useState } from "react";
import ControllerPost from './ControllerPost';
import HelperGetResponseObj from './HelperGetResponseObj';

const SignUp = () => {
    const [UserName, setUserName] = useState('Nino');
    const [UserNameStatus, setUserNameStatus] = useState("");
   /*const [Email, setEmail] = useState("");
    const [FirstMidName, setFirstMidName] = useState("");
    const [LastName, setLastName] = useState("");
    const [Password, setPassword] = useState("");
    const [ConfirmPassword, setConfirmPassword] = useState("");*/

    const isNameUrl = 'https://localhost:7129/api/User/isname'    

    const handleAddUserName = (input) => {        
        setUserName(input.target.value);
    }

     const handleOnClickCreate = async () => {
        const dataObj = {UserName: UserName};

        const result = await HelperGetResponseObj(ControllerPost(isNameUrl, dataObj));

        setUserNameStatus(result.userName);
    }

    return (
        <div>
            <h2>Register</h2>
            <form >
                Login:      <input type="text" value={UserName} onChange={handleAddUserName} name="login" />
                <p>{UserNameStatus}</p>
                <br></br>
                <br></br>
                E-mail:     <input type="e-mail" name="email" />
                <br></br>
                <br></br>
                FirstMidName:   <input type="text" name="first_mid_name" />
                <br></br>
                <br></br>
                LastName:   <input type="text" name="last_name" />
                <br></br>
                <br></br>
                Password:   <input type="password" name="password" />
                <br></br>
                <br></br>
                Confirm password:   <input type="password" name="confirm_password" />
                <br></br>
                <br></br>
                Create new account: <input type="button" onClick={handleOnClickCreate} name="create" value="create" />
            </form>
        </div>
    )
}

export default SignUp;
