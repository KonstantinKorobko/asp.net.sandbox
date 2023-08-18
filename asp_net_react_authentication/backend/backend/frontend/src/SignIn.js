const SignIn = (props) => {
    
    return (
        <div>
            <h2>SignIn</h2>
            <form >
                Login:    <input type="text" name="login" />    Password: <input type="password" name="password" /> <input type="button" name="sign_in" value="sign in" />
                <br></br>                
                <br></br>
                Create new account: <input type="button" name="sign_up" value="sign up" />
            </form>    
        </div>
    )
}

export default SignIn;
