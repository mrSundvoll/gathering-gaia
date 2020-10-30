import React from 'react';
import { MemoryRouter, Switch, Route } from 'react-router-dom';

import Jumbotron from 'react-bootstrap/Jumbotron';
import Container from 'react-bootstrap/Container';

import Game from './Game';

import './App.css';

const App = () => (
    <MemoryRouter>
        <Container className="p-3">
            <Jumbotron>
                <Switch>
                    <Route path="/">
                        <Game />
                    </Route>
                </Switch>
            </Jumbotron>
        </Container>
    </MemoryRouter>
);

export default App;
