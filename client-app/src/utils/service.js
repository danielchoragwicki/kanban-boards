import { mapBoards, mapBoard, mapBoardToApi, mapListToApi, mapCardToApi } from './helpers'

const baseUrl = "http://localhost:56935/api"
 
export const loadBoards = () => {
    return fetch(`${baseUrl}/boards/`) 
        .then(res => res.json())
        .then(res => mapBoards(res))
}


export const createBoard = item => {
    const board = mapBoardToApi(item)
    return fetch(`${baseUrl}/boards/`, {
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
  return fetch(`${baseUrl}/boards/${item.id}`, {
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
  return fetch(`${baseUrl}/boards/${id}`, {
    method: 'DELETE',
    headers: {
      'Accept': 'application/json',
      'Content-Type': 'application/json'
    },
  })
}

export const createList = item => {
  const list = mapListToApi(item)
  return fetch(`${ baseUrl }/KanbanLists`, {
    method: 'POST',
    headers: {
      'Accept': 'application/json',
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(list)
  }).then(res => res.json())
  // .then(res => mapBoard(res))
}

export const saveList = item => {
  const list = mapListToApi(item)
    return fetch(`${baseUrl}/KanbanLists/${item.id}`, {
      method: 'PUT',
      headers: {
        'Accept': 'application/json',
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(list)
    }).then(res => res.json())
  //   .then(res => mapBoard(res))
  }
  
  export const destroylist = id => {
    return fetch(`${baseUrl}/KanbanLists/${id}`, {
      method: 'DELETE',
      headers: {
        'Accept': 'application/json',
        'Content-Type': 'application/json'
      },
    })
  }

  export const createCard = item => {
    const card = mapCardToApi(item)
    return fetch(`${ baseUrl }/Cards`, {
      method: 'POST',
      headers: {
        'Accept': 'application/json',
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(card)
    }).then(res => res.json())
    // .then(res => mapBoard(res))
  }
  
  export const saveCard = item => {
    const card = mapCardToApi(item)
      return fetch(`${baseUrl}/Cards/${item.id}`, {
        method: 'PUT',
        headers: {
          'Accept': 'application/json',
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(card)
      }).then(res => res.json())
    //   .then(res => mapBoard(res))
    }
    
    export const destroycard = id => {
      return fetch(`${baseUrl}/Cards/${id}`, {
        method: 'DELETE',
        headers: {
          'Accept': 'application/json',
          'Content-Type': 'application/json'
        },
      })
    }