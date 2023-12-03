import http from "../http-common";
class ProductService {

    //https://localhost:5050/api/products
    getAllProcudts() {
        return http.get("/api/products");
    }

    //http://localhost:8080/api/tutorials/id
    get(ProductID) {
        return http.get(`/api/products${id}`);
    }

}

export default new ProductService