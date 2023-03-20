function saveTodoItems(itemsAsJson) {
    localStorage.setItem("todoItems", itemsAsJson);
}

function getTodoItems() {
    return localStorage.getItem("todoItems");
}