def luhn_check(card_number):
    digits = [int(digit) for digit in str(card_number)]

    for i in range(len(digits) - 2, -1, -2):
        digits[i] *= 2
        if digits[i] > 9:
            digits[i] -= 9

    total = sum(digits)

    return total % 10 == 0


card_number = input("Enter a card number: ")
is_valid = luhn_check(card_number)
print(f"Card number: {card_number}\nis valid: {is_valid}")
