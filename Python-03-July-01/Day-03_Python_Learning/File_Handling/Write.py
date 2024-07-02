def write_file():
    try:
        file = open("data.txt", "w")
        file.write("Hello, World!")
        file.close()
    except PermissionError:
        print("Permission denied")

# Write file using with keyword


def write_file_with():
    try:
        with open("data.txt", "w") as file:
            file.write("Hello, World!")
    except PermissionError:
        print("Permission denied")


write_file()
