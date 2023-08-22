async function HelperGetResponseObj(response) {
    return await response
    .then((_response) => _response.data)
    .catch(function (error) {
        if (error.response) {
            switch (error.response?.status) {
                case 400:
                    const errorObj400 = {Data: error.response.data.errors.Data[0]};
                        return errorObj400;
                case 404:
                    const errorObj404 = {Data: error.response.data.data};
                        return errorObj404;
                default:
                    console.log(error.response.data);
                    console.log(error.response.status);
                    console.log(error.response.headers);
                    return;  
            }
        }
        else if (error.request) {
            console.log(error.request);
        }
        else {
            console.log('Error', error.message);
        }
    console.log(error.config);
})
}

export default HelperGetResponseObj;
