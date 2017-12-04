import { ProductDetails } from '../../Products';

export class CaseSheetItemPostModel {
    productId: number;
    quantity: number;
    
    static ToPostModel(pd: ProductDetails): CaseSheetItemPostModel {
        return {
            productId: pd.productId,
            quantity: pd.quantity
        };
    }
}

export class CaseSheetPostModel {
    locationId: number;
    caseSheetNumber: string;
    caseDate: string;
    products: Array<CaseSheetItemPostModel>;
}