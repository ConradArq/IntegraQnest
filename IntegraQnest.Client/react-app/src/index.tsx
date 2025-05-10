import React from 'react';
import ReactDOM from 'react-dom/client';
import ProfilingWidget from './components/ProfilingWidget';

const container = document.getElementById('react-widget-root');
if (container) {
    const root = ReactDOM.createRoot(container);
    root.render(<ProfilingWidget />);
}