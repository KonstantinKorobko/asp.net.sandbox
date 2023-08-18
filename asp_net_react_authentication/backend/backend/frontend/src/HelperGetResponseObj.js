async function HelperGetResponseObj(response) {
    return await response
    .then((_response) => _response.data)
    .catch(function (error) {
        if (error.response) {
            switch (error.response?.status) {
                case 400:
                    /*if (error.response.data.errors.Password[0].length > 0) {
                        const errorObj = {Password: error.response.data.errors.Password[0]};
                        return errorObj;
                    }
                    if (error.response.data.errors.UserName !== null) {
                        const errorObj = {userName: error.response.data.errors.UserName[0]};
                        return errorObj;
                    }*/
                    //break;            
                //default:
                    //break;
            }
            console.log(error.response.data);
            console.log(error.response.status);
            console.log(error.response.headers);         
        }
        else if (error.request) {
            console.log(error.request);
        }
        else {
            console.log('Error', error.message);
        }
    //console.log(error.config);
})
}

export default HelperGetResponseObj;
