function printDeckOfCards(cards) {
    function createCard(face, suit) {
        let validFaces = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];
        let validSuits = ['S', 'H', 'D', 'C'];

        if (!validFaces.includes(face)) {
            throw new Error(`Invalid card: ${face}${suit}`);
        }
        if (!validSuits.includes(suit)) {
            throw new Error(`Invalid card: ${face}${suit}`);
        }

        return {
            face: face,
            suit: suit,
            toString: function () {
                let code = '';
                switch (suit) {
                    case 'S':
                        code = '\u2660';
                        break;
                    case 'H':
                        code = '\u2665';
                        break;
                    case 'D':
                        code = '\u2666';
                        break;
                    case 'C':
                        code = '\u2663';
                        break;
                }
                return `${face}${code}`;
            }
        }
    }

    let createdCards = [];
    for (const card of cards) {
        let suit = card[card.length - 1];
        let face = card.slice(0, card.length - 1);
        try {
            createdCards.push(createCard(face, suit));
        } catch (e) {
            console.log(e.message);
            return;
        }

    }
    console.log(createdCards.join(' '));
}


printDeckOfCards(['5S', '3D', 'QD', '1C']);
