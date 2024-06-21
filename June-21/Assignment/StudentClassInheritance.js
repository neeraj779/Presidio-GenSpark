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
    console.log(
      `Name: ${this.name}, Age: ${this.age}, Department: ${this.department}, Email: ${this.email}, Grade: ${this.grade}`
    );
  }
}

const grade = new Grade("John", 20, "Computer Science", "john@gmail.com", "A");
grade.displayDetails();
