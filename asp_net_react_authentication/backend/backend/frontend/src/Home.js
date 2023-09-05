import Navigation from './Navigation';

const Home = (props) => {
    const initHome = () => {
        const appState = props.api.handleGetAppState();

        switch (appState) {
            case 201:                
                return state201();

            case 401:                
                return state401();
        
            default:
                return stateUnknown();
        }
    }
    
    const state201 = () => {
        const role = props.api.handleGetAppRole();

        const title = "Welcome " + role + " !"

        return (
            <div className="container_home">
                <h1>{title}</h1>
                <Navigation role={role}/>
            </div>
        )
    }

    const state401 = () => {
        return (
            <div className="container_home">
                <h1>Please login or register.</h1>         
                <Navigation/>
            </div>
        )
    }

    const stateUnknown = () => {
        return (
            <div className="container_home">
                <h1>Unknown state.</h1>
            </div>
        )
    }

    return (
        initHome()
    )
}

export default Home;
