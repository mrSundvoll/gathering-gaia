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
