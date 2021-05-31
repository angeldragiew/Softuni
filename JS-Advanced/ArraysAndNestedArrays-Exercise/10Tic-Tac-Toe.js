function solve(moves) {
    let playerTurn = 'X';
    let dashboard = [
        [false, false, false],
        [false, false, false],
        [false, false, false]
    ];

    for (let i = 0; i < moves.length; i++) {
        const move = moves[i];
        let coordinates = move.split(' ');
        let row = Number(coordinates[0]);
        let col = Number(coordinates[1]);

        if (dashboard[row][col] === false) {
            dashboard[row][col] = playerTurn;
        } else {
            console.log("This place is already taken. Please choose another!");
            continue;
        }

        if (isThereAWinner(dashboard)) {
            console.log(`Player ${playerTurn} wins!`);
            printDashBoard(dashboard);
            break;
        }

        if (isThereFreePlaces(dashboard) === false) {
            console.log("The game ended! Nobody wins :(");
            printDashBoard(dashboard);
            break;
        }

        if (playerTurn === 'X') {
            playerTurn = 'O';
        } else {
            playerTurn = 'X';
        }
    }

    function isThereFreePlaces(board) {
        let isFreePlacesExist = false;

        for (let row = 0; row < board.length; row++) {
            for (let col = 0; col < board[0].length; col++) {
                const element = board[row][col];
                if (element === false) {
                    isFreePlacesExist = true;
                    break;
                }
            }
        }

        return isFreePlacesExist;
    }

    function isThereAWinner(board) {
        let isWinner = true;
        for (let row = 0; row < board.length; row++) {
            isWinner = true;
            let sign = board[row][0];
            if (sign === false) {
                isWinner = false;
                continue;
            }
            for (let col = 1; col < board[0].length; col++) {
                if (sign !== board[row][col]) {
                    isWinner = false;
                }
            }
            if (isWinner === true) {
                return isWinner;
            }
        }

        for (let col = 0; col < board.length; col++) {
            isWinner = true;
            let sign = board[0][col];
            if (sign === false) {
                isWinner = false;
                continue;
            }
            for (let row = 1; row < board[0].length; row++) {
                if (sign !== board[row][col]) {
                    isWinner = false;
                }
            }
            if (isWinner === true) {
                return isWinner;
            }
        }

        if (board[0][0] === board[1][1] && board[2][2] === board[1][1] && board[0][0] !== false) {
            isWinner = true;
        }
        if (board[0][2] === board[1][1] && board[2][0] === board[1][1] && board[0][2] !== false) {
            isWinner = true;
        }

        return isWinner;
    }

    function printDashBoard(board) {
        for (let i = 0; i < board.length; i++) {
            const row = board[i];
            console.log(row.join('\t'));
        }
    }
}




// console.log(solve(["0 1",
//     "0 0",
//     "0 2",
//     "2 0",
//     "1 0",
//     "1 1",
//     "1 2",
//     "2 2",
//     "2 1",
//     "0 0"]
// ));

console.log(solve(["0 0",
    "0 0",
    "1 1",
    "0 1",
    "1 2",
    "0 2",
    "2 2",
    "1 2",
    "2 2",
    "2 1"]
));

// console.log(solve(["0 1",
//     "0 0",
//     "0 2",
//     "2 0",
//     "1 0",
//     "1 2",
//     "1 1",
//     "2 1",
//     "2 2",
//     "0 0"]
// ));

// console.log(solve(['0 1',
//     "0 0",
//     "0 2",
//     "2 0",
//     "1 0",
//     "1 2",
//     "1 1",
//     "2 1",
//     "2 2",
//     "0 0"]));