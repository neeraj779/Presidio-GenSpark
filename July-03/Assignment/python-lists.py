if __name__ == '__main__':
    N = int(input())
    lst = []
    for _ in range(N):
        command = input().strip().split()

        cmd = command[0]
        args = command[1:]

        if cmd == 'insert':
            lst.insert(int(args[0]), int(args[1]))
        elif cmd == 'print':
            print(lst)
        elif cmd == 'remove':
            lst.remove(int(args[0]))
        elif cmd == 'append':
            lst.append(int(args[0]))
        elif cmd == 'sort':
            lst.sort()
        elif cmd == 'pop':
            lst.pop()
        elif cmd == 'reverse':
            lst.reverse()
