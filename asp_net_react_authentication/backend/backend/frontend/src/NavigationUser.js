//import { useNavigate } from 'react-router-dom';
import React, { useState } from "react";
import UserCard from './UserCard';

const NavigationUser = (props) => {
    const [browsingData, setBrowsingData] = useState();
    //const navigate = useNavigate();

    const getUserDataUrl = 'https://localhost:7129/api/User/getuser';

    const handleOnClickGetUserData = async () =>{
        const loginData = {            
        };
        const requestObj = {
            method: "post",
            url: getUserDataUrl,
            data: loginData
        };
        const result = await props.api.controller(requestObj);

        props.api.handleSetAppState(result.status);
        
        if (result.status === 201) {
            setBrowsingData(<UserCard user={result.data}/>);
        }
    }
    return (
        <table>
            <tbody>
                <tr className='main_menu'>
                    <td>
                        <input type="button" onClick={handleOnClickGetUserData} name="get_user_data" value="get user data" />
                    </td>
                </tr>
                <tr>
                    <td>{browsingData}</td>
                </tr>
            </tbody>
        </table>    
    )
}

export default NavigationUser;
