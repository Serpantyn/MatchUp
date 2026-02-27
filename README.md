# 🎮 MatchUp

MatchUp is a memory-game, where player need to find pairs of identical cards in a limited time. 

The game is developed in .NET WPF using the MVVM pattern.


## Gameplay

- At the beginning, all cards are turned over
- The player opens 2 cards
- If cards are the same - they remain open
- If not - they are turned over
- The goal is to find all pairs in the minimum number of attempts and time

## Technologies & Concepts

- .NET (WPF)
- MVVM architecture
- ICommand, INotifyPropertyChanged
- JSON serialization (game history persistence)
- log4net (logging)
- MSTest (unit testing)

## Screenshots

### 🏠 Start Screen
<img src="screenshots/start.png" width="250" alt="Start" />

### 🎮 Game Mode Selection
<img src="screenshots/mode.png" width="250" alt="Mode" />

### 🧩 Gameplay
<img src="screenshots/gameplay.png" width="250" alt="Gameplay" />

### 🏆 Victory Screen
<img src="screenshots/victory.png" width="250" alt="Victory" />

### ❌ Defeat Screen
<img src="screenshots/defeat.png" width="250" alt="Defeat" />

### 📊 Game History
<img src="screenshots/history.png" width="250" alt="History" />
