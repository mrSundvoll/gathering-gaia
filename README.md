# Liar's dice

This is a web-based implementation of the dice game [the liar's dice](https://en.wikipedia.org/wiki/Liar%27s_dice).

The solution is hosted on [radix](https://gathering-gaia.app.playground.radix.equinor.com/).


# Gameplay

1. A player create a new game.
1. Players sign up for the game.
1. Game master starts game.
1. All players start with 5 dice each.
1. In the beginning of each round, all player's dice are rolled. Players can only see their own dice.
1. The first player starts by making a bid [*](#bid_rules).
1. The next player either raises the bid or calls "liar".
1. When someone calls "liar" - the current bid is evaluated towards the actual number of dice on the table. One player will lose a dice [**](#compare_rules).
1. All remaining dice are rolled again, and the loser of the last round starts this round by placing the initial bid.
1. When a player is out of dice, he/she has lost.
1. The last player standing wins the game.

<a name="bid_rules">*</a> Bid rules:
* Each bid names a dice value (between 1 and 6) and a number of dice (between 1 and the remaining number of dice of all players)
* Initial bid: "Number of dices" x "Dice value" (e.g. 7 x 2)
* To raise, the player must either raise number or value of the dice (here: at minimim either 8 x 2 or 7 x 3)
* 1's counts as "wild" (will always count towards the sum of the current bid dice)

<a name="compare_rules">**</a> Evaluate bid:
* The number of dice on the table matching the current bid are counted, including all the 1's.
* If the number of dice is lower than the previous bid
-> The previous player loses one dice
* Else if the number of dice is higher than or equal to the previous bid
-> The one calling "liar" will lose one dice
