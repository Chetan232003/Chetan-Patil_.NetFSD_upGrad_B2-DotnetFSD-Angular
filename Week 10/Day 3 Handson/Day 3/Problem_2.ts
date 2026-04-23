
//Function with Required Parameters
function getWelcomemassage(name:string):string{
    return `Welcome ${name}`;
}

console.log(getWelcomemassage("Chetan"));

//Optional Parameters
function getInfo(name:string , age?:number):string{
    if(age){
        return`${name} is ${age} year old`;

    }else{
        return `${name}'s age is not provided`;
    }
}

console.log(getInfo("chetan", 23));
console.log(getInfo("Chetan"));

//Default Parameter

function getSubscriptionStatus(name:string , isSubscribe:boolean = false):string{
    return isSubscribe ?`${name} is subscribed.`
     :`${name} is not Subscribed.`
}

console.log(getSubscriptionStatus("Chetan", true));
console.log(getSubscriptionStatus("Mayur"));

//return type
function isEligibleForPremium(age : number):boolean{
    return age> 18;
}
console.log(isEligibleForPremium(17));

//Arrow Function
const greetUser = (name:string):string => {
    return `Hello ${name} Welcome to Cognizant`;
}
console.log(greetUser("Chetan"));

//Lexical this

const NotificationService = {

    appname:"MyApp",

    sendnotification :function ()  {
        console.log(`This is the Notification for ${this.appname}`)
    }

}

NotificationService.sendnotification();