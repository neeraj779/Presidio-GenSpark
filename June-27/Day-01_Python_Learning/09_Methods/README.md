# Methods

Methods are functions that are defined within a class. They perform operations using the attributes of the class.

## Basic Method

```python
class MyClass:
    def my_method(self):
        print("Hello from my_method!")
```

## Method with Arguments

```python
class MyClass:
    def my_method(self, arg1, arg2):
        print(f"Hello from my_method! arg1: {arg1}, arg2: {arg2}")
```

## Method with Return Value

```python
class MyClass:
    def my_method(self):
        return "Hello from my_method!"
```

## Method with Arguments and Return Value

```python
class MyClass:
    def my_method(self, arg1, arg2):
        return f"Hello from my_method! arg1: {arg1}, arg2: {arg2}"
```

## Method with Default Arguments

```python
class MyClass:
    def my_method(self, arg1=1, arg2=2):
        return f"Hello from my_method! arg1: {arg1}, arg2: {arg2}"
```
