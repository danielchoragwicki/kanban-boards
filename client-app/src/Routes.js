import React, { Component } from 'react';
import { Switch, Route, Redirect } from 'react-router-dom';
import Dashboard from './containers/Dashboard';
import Board from './containers/Board';

class Routes extends Component {
  render() {
    return (
        <Switch>
            <Route exact path='/' component={ Dashboard } />
            <Route exact path='/board' component={ Board } />
            <Redirect to='/'/>
        </Switch>
    );
  }
}

export default Routes;