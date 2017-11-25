import Store from 'rigby';

export interface ICreateStoreState {
    firstName: string;
}

export class CreateStore extends Store<ICreateStoreState> {
    constructor() {
        super('CreateCaseSheet');
        this.state = {
            firstName: ''
        };
    }

    initialize(props: any) {
        console.log('initialize called.');
    }

    handlePropChange(propName: keyof (ICreateStoreState), value: string) {
        this.state[propName] = value;
        console.log(this.state);
        this.emitChange();
    }
}

export default new CreateStore();