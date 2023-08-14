//import { NavLink } from 'react-router-dom'
import { useNavigate, Link } from 'react-router-dom';

const Navigation = (props) => {    
    /*return (
        <nav>
            <ul>
                <li>
                    <NavLink to="/spaApp/login">SignIn</NavLink>
                </li>
            </ul>
        </nav>
    )*/
    return(
        <table>
            <tbody>
                <tr className='main_menu'>
                    <td>
                        <input type="button" name="sign_in" value="sign in" />
                    </td>
                    <td>
                        <input type="button" name="sign_up" value="sign up" />
                    </td>
                </tr> 
            </tbody>
        </table>    
    )
}

export default Navigation;