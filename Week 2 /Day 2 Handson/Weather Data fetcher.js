const API_URL = "https://api.open-meteo.com/v1/forecast?latitude=18.52&longitude=73.85&current_weather=true";

const fetchWeatherAsync = async () => {
try {
    const response = await fetch(API_URL);

    if (!response.ok) {
    throw new Error("Failed to fetch weather data");
    }

    const data = await response.json();
    const weather = data.current_weather;

    console.log(`
Weather Report
-------------------------------
Temperature: ${weather.temperature}°C
Wind Speed: ${weather.windspeed} km/h
Time: ${weather.time}
`);
  } catch (error) {
    console.error(`Error: ${error.message}`);
  }
};

fetchWeatherAsync();