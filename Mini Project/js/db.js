const DB_NAME = "upgradEMSDB";
const DB_VERSION = 1;
const STORE_NAME = "events";

function openDatabase() {
  return new Promise((resolve, reject) => {
    const request = indexedDB.open(DB_NAME, DB_VERSION);

    request.onerror = function () {
      reject("Database failed to open.");
    };

    request.onsuccess = function () {
      resolve(request.result);
    };

    request.onupgradeneeded = function (event) {
      const db = event.target.result;

      if (!db.objectStoreNames.contains(STORE_NAME)) {
        const store = db.createObjectStore(STORE_NAME, { keyPath: "id" });
        store.createIndex("name", "name", { unique: false });
        store.createIndex("category", "category", { unique: false });
      }
    };
  });
}
//Adding new event to DB
async function addEventToDB(eventData) {
  const db = await openDatabase();

  return new Promise((resolve, reject) => {
    const transaction = db.transaction(STORE_NAME, "readwrite");
    const store = transaction.objectStore(STORE_NAME);
    const request = store.add(eventData);

    request.onsuccess = function () {
      resolve(true);
    };

    request.onerror = function () {
      reject("Event ID already exists.");
    };
  });
}

//Getting all the events
async function getAllEventsFromDB() {
  const db = await openDatabase();

  return new Promise((resolve, reject) => {
    const transaction = db.transaction(STORE_NAME, "readonly");
    const store = transaction.objectStore(STORE_NAME);
    const request = store.getAll();

    request.onsuccess = function () {
      resolve(request.result);
    };

    request.onerror = function () {
      reject("Unable to fetch events.");
    };
  });
}

//Getting event BY ID
async function getEventByIdFromDB(id) {
  const db = await openDatabase();

  return new Promise((resolve, reject) => {
    const transaction = db.transaction(STORE_NAME, "readonly");
    const store = transaction.objectStore(STORE_NAME);
    const request = store.get(Number(id));

    request.onsuccess = function () {
      resolve(request.result);
    };

    request.onerror = function () {
      reject("Unable to fetch event.");
    };
  });
}

async function deleteEventFromDB(id) {
  const db = await openDatabase();

  return new Promise((resolve, reject) => {
    const transaction = db.transaction(STORE_NAME, "readwrite");
    const store = transaction.objectStore(STORE_NAME);
    const request = store.delete(Number(id));

    request.onsuccess = function () {
      resolve(true);
    };

    request.onerror = function () {
      reject("Unable to delete event.");
    };
  });
}