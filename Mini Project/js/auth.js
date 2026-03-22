//Hardcoded Values direct login
const ADMIN_EMAIL = "admin@upgrad.com";
const ADMIN_PASSWORD = "12345";

const loginForm = document.getElementById("loginForm");

if (loginForm) {
  loginForm.addEventListener("submit", function (event) {
    event.preventDefault();

    const email = document.getElementById("email").value.trim();
    const password = document.getElementById("password").value.trim();

    //Validations
    if (!email || !password) {
      alert("Please fill in all fields.");
      return;
    }

    if (email === ADMIN_EMAIL && password === ADMIN_PASSWORD) {
      sessionStorage.setItem("isAdminLoggedIn", "true");
      alert("Login successful!");
      window.location.href = "events.html";
    } else {
      alert("Invalid email or password.");
    }
  });
}

function protectEventsPage() {
  const isLoggedIn = sessionStorage.getItem("isAdminLoggedIn");

  if (isLoggedIn !== "true") {
    alert("Unauthorized access. Please login first.");
    window.location.href = "login.html";
  }
}

function setupLogout() {
  const logoutBtn = document.getElementById("logoutBtn");

  if (logoutBtn) {
    logoutBtn.addEventListener("click", function () {
      sessionStorage.removeItem("isAdminLoggedIn");
      alert("Logged out successfully.");
      window.location.href = "login.html";
    });
  }
}