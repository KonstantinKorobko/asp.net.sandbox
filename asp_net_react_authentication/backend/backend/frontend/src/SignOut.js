import { useNavigate } from 'react-router-dom';

const SignOut = (props) => {
    const navigate = useNavigate();

    //const logoutUrl = 'https://localhost:7129/api/Logout';

    const handleOnClickYes = () =>{
        //ToDo add async remove RefreshRT from DB
        props.api.handleSetAppState(401);
        props.api.setAccessJWT("JWT");
        props.api.setRefreshRT("RT");
        props.api.handleSetAppRole("");

        navigate('/spaApp');
    }
    const handleOnClickNo = () =>{
        navigate('/spaApp');
    }

    return (
        <div>
            <h2>SignOut</h2>
            <form >
                Are you sure you want to logout?    <input type="button" onClick={handleOnClickYes} name="yes" value="yes" />
                                                    <input type="button" onClick={handleOnClickNo} name="no" value="no" />
            </form>    
        </div>
    )
}

export default SignOut;
