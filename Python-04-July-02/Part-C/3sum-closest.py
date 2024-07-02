class Solution:
    def threeSumClosest(self, nums: List[int], target: int) -> int:
        nums.sort()
        res = nums[0] + nums[1] + nums[2]
        
        for left in range(len(nums) - 2):
            middle = left + 1
            right = len(nums) - 1
            while middle < right:
                temp = nums[left] + nums[middle] + nums[right]
                if abs(temp - target) < abs(res - target):
                    res = temp
                if temp < target:
                    middle += 1
                elif temp > target:
                    right -= 1
                else:
                    return target
        return res