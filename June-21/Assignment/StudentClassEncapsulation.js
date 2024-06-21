class Student {
  constructor(name, age, department, email) {
    this.name = name;
    this.age = age;
    this.department = department;
    this.email = email;
  }

  getName() {
    return this.name;
  }

  setGrade(name) {
    this.name = name;
  }
}

const student = new Student("John", 20, "Computer Science", "john@gmail.com");
console.log(student.getName());
student.setGrade("Doe");
console.log(student.getName());
