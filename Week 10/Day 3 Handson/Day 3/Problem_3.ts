class Employee{
    constructor(
        public id:number,
        protected name:string,
        private salary:number

    ){}

    getsalary():number{
        return this.salary;
    }

    setsalary(value:number):void{
        if(value >0){
            this.salary=value;
        }else{
            console.log(`Salary must be greater then 0`);
        }
    }

    displaydetails():void{
        console.log(`Employee Id : ${this.id}`);
        console.log(`Employee Name is : ${this.name}.`);
        console.log(`Employee Salary :${this.salary}`);
    }

    
}
class Manager extends Employee{
    constructor(
        id:number,
        name:string,
        salary:number,
        public teamsize: number

    ){
        super(id,name,salary)
    }

    displaydetails(): void {
        console.log("Manager Details:");
        console.log(`Employee ID: ${this.id}`);
        console.log(`Employee Name: ${this.name}`);
        console.log(`Team Size: ${this.teamsize}`);
        console.log(`Salary: ${this.getsalary()}`);
    }

}

let emp1 = new Employee(1,"Chetan",50000);
console.log("Employee Details");
emp1.displaydetails();

console.log("Updated Salary");
emp1.setsalary(70000);
console.log(emp1.getsalary());

let manager = new Manager(201 , "Mayur" ,80000,4);
console.log(manager.displaydetails());