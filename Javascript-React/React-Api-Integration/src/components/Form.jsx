import { useEffect, useState } from "react";
import { postTodo, putTodo } from "../services/listapi";

export const Form = ({ data, setData, updateData, setUpdateData }) => {
  const [newItem, setNewItem] = useState({ title: "", body: "" });

  let isEmpty = Object.keys(updateData).length === 0;

  const handleInput = (e) => {
    const { name, value } = e.target;
    setNewItem((prev) => ({ ...prev, [name]: value }));
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    const val = e.nativeEvent.submitter.value;
    console.log(val);

    if (val === "Add") {
      const res = await postTodo(newItem);

      if (res.status === 201) {
        setData((prev) => [...prev, newItem]);
      }
    } else if (val === "Edit") {
      const res = await putTodo(updateData.id, newItem);

      if (res.status === 200 || res.status === 201) {
        setData((prev) =>
          prev.map((item) =>
            item.id === updateData.id ? { ...item, ...newItem } : item,
          ),
        );
        setUpdateData({});
      }
    }

    setNewItem({ title: "", body: "" });
  };

  useEffect(() => {
    setNewItem({
      title: updateData.title || "",
      body: updateData.body || "",
    });
  }, [updateData]);

  return (
    <>
      <form onSubmit={handleSubmit}>
        <input
          value={newItem.title}
          onChange={handleInput}
          name="title"
          type="text"
        />
        <input
          value={newItem.body}
          onChange={handleInput}
          name="body"
          type="text"
        />
        <button value={isEmpty ? "Add" : "Edit"}>
          {isEmpty ? "Add" : "Edit"}
        </button>
      </form>
    </>
  );
};
