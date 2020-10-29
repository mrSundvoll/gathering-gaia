# Liar's dice

This is a web-based implementation of the dice game [the liar's dice](https://en.wikipedia.org/wiki/Liar%27s_dice).

Solution is hosted on [radix](https://gathering-gaia.app.playground.radix.equinor.com/)

To run the project locally, you need docker and docker-compose:

```
docker-compose up
```

game can now be found under `http://localhost:8080/`. 

# Contribution

Solution consist of a client and api. 
- The API is at root of this repository and implemented using dotnet core. 
- Client can be found under [WebClient](./WebClient).

## API

API development requires dotnet core installed and an IDE as VSCode. For VSCode extension `ms-dotnettools.csharp` should be used. When this is installed, `Start debugging` should create and setup the necessary tools to debug the application. When debugging, the API will by default be available on: https://localhost:5001, and you can see the swagger definition on https://localhost:5001/swagger. It might run under a certificate that is not valid and you'll have to accept this the first time you run the API. 

## Client 

Client development is done using `docker-compose up`. This will host the `api` on `http://localhost:5000/` and the static web site on `http://localhost:8080/`. The static web site can now be developed and the solution should be updated on changes (need to refresh browser between changes).

# Gameplay

1. A player create a new game.
1. Players sign up for the game.
1. Game master starts game.
1. All players start with 5 dice each.
1. In the beginning of each round, all player's dice are rolled. Players can only see their own dice.
1. The first player starts by making a bid*.
1. The next player either raises the bid or calls "liar".
1. When someone calls "liar" - the current bid is compared to the actual number of dice on the table. One player will lose a dice.
1. The loser of the last round starts the next round by placing the initial bid.
1. When a player is out of dice, he/she has lost.
1. The last player standing wins the game.

## Bid rules
* Initial bid: <Number of dices> x <Type of dice> (e.g. 7 x 2)
* To raise: Either raise number or type of dice (e.g. 8 x 2 or 7 x 3)
* 1's counts as "wild" (the same as the current bid dice)

## Compare rules
* If there are fewer dices in total on the table than the previous bid
-> The previous player looses one dice
* Else if there are a higher or equal number of dices in total
-> The one calling "liar" will loose a dice
