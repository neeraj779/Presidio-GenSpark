def lengthOfLongestSubstring(s: str) -> int:
    if len(s) == 0:
        return 0
    visited = {}
    left, right = 0, 0
    longest = 1
    while right < len(s):
        if s[right] in visited:
            left = max(left, visited[s[right]]+1)
        longest = max(longest, right - left + 1)
        visited[s[right]] = right
        right += 1
    return longest


s = input("Enter a string: ")
print(lengthOfLongestSubstring(s))
