function HelperGetResponseObj(response) {
    return response.then((_response) => {return _response.data});
}

export default HelperGetResponseObj;