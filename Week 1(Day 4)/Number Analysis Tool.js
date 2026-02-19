let num = 7;

let sign = (num >= 0) ? "Positive" : "Negative";

if (num % 2 === 0) {
    console.log("Number is Even");
} else {
    console.log("Number is Odd");
}

//Here to check num is +ve or -ve
console.log("Number is " + sign);

// Loop 
for (let i = 1; i <= num; i++) {
    console.log(i);
}
