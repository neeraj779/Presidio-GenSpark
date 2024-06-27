# For loop
numbers = [1, 2, 3, 4, 5]
for number in numbers:
    print(number)


# Using range in for loop
for i in range(5):
    print("range:", i)


# Using range in for loop with start and end
for i in range(2, 5):
    print("start-end:", i)


# Using range in for loop with start, end and step
for i in range(2, 10, 2):
    print("start-end-step:", i)


# Using range in for loop with start, end and step
for i in range(10, 2, -2):
    print("start-end-step:", i)


# While loop
count = 0
while count < 5:
    print("Count:", count)
    count += 1
