# Contributing


## The solution
This solution consists of a client and an api.
- The API can be found under [LiarsDiceAPI](LiarsDiceAPI) and is implemented using dotnet core.
- Client can be found under [WebClient](WebClient).

### API
API development requires dotnet core installed and an IDE as VSCode. For VSCode extension `ms-dotnettools.csharp` should be used. When this is installed, `Start debugging` should create and setup the necessary tools to debug the application. When debugging, the API will by default be available on: https://localhost:5001, and you can see the swagger definition on https://localhost:5001/swagger. It might run under a certificate that is not valid and you'll have to accept this the first time you run the API.

### Client
Client development is done using `docker-compose up`. This will host the `api` on `http://localhost:5000/` and the static web site on `http://localhost:8080/`. The static web site can now be developed and the solution should be updated on changes (need to refresh browser between changes).

### Run the project
To run the project locally, you need docker and docker-compose:

```
docker-compose up
```

game can now be found under `http://localhost:8080/`.


## How to contribute
We are happy to receive contributions to this project.

Feel free to submit an issue if you discover a bug or want to propose a new
feature.

If you want, you are also welcome to fix the bug, implement the feature
or write documentation for some part of the project. You can do this by forking the
repo, making your changes here and [creating a pull request](https://docs.github.com/en/free-pro-team@latest/github/collaborating-with-issues-and-pull-requests/creating-a-pull-request).

To increase the likeliness that your pull request will be accepted please consider
the following:
* Write tests for the new code
* Make sure every commit passes all the tests.
* Write [good commit messages](https://chris.beams.io/posts/git-commit/).
