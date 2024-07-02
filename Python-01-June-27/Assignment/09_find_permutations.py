def findPermutations(s):
    if len(s) == 0:
        return []
    if len(s) == 1:
        return [s]
    permutations = []
    for i in range(len(s)):
        current = s[i]
        remaining = s[:i] + s[i+1:]
        for p in findPermutations(remaining):
            permutations.append([current] + p)
    return permutations


n = int(input("Enter the number of elements: "))
s = [input(f"Enter the element {i}: ") for i in range(n)]
print(findPermutations(s))
print(f"Total permutations: {len(findPermutations(s))}")
