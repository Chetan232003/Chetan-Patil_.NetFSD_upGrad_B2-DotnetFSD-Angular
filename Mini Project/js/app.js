async function renderHomeEvents() {
  const container = document.getElementById("homeEventsContainer");

  if (!container) return;

  const events = await getAllEventsFromDB();
  container.innerHTML = "";

  // Validation If no events then show nothing (blank)
  if (events.length === 0) {
    return; 
  }

  // Only show events added by admin
  events.forEach((event) => {
    const col = document.createElement("div");
    col.className = "col-lg-4 col-md-6";

    col.innerHTML = `
      <div class="card shadow-sm h-100 event-card">
        <div class="card-body">
          <h4 class="card-title fw-bold">${event.name}</h4>
          <p><strong>Category:</strong> ${event.category}</p>
          <p><strong>Date:</strong> ${event.date}</p>
          <p><strong>Time:</strong> ${event.time}</p>
          <a href="register.html?id=${event.id}" class="btn btn-primary">Register</a>
        </div>
      </div>
    `;

    container.appendChild(col);
  });
}