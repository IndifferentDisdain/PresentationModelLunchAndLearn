import * as React from 'react';
import { ProductDetails } from '../../Products';
import ProductComponent from './product.component';
import CreateStore from '../create.store';

class Props {
    products: Array<ProductDetails>;
}

interface IState {

}

export default class ProductsComponent extends React.Component<Props, IState> {

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