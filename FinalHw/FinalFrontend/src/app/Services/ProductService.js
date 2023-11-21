import http from "../http-common";
class ProductService {

    //https://localhost:5050/api/products
    getAllProcudts(){
        return http.get("/api/products");
    }

    //http://localhost:8080/api/tutorials/id
    get(ProductID) 
    {
        return http.get(`/api/products${id}`);
    }
    /*
    create(data) {
        console.log(data);
        return http.post("/tutorials",data);
    }
    update(id,data) {
        console.log("güncellenecek tutorial id"+id);
        console.log("güncellenecek tutorial "+data);
        return http.put(`/tutorials/${id}`,data);
    }

    delete(id) {
        return http.delete(`/tutorials/${id}`);
    }

    findByTitle(title) {
        return http.get(`tutorials?title=${title}`);
    }
    */
}

export default new ProductService