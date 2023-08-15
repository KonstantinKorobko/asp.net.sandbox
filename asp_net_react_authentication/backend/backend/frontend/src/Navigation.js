import { useNavigate } from 'react-router-dom';

const Navigation = () => {
    const navigate = useNavigate();

    const signIn = () => {
        navigate('/spaApp/login');
    };

    const signUp = () => {
        navigate('/spaApp/register');
    };

    return(
        <table>
            <tbody>
                <tr className='main_menu'>
                    <td>
                        <input type="button" onClick={signIn} name="sign_in" value="sign in" />
                    </td>
                    <td>
                        <input type="button" onClick={signUp} name="sign_up" value="sign up" />
                    </td>
                </tr> 
            </tbody>
        </table>    
    )
}

export default Navigation;
