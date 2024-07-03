if __name__ == '__main__':
    n = int(input())
    student_marks = {}
    for _ in range(n):
        name, *line = input().split()
        scores = list(map(float, line))
        student_marks[name] = scores
    query_name = input()

    value = student_marks[query_name]
    res = 0
    for i in value:
        res += i
    average = res / 3
    print(f"{average:.2f}")
