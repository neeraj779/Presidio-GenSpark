class Solution:
    def canJump(self, nums: List[int]) -> bool:

        res = 0
        for i,num in enumerate(nums):
            if i <= res:
                res = max(res, i + num)
        
        return res >= len(nums) - 1
        