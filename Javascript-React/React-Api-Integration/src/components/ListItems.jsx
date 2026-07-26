import { Item } from "./Item";

export const ListItems = ({ data, setData, updateData, setUpdateData }) => {
  return (
    <ul>
      {data.map((dataItems) => {
        const { id, body, title } = dataItems;
        //console.log(id);
        return (
          <Item
            key={id}
            id={id}
            body={body}
            title={title}
            data={dataItems}
            setData={setData}
            setUpdateData={setUpdateData}
          />
        );
      })}
    </ul>
  );
};
