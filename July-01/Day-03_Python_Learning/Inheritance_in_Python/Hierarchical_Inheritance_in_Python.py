# Hierarchical Inheritance: multiple derived classes from a single base class
class A:
    def method1(self):
        print("Method 1 from class A")


class B(A):
    def method2(self):
        print("Method 2 from class B")


class C(A):
    def method3(self):
        print("Method 3 from class C")


b = B()
c = C()
b.method1()
b.method2()
c.method1()
c.method3()
