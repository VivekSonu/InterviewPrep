//Note:
// Promise           -> One worker.Promise is representing future data.
// Promise.all       -> Wait for everyone, fail if anyone fails
// Promise.allSettled-> Wait for everyone, report success/failure of each
// Promise.race      -> Whoever finishes first wins

// all promise  are async in nature?
// Better statement
// ✅ Most async APIs return a Promise.
// ✅ A Promise is often used to represent async work.
// ❌ Not every Promise means real async work is happening.
// Promise.resolve(100);
// This Promise is already completed. No I/O, no timer, no network call.

let data;

function fetchData() {
  return new Promise((resolve, reject) => {
    setTimeout(() => {
      let data = { pCode: 1001, pData: "Orange" };
      resolve(data);
    }, 2000);
  });
}

fetchData()
  .then((data) => {
    console.log(data);
  })
  .catch((Error) => {
    console.log(Error);
  })
  .finally(() => {
    console.log("program executed");
  });

console.log("Sq process starts here");

function cSqrt(n) {
  return new Promise((resolve, reject) => {
    resolve(n * n);
  });
}

cSqrt(2)
  .then((res) => {
    console.log(res);
    return cSqrt(res);
  })
  .then((res1) => {
    console.log(res1);
  });
