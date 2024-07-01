class Person:
    def __init__(self, name, age):
        self.name = name
        self.age = age

    def greet(self):
        print("Hello my name is " + self.name)

    def get_age(self):
        print("My age is " + str(self.age))

    def set_age(self, age):
        self.age = age

    def set_name(self, name):
        self.name = name

    def get_name(self):
        print("My name is " + self.name)


p1 = Person("John", 36)
p1.greet()
p1.get_age()
p1.get_name()
p1.set_age(40)
p1.get_age()
p1.set_name("Mike")
p1.get_name()
