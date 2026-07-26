import { deleteTodo } from "../services/listapi";
export const Item = ({ id, title, body, setData, data, setUpdateData }) => {
  async function handleDelete() {
    try {
      console.log(id);
      await deleteTodo(id);
      setData((prev) => prev.filter((item) => item.id != id));
    } catch (error) {
      console.log(error);
    }
  }

  function handleUpdate() {
    setUpdateData(data);
  }

  return (
    <li key={id}>
      <h5>{id}</h5>
      <h4>{title}</h4>
      <p>{body}</p>
      <button onClick={handleUpdate}>Edit</button>
      <button onClick={handleDelete}>Delete</button>
    </li>
  );
};
