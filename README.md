# BattleGameSimulator
A simple C# game of battle, played over 1000 times, using some advanced techniques and SOLID principles.

## What is this ?
The battle is a simple card game. To win, one of the players must have all the cards.
Each player play a card at the same time and the highest card win. If two cards have the same value, it's a *battle* ! (hence the name)

I wanted to know how many hands must be played on average to win a Battle game, and if a tie situation could exists using my rules.
My special rules are :
* I shuffle my deck during the game (some people don't)
* If one player can't play anymore, but a battle occurs (on it's last card) then only the other player plays

## What can I learn from this repo ?
I used a simple algorith, but some "advanced" C# keywords, SOLID principles, and Dependency Injection using Ninject.
Have fun making stats from this, mesuring perfs, writting tests...

## Can I copy this repo ?
Sure, I'll be honored !
