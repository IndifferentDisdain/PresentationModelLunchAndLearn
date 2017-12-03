import Store from 'rigby';
import { CaseSheetPostModel, CaseSheetItemPostModel } from './Models';
import {ProductDetails} from '../Products';

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

    addProduct() {
        this.state.items.push(new ProductDetails());
        this.emitChange();
    }

    setProduct(existingProduct: ProductDetails, update: ProductDetails) {
        this.state.items.splice(this.state.items.indexOf(existingProduct), 1);
        update.extPrice = update.quantity * update.unitPrice;
        this.state.items.push(update);
        this.emitChange();
    }

    get total(): number {
        const {
            items
        } = this.state;
        if(!items || !items.length)
            return 0;
        
        return items.reduce((a, b) => {
            return a + (b.extPrice || 0)
        }, 0);
    }
}

export default new CreateStore();