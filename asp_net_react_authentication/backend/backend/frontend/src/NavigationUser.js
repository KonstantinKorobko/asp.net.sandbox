//import { useNavigate } from 'react-router-dom';

const NavigationUser = (props) => {
    //const navigate = useNavigate();

    const getUserDataUrl = 'https://localhost:7129/api/User/getusers';

    const handleOnClickGetUserData = async () =>{
        const loginData = {            
        };
        const requestObj = {
            method: "post",
            url: getUserDataUrl,
            data: loginData
        };
        const result = await props.api.controller(requestObj);

        //props.api.handleSetAppState(result.status);
        console.log(result.status);

        if (result.status === 201) {
            console.log(result.data);
        }
        else if (result.status === 401) {
            //setResult(result.Data);
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
            </tbody>
        </table>    
    )
}

export default NavigationUser;
