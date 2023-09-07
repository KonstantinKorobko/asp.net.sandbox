const UserCard = (props) => {
    return (
        <table className='user_card'>
            <tbody>
                <tr>
                    <td>
                        <p>User name: {props.user.userName}</p>
                    </td>
                </tr>
                <tr>
                    <td>
                        <p>E-mail: {props.user.email}</p>
                    </td>
                </tr>
                <tr>
                    <td>
                        <p>First middle name: {props.user.firstMidName}</p>
                    </td>
                </tr>
                <tr>
                    <td>
                        <p>Last name: {props.user.lastName}</p>
                    </td>
                </tr>
                <tr>
                    <td>
                        <p>Role: {props.user.role}</p>
                    </td>
                </tr>
                <tr>
                    <td>
                        <p>Account created date: {props.user.createdDate}</p>
                    </td>
                </tr>
                <tr>
                    <td>
                        <p>Account modifited date: {props.user.modifitedDate}</p>
                    </td>
                </tr>
            </tbody>
        </table>
    )
}

export default UserCard;