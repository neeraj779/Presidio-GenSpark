function Person(name, age) {
  this.name = name;
  this.age = age;
}

Person.prototype.greet = function () {
  console.log(`Hello, my name is ${this.name}`);
};

const person1 = new Person("John", 30);
person1.greet();

function Student(name, age, grade) {
  Person.call(this, name, age);
  this.grade = grade;
}

Student.prototype = Object.create(Person.prototype);
Student.prototype.constructor = Student;

Student.prototype.greet = function () {
  console.log(`Hello, my name is ${this.name} and my grade is ${this.grade}`);
};

const student1 = new Student("Tom", 25, "A");
student1.greet();
