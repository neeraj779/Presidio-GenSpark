# input() function is used to take input from user
name = input("Enter your name: ")

# Input as integer
age = int(input("Enter your age: "))
print("You are", age, "years old")

#  Multiple inputs
name, age = input("Enter your name and age: ").split(",")
print("Hello", name, "You are", age, "years old")

# Multiple inputs as integers
num1, num2 = map(int, input("Enter Two Numbers: ").split(","))
print("Sum of", num1, "and", num2, "is", num1 + num2)


# print() function is used to display output
print("Hello", name)

# More examples
print("Hello", name, "How ", "are", "you?", sep=", ", end="!")
