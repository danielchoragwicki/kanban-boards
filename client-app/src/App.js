import React, { Component } from 'react';
import Dashboard from './pages/Dashboard';
import Board from './pages/Board'
import { findById, addItem, updateList, removeItem } from './utils/helpers'
import { loadBoards, createBoard, saveBoard, destroyBoard } from './utils/service'

import { BrowserRouter, Switch, Redirect, Route } from "react-router-dom"; 
import './styles/styles.css';

class App extends Component {
  state = {
    boards: [],
    isLoading: true,
  }
  componentDidMount() {
    loadBoards()
      .then(boards => this.setState({boards, isLoading: false}))
  }
  // handleCreate = newBoard => {
  //   const updatedBoards = addItem(this.state.boards, newBoard)
  //   this.setState({boards: updatedBoards})
  //   saveBoards(updatedBoards)
  // }
  // handleRemove = id => {
  //   const updatedBoards = removeItem(this.state.boards, id)
  //   this.setState({boards: updatedBoards})
  //   saveBoards(updatedBoards)
  // }
  // updatedBoard = board => {
  //   const upadtedBoard = updateList(this.state.boards, board)
  //   this.setState({boards: upadtedBoard})
  //   saveBoards(upadtedBoard)
  // }

  handleCreate = newBoard => {
    const updatedBoards = addItem(this.state.boards, newBoard)
    this.setState({boards: updatedBoards})
    createBoard(newBoard)
      .then(() => console.log(`Board ${newBoard.name} added`))
  }
  handleRemove = id => {
    const updatedBoards = removeItem(this.state.boards, id)
    this.setState({boards: updatedBoards})
    destroyBoard(id)
      .then(() => console.log(`Board with ID ${id} removed`))
  }
  updatedBoard = board => {
    const upadtedBoard = updateList(this.state.boards, board)
    this.setState({boards: upadtedBoard})
    saveBoard(board)
      .then(() => console.log(`Board ${board.name} updated`))
  }

  render() {  
    return (
      <BrowserRouter basename={process.env.PUBLIC_URL}>
            <Switch>
                <Route exact path='/' render={props => (this.state.isLoading ? <div className="loader__wrapper"><div className="loader">
                  <div className="loader__item"></div>
                  <div className="loader__item"></div>
                  <div className="loader__item"></div>
                  <div className="loader__item"></div>
                </div></div> : <Dashboard 
                    handleCreate={this.handleCreate} 
                    boards={this.state.boards} 
                    {...props}/>)
                }/>
                <Route path="/board/:id" 
                render={props => {
                    const ifCorrectID = findById(parseInt(props.match.params.id), this.state.boards)
                    return (ifCorrectID 
                      ? <Board id={parseInt(props.match.params.id)} 
                          board={ifCorrectID} 
                          handleRemove={this.handleRemove} 
                          updatedBoard={this.updatedBoard} /> 
                      : <Redirect to='/' />)
                  }
                }/>
                <Redirect to='/'/>
            </Switch>
        </BrowserRouter>
    );
  } 
}

export default App;