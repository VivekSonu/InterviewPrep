function fetchData(dd) {
  setTimeout(() => {
    let data = { pCode: 1001, pNmae: "Orange" };
    dd(data);
  }, 2000);
}

function displayData(data) {
  console.log(data);
  console.log("program ends");
}

console.log("start here");
fetchData(displayData);
// displayData();
