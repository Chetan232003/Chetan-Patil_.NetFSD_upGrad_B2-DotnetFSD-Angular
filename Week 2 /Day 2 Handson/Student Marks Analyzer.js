const marks = [75, 82, 90, 60, 68];


const calculateTotal = (arr) => 
arr.reduce((sum, mark) => sum + mark, 0);

const calculateAverage = (arr) => 
calculateTotal(arr) / arr.length;

const getResult = (avg) => (avg >= 50 ? "Pass" : "Fail");


const total = calculateTotal(marks);
const average = calculateAverage(marks);
const result = getResult(average);

// Display output using template literals
console.log(`
Student Marks Report
-----------------------
Marks: ${marks.join(", ")}
Total: ${total}
Average: ${average.toFixed(2)}
Result: ${result}
`);