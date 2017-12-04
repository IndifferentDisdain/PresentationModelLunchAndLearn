import * as React from 'react';
import { ProductDetails, ProductsService } from '../../Products';
import ProductComponent from './product.component';
import CreateStore from '../store';
import Select from 'react-select';

class Props {
    products: Array<ProductDetails>;
}

interface IState {
    searchTerm: string;
}

export default class ProductsComponent extends React.Component<Props, IState> {

    constructor(props) {
        super(props);
        this.state = {
            searchTerm: ''
        }
    }

    addProduct = (product: ProductDetails) => {
        CreateStore.addProduct(product);
    }

    getProducts = (input: string) => {
        return ProductsService.getProducts(input)
            .then(json => {
                return {
                    options: json
                }
            });
    }

    render() {
        const {
            products
        } = this.props;

        return (
            <table className="table table-striped">
                <thead>
                    <tr>
                        <th>Product SKU</th>
                        <th>Description</th>
                        <th className="text-right">Quantity</th>
                        <th className="text-right">Unit Price</th>
                        <th className="text-right">Ext. Price</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    {products.map(x => {
                        return (<ProductComponent key={x.productId || ''} product={x} />);
                    })}
                    <tr>
                        <td>
                            <Select.Async
                                labelKey='productSku'
                                valueKey='productId'
                                value={this.state.searchTerm}
                                loadOptions={this.getProducts}
                                onChange={this.addProduct}
                            />
                        </td>
                    </tr>
                </tbody>
                <tfoot>
                    <tr>
                        <td colSpan={4} className="text-right"><strong>Total: </strong></td>
                        <td className="text-right"><strong>{CreateStore.total}</strong></td>
                    </tr>
                </tfoot>
            </table>
        )
    }
}