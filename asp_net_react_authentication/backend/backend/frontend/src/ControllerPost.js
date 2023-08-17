import axios from "axios";

async function ControllerPost(api_url, data_obj) {    
        return await axios({
            method: 'post',
            url: api_url,
            data: data_obj
        }).catch(function (error) {
            if (error.response) {
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
        console.log(error.config);
    })
  }
  
  export default ControllerPost;
