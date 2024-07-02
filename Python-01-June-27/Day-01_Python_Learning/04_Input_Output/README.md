# Input and Output

## Input

To get input from the user, you can use the `input()` function. It reads a line from input, converts it to a string, and returns it.

## More on `input()`

1. The `input()` function can take a string as an argument. This string will be displayed to the user before taking input.
2. The `input()` function always returns a string. If you want to take an integer input, you need to convert it to an integer using the `int()` function.
3. The `input()` function reads a line from the input and returns it. If you want to read multiple values from the input, you can use the `split()` function.

```python
a, b = input().split()
```

The above code will read two values from the input and store them in variables `a` and `b`.

4. The `split()` function splits the input based on the separator. By default, the separator is a space. You can specify the separator using the `split()` function.

```python
a, b = input().split(',')
```

The above code will read two values from the input separated by a comma and store them in variables `a` and `b`.

5. If you want to read multiple values from the input and convert them to integers, you can use the `map()` function.

```python
a, b = map(int, input().split())
```

The above code will read two values from the input, split them based on the separator, convert them to integers, and store them in variables `a` and `b`.

6. If you want to read multiple values from the input and convert them to integers, you can use the `map()` function with a lambda function also.

```python
a, b = map(lambda x: int(x), input().split())
```

The above code will read two values from the input, split them based on the separator, convert them to integers, and store them in variables `a` and `b`.

7. If you want to read multiple values from the input and convert them to integers, you can use the `map()` function with a list comprehension also.

```python
a, b = [int(x) for x in input().split()]
```

The above code will read two values from the input, split them based on the separator, convert them to integers, and store them in variables `a` and `b`.

## Output

To display output to the user, you can use the `print()` function. It converts its arguments to a string and writes them to standard output.

## More on `print()`

The `print()` function can take multiple arguments. It will concatenate them with a space in between and print them. You can also specify the separator using the `sep` argument.

```python
print('Hello', 'World', sep=', ')
```

The above code will print `Hello, World`.

You can also specify the end character using the `end` argument the default value of which is `\n`.

```python
print('Hello', end=' ')
print('World')
```

The above code will print `Hello World` on the same line.

## Other Parameters of Print Statement

1. object(s): Any object, and as many as you like. Will be converted to string before printed

2. sep='separator': Specify how to separate the objects, if there is more than one. Default is ' '

3. end='end': Specify what to print at the end. Default is '\n' (line feed)

4. file: An object with a write method. Default is sys.stdout

5. flush: A Boolean, specifying if the output is flushed (True) or buffered (False). Default is False. Flush means that the output is written to the console immediately. Buffered means that the output is stored in a buffer and written to the console later.

**_Parameters 2 to 4 are optional_**

## Examples

```python
print(object(s), sep=separator, end=end, file=file, flush=flush)
```
