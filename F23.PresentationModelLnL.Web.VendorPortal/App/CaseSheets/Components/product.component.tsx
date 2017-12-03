import * as React from 'react';
import { ProductDetails } from '../../Products';
import Select from 'react-select';
import CreateStore from '../create.store';

class Props {
    product: ProductDetails;
}

interface IState {
    searchTerm: string;
}

export default class ProductComponent extends React.Component<Props, IState> {
    constructor(props) {
        super(props);
        this.state = {
            searchTerm: ''
        }
    }
    getProducts = (input: string) => {
        // if (!!input || input.length < 2)
        //     return;
        return fetch(`/api/products?searchTerm=${input}`)
            .then(response => response.json())
            .then(json => {
                return {
                    options: json
                }
            });
    }

    handleProductIdChanged = (product: ProductDetails) => {
        CreateStore.setProduct(this.props.product, product);
    }

    render() {
        const {
            product
        } = this.props;
        
        if (product.productId) {
            return (
                <tr>
                    <td>{product.productSku}</td>
                    <td>{product.description}</td>
                    <td className="text-right">{product.quantity}</td>
                    <td className="text-right">{product.unitPrice}</td>
                    <td className="text-right">{product.extPrice}</td>
                </tr>
            );
        } else {
            return (
                <tr>
                    <td>
                        <Select.Async
                            labelKey='productSku'
                            valueKey='productId'
                            value={this.state.searchTerm}
                            loadOptions={this.getProducts}
                            onChange={this.handleProductIdChanged}
                        />
                    </td>
                </tr>
            );
        }
    }
}