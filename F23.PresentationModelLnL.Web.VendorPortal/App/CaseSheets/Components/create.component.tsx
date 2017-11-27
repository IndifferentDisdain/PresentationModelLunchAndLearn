import * as React from 'react';
import { StoreCallback } from 'rigby';
import CreateStore, { ICreateStoreState } from '../create.store';
import {CaseSheetPostModel} from '../Models';

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

    handleFieldChange: any = (propName: keyof(CaseSheetPostModel), e: any) => {
        CreateStore.handlePropChange(propName, e.currentTarget.value);
    }

    render() {
        const {
            caseSheet
        } = this.state;

        return (
            <div className='form-group'>
                <label htmlFor='caseSheetNumber'>Case Sheet Number</label>
                <input
                    type='text'
                    className='form-control'
                    required
                    value={caseSheet.caseSheetNumber || ''}
                    id='caseSheetNumber'
                    name='caseSheetNumber'
                    onChange={this.handleFieldChange.bind(this, 'caseSheetNumber')}
                />
            </div>
        );
    }
}