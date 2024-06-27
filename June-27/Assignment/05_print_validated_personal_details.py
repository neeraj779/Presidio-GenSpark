def validate_name(name):
    if name.isalpha() == False:
        print("Name must contain only alphabets.")
        return False
    return True


def validate_age(age):
    if age.isdigit() == False:
        print("Age must contain only digits.")
        return False
    return True


def validate_dob(dob):
    if len(dob) != 10:
        print("Date of birth must be in dd/mm/yyyy format.")
        return False
    if dob[2] != "/" or dob[5] != "/":
        print("Date of birth must be in dd/mm/yyyy format.")
        return False
    return True


def validate_phone(phone):
    if phone.isdigit() == False:
        print("Phone number must contain only digits.")
        return False
    if len(phone) != 10:
        print("Phone number must contain 10 digits.")
        return False
    return True


def get_input(prompt, validator):
    while True:
        value = input(prompt)
        if validator(value):
            return value


name = get_input("Enter your name: ", validate_name)
age = get_input("Enter your age: ", validate_age)
dob = get_input("Enter your date of birth (dd/mm/yyyy): ", validate_dob)
phone = get_input("Enter your phone number: ", validate_phone)

print("\nPersonal Details:")
print("Name: " + name)
print("Age: " + age)
print("Date of Birth: " + dob)
print("Phone: " + phone)
