if __name__ == '__main__':
    students = []
    for _ in range(int(input())):
        name = input()
        score = float(input())

        inp = [name, score]
        students.append(inp)

    scores = [student[1] for student in students]
    unique_scores = sorted(set(scores))
    second_lowest_score = unique_scores[1]

    res = sorted([student[0]
                 for student in students if student[1] == second_lowest_score])

    for i in res:
        print(i)
