class Calculator:
    def add(self, a, b):
        return a + b

    def subtract(self, a, b):
        return a - b

    def multiply(self, a, b):
        return a * b

    def divide(self, a, b):
        if b != 0:
            return a / b
        else:
            return "Cannot divide by zero"


# Creating an object of the class
calc = Calculator()

# Using methods
print("Add:", calc.add(5, 3))
print("Subtract:", calc.subtract(5, 3))
print("Multiply:", calc.multiply(5, 3))
print("Divide:", calc.divide(5, 3))
print("Divide by zero:", calc.divide(5, 0))
