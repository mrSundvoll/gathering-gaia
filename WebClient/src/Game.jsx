import React from 'react';

import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import { Button, Card, Typography, Body, Wrapper, Grid, TextField } from '@equinor/eds-core-react' ;

const { CardHeader } = Card

const Dice = {
  1: "\u2680",
  2: "\u2681",
  3: "\u2682",
  4: "\u2683",
  5: "\u2684",
  6: "\u2685",
}


class GameLog extends React.PureComponent {
  render() {
    return (
      <textarea value={this.props.log} readOnly="readonly" />
    )
  }
}


class Player extends React.PureComponent {
  render() {
    return (
      <Card variant={this.props.active === "true" ? "danger" : "default"}>
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
  constructor(props) {
    super(props)
    this.state = {
      amountDie: 1,
      selectedDie: 0
    }
  }

  render() {
    const buttons = []
    for (let i = 1; i <= 6; i++) {
      buttons.push(
        <Button onClick={() => this.selectDie(i)} disabled={this.state.selectedDie === i && "disabled"}>
          {Dice[i]}
        </Button>
      )
    }

    return (
      <>
        <div>{buttons}</div>
        <TextField
          type="number"
          label="Number of dice to bet"
          meta="dice"
          value={this.state.amountDie}
          onChange={e => this.selectNumber(e)}
        />
          <Button onClick={() => this.onBet()}>Bet</Button>
          <Button onClick={() => this.onCall()}>Call</Button>
        </>
    )
  }

  selectDie(which) {
    this.setState({
      selectedDie: which
    })
  }

  selectNumber(e) {
    const num = e.target.value;
    this.setState({
      amountDie: num
    })
  }

  onBet() {
    alert(`Bet ${this.state.amountDie} ${Dice[this.state.selectedDie]}`)
  }

  onCall() {
    alert(`Call ${this.state.amountDie} ${Dice[this.state.selectedDie]}`)
  }
}


class Game extends React.PureComponent {
  constructor(props) {
    super(props)

    this.state = {
      log: ""
    }
  }

  render() {
    return (
      <Container>
        <Row>
          <Col>
            <GameLog log={this.state.log}/>
          </Col>
          <Col>
            <PlayerList />
          </Col>
        </Row>
        <Row>
          <Col>
            <CurrentPlayer />
            <Button onClick={() => this.onClick()}/>
          </Col>
        </Row>
      </Container>
    )
  }

  onClick() {
    this.setState({
      log: this.state.log + "Foo\n"
    })
  }
}

export default Game;
