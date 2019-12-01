import React from 'react';
import Layout from './components/layout';
import { BrowserRouter as Router } from 'react-router-dom';
import BaseRouter from './routes';

function App() {
    return (
        <Router>
            <Layout>
                <BaseRouter />
            </Layout>
        </Router>
    )
}

export default App;