import axios from "axios";

async function ControllerPost(api_url, data_obj) {    
    return await axios({
        method: 'post',
        url: api_url,
        data: data_obj
    })
}
  
export default ControllerPost;
