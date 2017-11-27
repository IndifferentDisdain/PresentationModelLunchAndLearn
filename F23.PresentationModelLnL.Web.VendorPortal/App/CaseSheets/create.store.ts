import Store from 'rigby';
import { CaseSheetPostModel, CaseSheetItemPostModel } from './Models';

export interface ICreateStoreState {
    caseSheet: CaseSheetPostModel
}

export class CreateStore extends Store<ICreateStoreState> {
    constructor() {
        super('CreateCaseSheet');
        this.state = {
            caseSheet: new CaseSheetPostModel()
        };
    }

    initialize(props: any) {
        console.log('initialize called.');
    }

    handlePropChange(propName: keyof (CaseSheetPostModel), value: string) {
        this.state.caseSheet[propName] = value;
        this.emitChange();
    }
}

export default new CreateStore();