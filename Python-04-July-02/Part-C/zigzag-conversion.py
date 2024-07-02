class Solution:
    def convert(self, s: str, n: int) -> str:
        res = ''
        if n == 1:
            return s
        i = 0
        while i < len(s):
            res += s[i]
            i += n*2 -2
        for j in range(1,n-1):
            i = j 
            while i < len(s):
                res += s[i]
                if i+(n*2 - (j+1)*2) < len(s):                    
                    res += s[i+(n*2 - (j+1)*2)]
                i += n*2 - 2     
        i = n - 1
        while i < len(s):
            res += s[i]
            i += n*2 -2
        return res