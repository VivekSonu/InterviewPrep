const sqrt = (n) => {
  return new Promise((resolve, reject) => {
    resolve(n * n);
  });
};

// let a = await sqrt(2);
// console.log(a);

(async function () {
  let res = await sqrt(4);
  console.log(res);
})();
