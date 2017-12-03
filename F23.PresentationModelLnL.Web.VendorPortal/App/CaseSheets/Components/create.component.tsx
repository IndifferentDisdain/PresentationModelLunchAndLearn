import * as React from 'react';
import { StoreCallback } from 'rigby';
import CreateStore, { ICreateStoreState } from '../create.store';
import { CaseSheetPostModel } from '../Models';
import Select from 'react-select';
import {IdAndName} from '../../Core/Models';
import ProductsComponent from './products.component'

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

    handleInputChange: any = (propName: keyof (CaseSheetPostModel), e: any) => {
        CreateStore.handlePropChange(propName, e.currentTarget.value);
    }

    handleSelectChange: any = (propName: keyof(CaseSheetPostModel), valueObj: IdAndName) => {
        CreateStore.handlePropChange(propName, valueObj.id);
    }

    getLocations = (input: string) => {
        return fetch(`/api/locations?searchTerm=${input}`)
            .then(response => response.json())
            .then(json => {
                return { options: json };
            });
    }

    render() {
        const {
            caseSheet,
            items
        } = this.state;

        return (
            <div>
                <div className='form-group'>
                    <label htmlFor='caseSheetNumber'>Case Sheet Number</label>
                    <input
                        type='text'
                        className='form-control'
                        required
                        value={caseSheet.caseSheetNumber || ''}
                        id='caseSheetNumber'
                        name='caseSheetNumber'
                        onChange={this.handleInputChange.bind(this, 'caseSheetNumber')}
                    />
                </div>
                <div className='form-group'>
                    <label htmlFor='locationId'>Location</label>
                    <Select.Async
                        id='locationId'
                        name='locationId'
                        labelKey='name'
                        valueKey='id'
                        value={caseSheet.locationId || ''}
                        loadOptions={this.getLocations}
                        onChange={this.handleSelectChange.bind(this, 'locationId')}
                    />
                </div>
                <div className='form-group'>
                    <label htmlFor='caseDate'>Case Date</label>
                    <input
                        type='date'
                        className='form-control'
                        required
                        value={caseSheet.caseDate || ''}
                        id='caseDate'
                        name='caseDate'
                        onChange={this.handleInputChange.bind(this, 'caseDate')}
                    />
                </div>
                <hr />  
                <h2>Products</h2>
                <ProductsComponent products={items} />
                <button type="button" className="btn btn-primary" disabled={!CreateStore.canSave}>
                    <span className="glyphicon glyphicon-disk"></span> Save
                </button>
            </div>
        );
    }
}