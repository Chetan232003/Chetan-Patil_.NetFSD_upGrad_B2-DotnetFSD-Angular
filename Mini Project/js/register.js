// Load Event Details on Page
async function loadEventDetails() {

  const params = new URLSearchParams(window.location.search);
  const eventId = params.get("id");

  const container = document.getElementById("eventDetails");

  if (!eventId || !container) return;

  try {
    // Get event data from IndexedDB
    const eventData = await getEventByIdFromDB(eventId);

    if (!eventData) {
      container.innerHTML = "<p>Event not found.</p>";
      return;
    }

    // Display event details
    container.innerHTML = `
      <h4 class="mb-3">Event Details</h4>
      <p><strong>Event ID:</strong> ${eventData.id}</p>
      <p><strong>Event Name:</strong> ${eventData.name}</p>
      <p><strong>Category:</strong> ${eventData.category}</p>
      <p><strong>Date:</strong> ${eventData.date}</p>
      <p><strong>Time:</strong> ${eventData.time}</p>
    `;
  } catch (error) {
    console.error(error);
    container.innerHTML = "<p>Error loading event details.</p>";
  }
}

function setupRegistrationForm() {

  const form = document.getElementById("registrationForm");

  if (!form) return;

  form.addEventListener("submit", function (event) {
    event.preventDefault();

    // 1. Get user input
    const firstName = document.getElementById("firstName").value.trim();
    const lastName = document.getElementById("lastName").value.trim();
    const email = document.getElementById("participantEmail").value.trim();

    // Validation
    if (!firstName || !lastName || !email) {
      alert("Please fill all participant details.");
      return;
    }

    // Get event ID from URL
    const params = new URLSearchParams(window.location.search);
    const eventId = params.get("id");

    //  Create registration object
    const registration = {
      eventId: eventId,
      firstName: firstName,
      lastName: lastName,
      email: email
    };

    // Get existing registrations
    let registrations = JSON.parse(localStorage.getItem("registrations")) || [];

    //  Prevent duplicate registration
    const alreadyRegistered = registrations.some(
      (r) => r.email === email && r.eventId === eventId
    );

    if (alreadyRegistered) {
      alert("You have already registered for this event!");
      return;
    }

    //  Save new registration
    registrations.push(registration);

    // Store in LocalStorage
    localStorage.setItem("registrations", JSON.stringify(registrations));

    // Success message
    alert("You are successfully registered to this event!");

    // Reset form
    form.reset();
  });
}