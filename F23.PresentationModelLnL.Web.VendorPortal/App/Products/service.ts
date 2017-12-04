export class ProductsService {
    getProducts(searchTerm: string) {
        return fetch(`/api/products?searchTerm=${searchTerm}`)
            .then(response => response.json());
    }
}

export default new ProductsService();