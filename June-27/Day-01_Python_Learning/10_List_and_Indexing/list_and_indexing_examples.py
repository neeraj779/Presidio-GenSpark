# Creating a list
fruits = ["apple", "banana", "cherry"]

# Accessing items by index
print("First fruit:", fruits[0])
print("Second fruit:", fruits[1])
print("Third fruit:", fruits[2])

# Modifying a list item
fruits[1] = "blueberry"
print("Modified list:", fruits)

# Adding an item to the list
fruits.append("date")
print("List after append:", fruits)

# Removing an item from the list
fruits.remove("cherry")
print("List after remove:", fruits)

# Slicing the list
print("First two fruits:", fruits[:2])
print("Last two fruits:", fruits[-2:])

# inserting an item at a specific index
fruits.insert(1, "banana")
print("List after insert:", fruits)

# Deleting an item at a specific index
del fruits[1]
print("List after delete:", fruits)

# Iterating over a list
for fruit in fruits:
    print(fruit)

# Iterating over a list with index
for index, fruit in enumerate(fruits):  # enumerate returns index and value
    print("Index:", index, "Fruit:", fruit)

# Iterating over a list with index
for index in range(len(fruits)):
    print("Index:", index, "Fruit:", fruits[index])

# inverse the list
fruits.reverse()
print("List after reverse:", fruits)


# inverse the list using slicing
fruits = fruits[::-1]
print("List after reverse using slicing:", fruits)

# Sorting the list
fruits.sort()
print("List after sort:", fruits)

# Sorting the list in reverse
fruits.sort(reverse=True)

# Sorting the list using sorted
sorted_fruits = sorted(fruits)  # sorted returns a new list
print("Sorted fruits:", sorted_fruits)
