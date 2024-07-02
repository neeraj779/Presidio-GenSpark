# single Inheritance in Python
class Employee:
    def __init__(self, name, age, salary):
        self.name = name
        self.age = age
        self.salary = salary

    def display(self):
        print("Name:", self.name)
        print("Age:", self.age)
        print("Salary:", self.salary)


class Programmer(Employee):
    def __init__(self, name, age, salary, language):
        super().__init__(name, age, salary)
        self.language = language

    def display(self):
        super().display()
        print("Language:", self.language)


p1 = Employee("John", 36, 100000)
p2 = Programmer("John", 36, 100000, "Python")

p1.display()
print(10*"-")
p2.display()
