players_data = {
    "Ram": 100,
    "Shyam": 200,
    "Ghanshyam": 300,
    "Radha": 400,
    "Sita": 500,
    "Gita": 600,
    "Rita": 700,
    "Sunita": 800,
    "Anita": 900,
    "Manita": 1000,
    "Janita": 1100,
    "Kanita": 1200,
    "Banita": 1300,
    "Tanita": 1400,
    "Panita": 1500,
    "Vanita": 1600,
    "Sanita": 1700,
    "Danita": 1800,
    "Lanita": 1900,
    "Nanita": 2000
}

sorted_players = sorted(players_data.items(), key=lambda x: x[1], reverse=True)

print("Top 10 players are:")
for i in range(10):
    player, score = sorted_players[i]
    print(f"{player}: {score}")
