import { useNavigate } from 'react-router-dom';

const Navigation = (props) => {
    const navigate = useNavigate();

    const signIn = () => {
        navigate('/spaApp/login');
    };

    const signUp = () => {
        navigate('/spaApp/register');
    };

    const signOut = () => {
        navigate('/spaApp/logout');
    };

    const initNavigation = () => {
        const appRole = props.role;

        switch (appRole) {
            case "admin":                
                return roleAdmin();

            case "user":
                return roleUser();

            default:
                return roleDefault();
        }
    }

    const roleAdmin = () => {
        return (
            <table>
                <tbody>
                    <tr className='main_menu'>
                        <td>
                            <input type="button" name="get_users" value="get users" />
                        </td>
                        <td>
                            <input type="button" onClick={signOut} name="sign_up" value="sign out" />
                        </td>
                    </tr> 
                </tbody>
            </table>    
        )
    }
    const roleUser = () => {
        return (
            <table>
                <tbody>
                    <tr className='main_menu'>
                        <td>
                            <input type="button" name="get_user_data" value="get user data" />
                        </td>
                        <td>
                            <input type="button" onClick={signOut} name="sign_up" value="sign out" />
                        </td>
                    </tr> 
                </tbody>
            </table>    
        )
    }

    const roleDefault = () => {
        return (
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

    return (
        initNavigation()
    )
}

export default Navigation;
