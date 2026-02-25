console.log(" -> CALLBACK VERSION\n");

let tasksCallback = [];

const addTaskCallback = (task, callback) => {
  setTimeout(() => {
    tasksCallback.push(task);
    callback(`Task "${task}" added`);
  }, 500);
};

const listTasksCallback = (callback) => {
  setTimeout(() => {
    callback(`Tasks: ${tasksCallback.join(", ")}`);
  }, 500);
};

// Run callback demo
addTaskCallback("Learn JS", (msg) => {
  console.log(msg);
  listTasksCallback((list) => {
    console.log(list);

  // Promise
    console.log("\n -> PROMISE VERSION\n");

    let tasksPromise = [];

    const addTaskPromise = (task) =>
      new Promise((resolve) => {
        setTimeout(() => {
          tasksPromise.push(task);
          resolve(`Task "${task}" added`);
        }, 500);
      });

    const listTasksPromise = () =>
      new Promise((resolve) => {
        setTimeout(() => {
          resolve(`Tasks: ${tasksPromise.join(", ")}`);
        }, 500);
      });

    addTaskPromise("Practice ES6")
      .then(console.log)
      .then(() => addTaskPromise("Build App"))
      .then(console.log)
      .then(listTasksPromise)
      .then(console.log)
      .then(() => {

        // Async and Await
        console.log("\n -> ASYNC/AWAIT VERSION\n");

        let tasksAsync = [];

        const addTask = async (task) =>
          new Promise((resolve) => {
            setTimeout(() => {
              tasksAsync.push(task);
              resolve(`Task "${task}" added`);
            }, 500);
          });

        const deleteTask = async (task) =>
          new Promise((resolve) => {
            setTimeout(() => {
              tasksAsync = tasksAsync.filter((t) => t !== task);
              resolve(`Task "${task}" deleted`);
            }, 500);
          });

        const listTasks = async () =>
          new Promise((resolve) => {
            setTimeout(() => {
              resolve(`Tasks: ${tasksAsync.join(", ")}`);
            }, 500);
          });

        const runAsyncDemo = async () => {
          console.log(await addTask("Read Docs"));
          console.log(await addTask("Deploy App"));
          console.log(await listTasks());
          console.log(await deleteTask("Read Docs"));
          console.log(await listTasks());
        };

        runAsyncDemo();
      });
  });
});