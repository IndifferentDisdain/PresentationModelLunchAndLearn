import * as React from 'react';
import * as ReactDOM from 'react-dom';
import { CreateComponent } from './Components';

export function create() {
    ReactDOM.render(
        <CreateComponent/>,
        document.getElementById('react-mount-point')
    );
}