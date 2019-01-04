import { mapBoards, mapBoard, mapBoardToApi } from './helpers'

const baseUrl = "http://localhost:56935/api/boards"
 
export const loadBoards = () => {
    return fetch(baseUrl) 
        .then(res => res.json())
        .then(res => mapBoards(res))
}

// export const saveBoards = boards => {
//     localStorage.setItem('boards', JSON.stringify(boards))
// }

// export const deleteBoards = () => {
//   localStorage.clear()
// }


export const createBoard = item => {
    const board = mapBoardToApi(item)
    return fetch(baseUrl, {
      method: 'POST',
      headers: {
        'Accept': 'application/json',
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(board)
    }).then(res => res.json())
    // .then(res => mapBoard(res))
  }

export const saveBoard = item => {
const board = mapBoardToApi(item)
  return fetch(`${baseUrl}/${item.id}`, {
    method: 'PUT',
    headers: {
      'Accept': 'application/json',
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(board)
  }).then(res => res.json())
//   .then(res => mapBoard(res))
}

export const destroyBoard = id => {
  return fetch(`${baseUrl}/${id}`, {
    method: 'DELETE',
    headers: {
      'Accept': 'application/json',
      'Content-Type': 'application/json'
    },
  })
}