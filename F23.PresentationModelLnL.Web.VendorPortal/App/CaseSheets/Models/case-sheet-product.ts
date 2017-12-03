export default class CaseSheetProduct {
    productId: number;
    productSku: string;
    description: string;
    quantity: number;
    unitPrice: number;
    get extPrice(): number {
        return this.quantity * this.unitPrice;
    }
}