import Store from 'rigby';
import { CaseSheetPostModel, CaseSheetItemPostModel } from './Models';
import { ProductDetails } from '../Products';

export interface ICreateStoreState {
    caseSheet: CaseSheetPostModel
    items: Array<ProductDetails>;
}

export class CreateStore extends Store<ICreateStoreState> {
    constructor() {
        super('CreateCaseSheet');
        this.state = {
            caseSheet: new CaseSheetPostModel(),
            items: new Array<ProductDetails>()
        };
    }

    initialize(props: any) {
        this.state.caseSheet.caseDate = (new Date()).toISOString().split('T')[0];
        this.emitChange();
    }

    handlePropChange(propName: keyof (CaseSheetPostModel), value: string | number) {
        this.state.caseSheet[propName] = value;
        this.emitChange();
    }

    handleQtyChanged(product: ProductDetails, qty: number) {
        product.quantity = qty;
        product.extPrice = product.quantity * product.unitPrice;
        this.emitChange();
    }

    removeProduct(product: ProductDetails) {
        const idx = this.state.items.indexOf(product);
        this.state.items.splice(idx, 1);
        this.emitChange();
    }

    addProduct(product: ProductDetails) {
        product.extPrice = product.quantity * product.unitPrice;
        this.state.items.push(product);
        this.emitChange();
    }

    save() {
        this.state.caseSheet.products = this.state.items.map(x => CaseSheetItemPostModel.ToPostModel(x));
        
        // const formData = new FormData();
        // formData.append('model', JSON.stringify(this.state.caseSheet));

        // headers: {
        //     'Content-Type': 'application/json',
        //     'Accept': 'application/json'
        // },
        fetch('/CaseSheets/Create', {
            method: 'POST',
            headers: new Headers({
                'Content-Type': 'application/json',
                'Accept': 'application/json'
            }),
            // body: {model: JSON.stringify(this.state.caseSheet)}
            body: JSON.stringify(this.state.caseSheet)
        })
        .then(response => {
            if(response.ok)
                window.location.href = '/CaseSheets';
        });
    }

    get total(): number {
        const {
            items
        } = this.state;
        if (!items || !items.length)
            return 0;

        return items.reduce((a, b) => {
            return a + (b.extPrice || 0)
        }, 0);
    }

    get canSave(): boolean {
        const {
            caseSheet,
            items
        } = this.state;

        if (!items || !items.length)
            return false;

        if (!caseSheet)
            return false;
        if (!caseSheet.locationId)
            return false;
        if (!caseSheet.caseSheetNumber)
            return false;

        return true;
    }
}

export default new CreateStore();