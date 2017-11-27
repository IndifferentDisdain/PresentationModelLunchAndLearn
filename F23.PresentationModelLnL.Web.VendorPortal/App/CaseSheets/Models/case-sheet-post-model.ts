export class CaseSheetItemPostModel {
    productId: number;
    quantity: number;
}

export class CaseSheetPostModel {
    locationId: number;
    caseSheetNumber: string;
    caseDate: string;
    products: Array<CaseSheetItemPostModel>;
}