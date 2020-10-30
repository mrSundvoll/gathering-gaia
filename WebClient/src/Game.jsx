import React from 'react';

import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import { Button, Card, Typography, Body, Wrapper, Grid } from '@equinor/eds-core-react' ;

const { CardHeader } = Card


class GameLog extends React.PureComponent {
    render() {
        return (<Button>Log</Button>)
    }
}


class Player extends React.PureComponent {
    render() {
        return (
            <Card variant={this.props.active === "true" && "danger"}>
              <CardHeader>
                <strong>{this.props.name}</strong>
                <span>&#9856; {this.props.dice}</span>
              </CardHeader>
            </Card>
        )
    }
}


class PlayerList extends React.PureComponent {
    render() {
        return (
            <>
              <Player name="Foo" dice="5" />
              <Player name="Bar" dice="8" active="true" />
              <Player name="Baz" dice="0" />
            </>
        )
    }
}


class CurrentPlayer extends React.PureComponent {
    render() {
        return (<React.Fragment />)
    }
}


class Game extends React.PureComponent {
    render() {
        return (
            <Container>
              <Row>
                <Col>
                  <GameLog />
                </Col>
                <Col>
                  <PlayerList />
                </Col>
              </Row>
              <Row>
                <Col><CurrentPlayer /></Col>
              </Row>
            </Container>
        )
    }
}

export default Game;
