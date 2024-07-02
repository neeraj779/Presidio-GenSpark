def checkPrimeNumber(n):
    if n <= 1:
        return False
    elif n <= 3:
        return True
    elif n % 2 == 0 or n % 3 == 0:
        return False
    i = 5
    while i * i <= n:
        if n % i == 0 or n % (i + 2) == 0:
            return False
        i += 6
    return True


def findPrimeNumbers(n):
    primeNumbers = []
    for i in range(2, n+1):
        if checkPrimeNumber(i):
            primeNumbers.append(i)
    return primeNumbers


n = int(input("Enter a number: "))
print("Prime numbers upto", n, "are:", findPrimeNumbers(n))
