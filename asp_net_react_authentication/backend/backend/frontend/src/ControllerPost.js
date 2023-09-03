import axios from "axios";

async function ControllerPost(request_data) {
    const result = await axios({
        headers: {
            Authorization: `Bearer ${request_data.accessJWT}`
           },
        method: request_data.method,
        url: request_data.url,
        data: request_data.data
    })
    return result;
}
  
export default ControllerPost;
