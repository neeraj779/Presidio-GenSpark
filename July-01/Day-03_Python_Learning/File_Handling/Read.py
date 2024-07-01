def read_file():
    try:
        file = open("data.txt", "r")
        print(file.read())
        file.close()
    except FileNotFoundError:
        print("File not found")

# Read file using with keyword


def read_file_with():
    try:
        with open("data.txt", "r") as file:
            print(file.read())
    except FileNotFoundError:
        print("File not found")


read_file()
