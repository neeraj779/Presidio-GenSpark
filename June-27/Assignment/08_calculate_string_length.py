def calculateStringLength(string):
    return len(string)


def calculateStringLengthLoop(string):
    count = 0
    for i in string:
        count += 1
    return count


name = input("Enter string: ")
print("Length of string is", calculateStringLength(name))
print("Length of string is", calculateStringLengthLoop(name))
