import React from 'react';
import { BrowserRouter as Router, Switch, Route } from 'react-router-dom';

import Jumbotron from 'react-bootstrap/Jumbotron';
import Container from 'react-bootstrap/Container';

import Create from './Create';
import Game from './Game';

import './App.css';

const App = () => (
    <Router>
        <Container className="p-3">
            <Jumbotron>
                <Switch>
                    <Route exact path="/create">
                        <Create />
                    </Route>
                    <Route exact path="/">
                        <Game />
                    </Route>
                </Switch>
            </Jumbotron>
        </Container>
    </Router>
);

export default App;
