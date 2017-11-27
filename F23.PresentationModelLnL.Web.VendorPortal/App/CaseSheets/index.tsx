import 'react-hot-loader/patch';
import * as React from 'react';
import * as ReactDOM from 'react-dom';
import { AppContainer } from 'react-hot-loader';

import App from './App';

const render = (Component: React.StatelessComponent) => {
    ReactDOM.render(
        <AppContainer>
            <Component />
        </AppContainer>,
        document.getElementById('react-mount-point')
    );
}

render(App);

if (module.hot) {
    module.hot.accept('./App', () => {
        console.log('Reloading');
        const nextApp = require('./App').default;
        render(nextApp);
    });
}