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

  updateName(name) {
    this.name = name;
  }

  updateAge(age) {
    this.age = age;
  }

  updateDepartment(department) {
    this.department = department;
  }
}

const student = new Student("John", 20, "Computer Science", "john@gmail.com");
student.displayDetails();
student.updateName("Jane");
student.updateAge(21);
student.updateDepartment("Electrical Engineering");
student.displayDetails();
