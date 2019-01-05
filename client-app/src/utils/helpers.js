// export const generateId = () => Math.random().toString(36).substr(2, 16)

export const generateId = () => {
  const a = new Date().valueOf();
  const str_a = a.toString();
  const result = Number(str_a.slice(0, 9));
  return result
}

export const findById = (id, list) => list.find(item => item.id === id)

export const addItem = (list, item) => [...list, item]

export const updateList = (list, updated) => {
  const updatedItem = list.findIndex(item => item.id === updated.id)
  return [
    ...list.slice(0, updatedItem),
    updated,
    ...list.slice(updatedItem+1)
  ]
}

export const removeItem = (list, id) => {
  const removedIndex = list.findIndex(item => item.id === id)
  return [
    ...list.slice(0, removedIndex),
    ...list.slice(removedIndex+1)
  ]
}

export const truncate = (elem, limit, after) => {
  if (!elem || !limit) return
  let content = elem.trim()
  if (content.length > limit) {
    content = content.split('').slice(0, limit)
    content = content.join('') + (after ? after : '')
  }
  return content
}

export const reorder = (list, startIndex, endIndex) => {
  const result = Array.from(list)
  const [removed] = result.splice(startIndex, 1)
  result.splice(endIndex, 0, removed)

  return result
}

export const move = (source, destination, droppableSource, droppableDestination) => {
  const sourceClone = Array.from(source)
  const destClone = Array.from(destination)
  const [removed] = sourceClone.splice(droppableSource.index, 1)

  destClone.splice(droppableDestination.index, 0, removed)

  const result = {}
  result[droppableSource.droppableId] = sourceClone
  result[droppableDestination.droppableId] = destClone

  return result
};


export const mapBoards = boards => {
  let mapBoards = boards.map(board => {
    const mapBoardItem = {
      id: board.Id,
      name: board.Name,
      theme: board.Theme,
      lists: board.KanbanLists.map(list => {
        const mapListItem = {
          id: list.Id,
          name: list.Name,
          boardId: board.Id,
          items: list.Cards.map(card => {
            const mapCard = {
              id: card.Id,
              name: card.Name,
              KanbanListId: card.KanbanListId,
              desc: card.Description,
              startDate: card.StartDate,
              endDate: card.EndDate,
            }
            return mapCard
          }),
        }
        return mapListItem
      }),
    }
    return mapBoardItem
  })
  return mapBoards
}

export const mapBoard = board => {
  const mapBoardItem = {
    id: board.Id,
    name: board.Name,
    theme: board.Theme,
    lists: board.KanbanLists.map(list => {
      const mapListItem = {
        id: list.Id,
        name: list.Name,
        boardId: board.Id,
        items: list.Cards.map(card => {
          const mapCard = {
            id: card.Id,
            name: card.Name,
            KanbanListId: card.KanbanListId,
            desc: card.Description,
            startDate: card.StartDate,
            endDate: card.EndDate,
          }
          return mapCard
        }),
      }
      return mapListItem
    }),
  }
  return mapBoardItem
}


// export const mapBoardsToApi = boards => {
//   let mapBoardsToApi = boards.map(board => {
//     const mapBoardItem = {
//       Id: board.id,
//       Name: board.name,
//       Theme: board.theme,
//       KanbanLists: board.lists.map(list => {
//         const mapListItem = {
//           Id: list.id,
//           Name: list.name,
//           boardId: list.boardId,
//           Cards: list.items.map(card => {
//             const mapCard = {
//               Id: card.id,
//               Name: card.name,
//               Description: card.desc,
//               StartDate: card.startDate,
//               EndDate: card.endDate,
//             }
//             return mapCard
//           }),
//         }
//         return mapListItem
//       }),
//     }
//     return mapBoardItem
//   })
//   return mapBoardsToApi
// }

export const mapBoardToApi = board => {
  const mapBoardItem = {
    Id: board.id,
    Name: board.name,
    Theme: board.theme,
    KanbanLists: board.lists.map(list => {
      const mapListItem = {
        Id: list.id,
        Name: list.name,
        BoardId: list.boardId,
        Cards: list.items.map(card => {
          const mapCard = {
            Id: card.id,
            Name: card.name,
            KanbanListId: card.KanbanListId,
            Description: card.desc,
            StartDate: card.startDate,
            EndDate: card.endDate,
          }
          return mapCard
        }),
      }
      return mapListItem
    }),
  }
  return mapBoardItem
}
  
export const mapListToApi = list => {
  const mapListItem = {
    Id: list.id,
    Name: list.name,
    BoardId: list.boardId,
    Cards: list.items.map(card => {
      const mapCard = {
        Id: card.id,
        Name: card.name,
        KanbanListId: card.KanbanListId,
        Description: card.desc,
        StartDate: card.startDate,
        EndDate: card.endDate,
      }
      return mapCard
    }),
  }
  return mapListItem
}

export const mapCardToApi = card => {
    const mapCard = {
      Id: card.id,
      Name: card.name,
      KanbanListId: card.KanbanListId,
      Description: card.desc,
      StartDate: card.startDate,
      EndDate: card.endDate,
    }
    console.log(mapCard)
    return mapCard
}