# Multiple Inheritance
class A:
    def method1(self):
        print("Method 1 from class A")


class B:
    def method2(self):
        print("Method 2 from class B")


class C(A, B):
    def method3(self):
        print("Method 3 from class C")


c = C()
c.method1()
c.method2()
c.method3()
