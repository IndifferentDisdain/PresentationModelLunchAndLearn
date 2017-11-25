import * as React from 'react';
import { StoreCallback } from 'rigby';
import CreateStore, { ICreateStoreState } from '../create.store';

export default class CreateComponent extends React.Component<{}, ICreateStoreState> {

    onStoreChangeCallbackId: number;
    onStoreChangeHandler: StoreCallback;

    constructor(props: null) {
        super(props);
        this.state = CreateStore.getState();
        this.onStoreChangeHandler = this.onUpdate.bind(this);
    }

    componentDidMount() {
        this.onStoreChangeCallbackId = CreateStore.listen(this.onStoreChangeHandler);
        CreateStore.initialize(this.props);
    }

    componentWillUnmount() {
        CreateStore.mute(this.onStoreChangeCallbackId);
    }

    onUpdate(state: ICreateStoreState) {
        this.setState(state);
    }

    handleFieldChange: any = (propName: keyof(ICreateStoreState), e: any) => {
        CreateStore.handlePropChange(propName, e.currentTarget.value);
    }

    render() {
        const {
            firstName
        } = this.state;

        return (
            <div className='form-group'>
                <label htmlFor='firstName'>First Name</label>
                <input
                    type='text'
                    className='form-control'
                    required
                    value={firstName}
                    name='firstName'
                    onChange={this.handleFieldChange.bind(this, 'firstName')}
                />
            </div>
        );
    }
}