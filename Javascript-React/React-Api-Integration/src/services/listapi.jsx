import axios from "axios";

const api = axios.create({
  baseURL: "https://jsonplaceholder.typicode.com",
  headers: {
    "Content-Type": "application/json",
  },
});

export const getTodos = () => {
  return api.get("/posts");
};

export const deleteTodo = (id) => {
  return api.delete(`/posts/${id}`);
};

export const postTodo = (post) => {
  return api.post("/posts", post);
};

export const putTodo = (Id, post) => {
  return api.put(`/posts/${Id}`, post);
};
