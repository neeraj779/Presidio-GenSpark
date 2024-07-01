def exception_handling():
    try:
        a = 10
        b = 0
        c = a/b
        print(c)
    except ZeroDivisionError:
        print("Division by zero is not allowed")
    except Exception as e:
        print(e)
    finally:
        print("Finally block is always executed")


exception_handling()
