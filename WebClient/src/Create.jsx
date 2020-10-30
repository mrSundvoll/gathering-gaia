import React from 'react';

import { useHistory } from 'react-router-dom';
import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import { Button, Card, Typography, Body, Wrapper, Grid, TextField } from '@equinor/eds-core-react' ;

const baseurl = "https://server-gathering-gaia-prod.playground.radix.equinor.com"

function createGame(name) {
    return fetch(`${baseurl}/api/Games`, {
        method: "POST",
        mode: 'cors',
        headers: {
            'Content-Type': 'application/json;charset=utf-8'
        },
        body: JSON.stringify({gameName: name})
    }).catch(console.log)
      .then(r => r.json())
}

window.createGame = createGame;

function CreateGameButton(props) {
  const history = useHistory();

  function handleClick() {
      createGame(props.name)
  }

  return (
    <button type="button" onClick={handleClick}>
      Create game
    </button>
  );
}

class Create extends React.PureComponent {
    constructor(props) {
        super(props)
        this.state = {
            name: ""
        }
    }

    render() {
        return (
            <>
            <TextField value={this.state.name} onChange={e => this.onChangeName(e)}/>
            <CreateGameButton name={this.state.name}/>
            </>
        )
    }

    onChangeName(e) {
        this.setState({
            name: e.target.value
        })
    }
}

export default Create;
