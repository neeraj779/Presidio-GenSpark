class Math:
    def add(self, a, b, c=0):
        return a + b + c


math = Math()
print(math.add(2, 3))
print(math.add(2, 3, 4))
