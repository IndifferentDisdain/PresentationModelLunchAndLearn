import * as React from 'react';
import { ProductDetails } from '../../Products';
import CreateStore from '../create.store';

class Props {
    product: ProductDetails;
}

interface IState {

}

export default class ProductComponent extends React.Component<Props, IState> {

    handleQtyChanged = (e: any) => {
        CreateStore.handleQtyChanged(this.props.product, parseInt(e.currentTarget.value));
    }

    handleRemoveProduct = () => {
        CreateStore.removeProduct(this.props.product);
    }

    render() {
        const {
            product
        } = this.props;

        return (
            <tr>
                <td>{product.productSku}</td>
                <td>{product.description}</td>
                <td>
                    <input
                        type="number"
                        className="form-control text-right"
                        value={product.quantity}
                        onChange={this.handleQtyChanged}
                    />
                </td>
                <td className="text-right">{product.unitPrice}</td>
                <td className="text-right">{product.extPrice}</td>
                <td>
                    <button type="button" className="btn btn-danger" onClick={this.handleRemoveProduct}>
                        <span className="glyphicon glyphicon-trash" />
                    </button>
                </td>
            </tr>
        );

    }
}