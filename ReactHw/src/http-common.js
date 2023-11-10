import axios from "axios"

export default axios.create({
    baseURL : "http://85.159.71.66:8080/api/",
    headers : {
        "Content-type" : "application/json"
    }
});