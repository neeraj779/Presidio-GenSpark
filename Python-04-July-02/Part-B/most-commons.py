from collections import Counter


if __name__ == '__main__':
    s = sorted(input())

    map = Counter(s).most_common(3)

    for i in map:
        print(f'{i[0]} {i[1]}')
