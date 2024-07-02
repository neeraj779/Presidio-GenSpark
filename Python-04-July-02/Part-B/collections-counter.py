from collections import Counter

def compute_earnings():
    input()
    shoe_sizes = list(map(int, input().split()))
    n = int(input())
    
    shoe_inventory = Counter(shoe_sizes)
    
    total_earnings = 0
    
    for _ in range(n):
        size, price = map(int, input().split())
        if shoe_inventory[size] > 0:
            total_earnings += price
            shoe_inventory[size] -= 1
    
    print(total_earnings)

compute_earnings()
