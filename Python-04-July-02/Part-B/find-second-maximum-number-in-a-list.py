if __name__ == '__main__':
    n = int(input())
    arr = list(map(int, input().split()))
    
    first_max = max(arr)
    second_max_list = [x for x in arr if x != first_max]
    
    print(max(second_max_list))