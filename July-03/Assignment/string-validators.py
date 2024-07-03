def check_string_properties(s):
    has_alnum = any(c.isalnum() for c in s)
    print(has_alnum)

    has_alpha = any(c.isalpha() for c in s)
    print(has_alpha)

    has_digit = any(c.isdigit() for c in s)
    print(has_digit)

    has_lower = any(c.islower() for c in s)
    print(has_lower)

    has_upper = any(c.isupper() for c in s)
    print(has_upper)


if __name__ == '__main__':
    s = input()
    check_string_properties(s)
