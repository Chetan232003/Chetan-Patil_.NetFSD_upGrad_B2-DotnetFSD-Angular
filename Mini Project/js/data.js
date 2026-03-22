async function initializeDefaultEvents() {
  const existingEvents = await getAllEventsFromDB();

  if (existingEvents.length === 0) {
    const defaultEvents = [
      {
        id: 101,
        name: "Dev Tech",
        category: "Tech & Innovations",
        date: "2026-03-04",
        time: "15:15",
        url: "https://example.com/dev-tech"
      },
      {
        id: 102,
        name: "MCT Summit",
        category: "Tech & Innovations",
        date: "2026-03-09",
        time: "14:15",
        url: "https://example.com/mct-summit"
      },
      {
        id: 103,
        name: "Client Summit",
        category: "Industrial Event",
        date: "2026-03-17",
        time: "15:00",
        url: "https://example.com/client-summit"
      }
    ];

    for (const event of defaultEvents) {
      try {
        await addEventToDB(event);
      } catch (error) {
        console.log(error);
      }
    }
  }
}