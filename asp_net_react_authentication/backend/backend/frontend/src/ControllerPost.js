import axios from "axios";

async function ControllerPost(request_data) {
    const result = await axios({
        method: request_data.method,
        url: request_data.url,
        data: request_data.data
    })
    console.log(result);
    return result;
}
  
export default ControllerPost;
