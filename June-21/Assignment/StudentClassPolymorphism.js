class Student {
  constructor(name, age, department, email) {
    this.name = name;
    this.age = age;
    this.department = department;
    this.email = email;
  }

  displayDetails() {
    console.log(
      `Name: ${this.name}, Age: ${this.age}, Department: ${this.department}, Email: ${this.email}`
    );
  }
}

class Grade extends Student {
  constructor(name, age, department, email, grade) {
    super(name, age, department, email);
    this.grade = grade;
  }

  displayDetails() {
    super.displayDetails();
    console.log(`Grade: ${this.grade}`);
  }
}

class Parents extends Student {
  constructor(name, age, department, email, parentName, parentEmail) {
    super(name, age, department, email);
    this.parentName = parentName;
    this.parentEmail = parentEmail;
  }

  displayDetails() {
    super.displayDetails();
    console.log(
      `Parent Name: ${this.parentName}, Parent Email: ${this.parentEmail}`
    );
  }
}

const student = new Student("John", 20, "Computer Science", "john@gmail.com");
const grade = new Grade("John", 20, "Computer Science", "john@gmail.com", "A");
const parents = new Parents(
  "John",
  20,
  "Computer Science",
  "john@gmail.com",
  "Doe",
  "doe@gmail.com"
);

const students = [student, grade, parents];

students.forEach((student) => student.displayDetails());
