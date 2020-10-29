# SI Gathering Challenge: Template

To run the project locally, you need docker:

```
docker build -t <name> .
docker run -p 8000:8000 <name>
```


# Gameplay

1. Game master starts a game
2. All players get 5 dices each
3. Game master initiates round
4. All player's dices are rolled (players only sees their own dices)
5. One player starts with making a bid
6. Next player either raises the bid or calls "liar"
7. When someone calls "liar" - compare the two players. One will loose a dice.
8. When a players is out of dices, he/she has lost.
9. The last player standing wins.


# Bid rules
* Initial bid: <Number of dices> x <Type of dice> (e.g. 7 x 2)
* To raise: Either raise number or type of dice (e.g. 8 x 2 or 7 x 3)
* 1's counts as "wild" (the same as the current bid dice)

# Compare rules
* If there are fewer dices in total on the table than the previous bid
-> The previous player looses one dice
* Else if there are a higher or equal number of dices in total
-> The one calling "liar" will loose a dice
