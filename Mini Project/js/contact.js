function setupContactForm() {
  const form = document.getElementById("contactForm");

  if (!form) return;

  form.addEventListener("submit", function (event) {
    event.preventDefault();

    const name = document.getElementById("contactName").value.trim();
    const email = document.getElementById("contactEmail").value.trim();
    const description = document.getElementById("contactDescription").value.trim();

    if (!name || !email || !description) {
      alert("Please fill in all contact form fields.");
      return;
    }

    alert("Your query has been submitted successfully!");
    form.reset();
  });
}