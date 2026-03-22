async function renderEvents(filteredEvents = null) {
  const container = document.getElementById("eventsContainer");
  if (!container) return;

  const events = filteredEvents || await getAllEventsFromDB();
  container.innerHTML = "";

  if (events.length === 0) {
    container.innerHTML = `<p class="text-center">No events found.</p>`;
    return;
  }

  events.forEach((event) => {
    const col = document.createElement("div");
    col.className = "col-lg-4 col-md-6";

    col.innerHTML = `
      <div class="card shadow-sm h-100 event-card">
        <div class="card-body">
          <h4 class="card-title fw-bold">${event.name}</h4>
          <p class="mb-2"><strong>ID:</strong> ${event.id}</p>
          <p class="mb-2"><strong>Category:</strong> ${event.category}</p>
          <p class="mb-2"><strong>Date:</strong> ${event.date}</p>
          <p class="mb-3"><strong>Time:</strong> ${event.time}</p>
          <p class="mb-3">
            <a href="${event.url}" target="_blank" class="text-decoration-none">Join Event</a>
          </p>
          <button class="btn btn-danger delete-btn" data-id="${event.id}">Delete</button>
        </div>
      </div>
    `;

    container.appendChild(col);
  });

  attachDeleteHandlers();
}

function setupAddEventForm() {
  const form = document.getElementById("addEventForm");

  if (!form) return;

  form.addEventListener("submit", async function (event) {
    event.preventDefault();

    const newEvent = {
      id: Number(document.getElementById("eventId").value),
      name: document.getElementById("eventName").value.trim(),
      category: document.getElementById("eventCategory").value,
      date: document.getElementById("eventDate").value,
      time: document.getElementById("eventTime").value,
      url: document.getElementById("eventUrl").value.trim()
    };

    if (
      !newEvent.id ||
      !newEvent.name ||
      !newEvent.category ||
      !newEvent.date ||
      !newEvent.time ||
      !newEvent.url
    ) {
      alert("Please fill in all event fields.");
      return;
    }

    try {
      await addEventToDB(newEvent);
      alert("Event added successfully!");
      form.reset();
      await renderEvents();
    } catch (error) {
      alert(error);
    }
  });
}

function attachDeleteHandlers() {
  const deleteButtons = document.querySelectorAll(".delete-btn");

  deleteButtons.forEach((button) => {
    button.addEventListener("click", async function () {
      const eventId = this.getAttribute("data-id");

      await deleteEventFromDB(eventId);
      alert("Event deleted successfully!");
      await renderEvents();
    });
  });
}

function setupSearchForm() {
  const searchForm = document.getElementById("searchForm");

  if (!searchForm) return;

  searchForm.addEventListener("submit", async function (event) {
    event.preventDefault();

    const searchType = document.getElementById("searchType").value;
    const searchValue = document.getElementById("searchValue").value.trim().toLowerCase();

    const allEvents = await getAllEventsFromDB();

    if (!searchValue) {
      renderEvents(allEvents);
      return;
    }

    const filteredEvents = allEvents.filter((event) => {
      if (searchType === "id") {
        return String(event.id).includes(searchValue);
      }

      if (searchType === "name") {
        return event.name.toLowerCase().includes(searchValue);
      }

      if (searchType === "category") {
        return event.category.toLowerCase().includes(searchValue);
      }

      return false;
    });

    renderEvents(filteredEvents);
  });
}