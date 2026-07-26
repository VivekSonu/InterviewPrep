import { useEffect, useState } from "react";
import "./App.css";
import { getTodos } from "./services/listapi";
import { ListItems } from "./components/ListItems";
import { Form } from "./components/Form";

function App() {
  const [data, setData] = useState([]);
  const [updateData, setUpdateData] = useState([]);

  const getTodoData = async () => {
    const res = await getTodos();
    //console.log(res.data);
    setData(res.data);
  };

  useEffect(() => {
    getTodoData();
  }, []);

  return (
    <>
      <section>
        <Form
          data={data}
          setData={setData}
          updateData={updateData}
          setUpdateData={setUpdateData}
        />
      </section>
      <section>
        <ListItems
          data={data}
          setData={setData}
          updateData={updateData}
          setUpdateData={setUpdateData}
        />
      </section>
    </>
  );
}

export default App;
