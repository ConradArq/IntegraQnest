import React from 'react';
import ReactDOM from 'react-dom/client';
import DemoWidget from './components/DemoWidget';
const container = document.getElementById('react-root');
if (container) {
    const root = ReactDOM.createRoot(container);
    root.render(React.createElement(DemoWidget, null));
}
