const SignUp = (props) => {
    
    return (
        <div>
            <h2>Register</h2>
            <form >
                Login:      <input type="text" name="login" />
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
                Create new account: <input type="button" name="register" value="register" />
            </form>
        </div>
    )
}

export default SignUp;
