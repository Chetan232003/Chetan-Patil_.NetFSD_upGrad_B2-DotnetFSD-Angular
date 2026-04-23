"use strict";
// Variable Declaration
const username = "Chetan";
let age = 23;
let Email = "chetan@gmail.com";
const IsSubscribed = true;
//Type Inference
let city = "Mumbai";
let rating = 4.5;
//Age Increment
age = age + 1;
//Check Primium
let IsPremium = age > 18 && IsSubscribed;
let message = `Hello my name is ${username} and i am ${age} old and my email is ${Email}`;
console.log(message);
console.log(city);
console.log(rating);
console.log(IsPremium);
