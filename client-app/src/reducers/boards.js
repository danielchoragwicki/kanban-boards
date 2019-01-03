import { getBoards, createBoard, destroyBoard, updatedBoard } from '../utils/boardsServices';

export const BOARD_ADD = 'BOARD_ADD';
export const BOARD_REMOVE = 'TODO_REMOVE';
export const BOARDS_LOAD = 'BOARDS_LOAD';
export const CURRENT_UPDATE = 'CURRENT_UPDATE';

const initialState = {
  boards: [],
  currentBoard: {},
};


export const addBoard = board => ({type: BOARD_ADD, payload: board})
export const removeBoard = id => ({type: BOARD_REMOVE, payload: id})
export const loadBoards = boards => ({type: BOARDS_LOAD, payload: boards})
export const updateCurrent = obj => ({type: CURRENT_UPDATE, payload: obj});

export const saveBoard = name => {
    return(dispatch) => {
        // dispatch(showMessage('Saving Board'))
        createBoard(name)
            .then(res => dispatch(addBoard(res)))
    }
}

export const deleteBoard = id => {
    return(dispatch) => {
        // dispatch(showMessage('Removing Board'))
        destroyBoard(id)
            .then(() => dispatch(removeBoard(id)))
    }
}

export const fetchTodos = () => {
  return(dispatch) => {
      // dispatch(showMessage('Loading Board'))
      getBoards()
          .then(boards => dispatch(loadBoards(boards)))
  }
}

// export const updateBoard = id => {
//   return(dispatch, getState) => {
//       // dispatch(showMessage('Saving board update'))
//       const { boards } = getState().boards
//       const board = boards.find(t => t.id === id)
//       const updated = {...board, isComplete: !todo.isComplete}
//       updatedBoard(updated)
//           .then(res => dispatch(replaceTodo(res)))
//   }
// }

export default (state = initialState, action) => {
    switch(action.type) {
        case BOARD_ADD: 
            return {...state, boards: state.boards.concat(action.payload)}
        case BOARD_REMOVE:
            return {...state, boards: state.boards
                .filter(t => t.id !== action.payload)}
        case BOARDS_LOAD: 
            return {...state, boards: action.payload}
        case CURRENT_UPDATE: 
            return {...state, currentBoard: action.payload }
        default:
            return state
    }
}
