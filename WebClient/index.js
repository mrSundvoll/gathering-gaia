class Player {
    constructor() {
        this.dice = 5
        this.roll = {
            1: 0,
            2: 0,
            3: 0,
            4: 0,
            5: 0,
            6: 0,
        }
    }

    doRoll() {
        this.roll = {
            1: 0,
            2: 0,
            3: 0,
            4: 0,
            5: 0,
            6: 0,
        }

        for (let i = 0; i < this.dice; i++) {
            this.roll[Math.floor(Math.random() * 6) + 1] += 1;
        }
    }
}

class Game {
    constructor() {
        this.currentPlayer = new Player()

        $("#game .dice").text(this.currentPlayer.dice)
        $("#game .call").on("click", () => this.onCall())
        $("#game .roll").on("click", () => {
            this.currentPlayer.doRoll()
            this.updateRoll()
        })

        for (let i = 1; i <= 6; i++)
            $(`#game .bid-${i}`).on("click", () => this.onBid(i))
    }

    updateRoll() {
        for (let i = 1; i <= 6; i++) {
            $(`#game .dice-${i}`).text(this.currentPlayer.roll[i])
        }
    }

    onBid(which) {
        const amount = $("#game .bid-amount").val()
        alert("User bid " + amount + " " + which)
    }

    onCall() {
        alert("Call")
    }
}

function initStart() {
    $("#start .name").on("keyup", elem => {
        if (elem.currentTarget.value === "") {
            $("#start button").attr("disabled", "disabled")
        } else {
            $("#start button").removeAttr("disabled")
        }
    })

    $("#start .room").on("keyup", elem => {
        if (elem.currentTarget.value === "") {
            $("#start .join").attr("disabled", "disabled")
        } else {
            $("#start .join").removeAttr("disabled")
        }
    })

    $("#start .create").on("click", () => {
        window.game = new Game()
        $("#start").addClass("d-none")
        $("#game").removeClass("d-none")
    });

    $("#start .join").on("click", () => {
        alert("Join")
    });
}

$(() => {
    initStart()

        window.game = new Game()
    $("#game").toggleClass("d-none")
})
