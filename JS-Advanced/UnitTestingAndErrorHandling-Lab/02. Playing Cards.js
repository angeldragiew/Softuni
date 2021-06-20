function createCard(face, suit) {
    let validFaces = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];
    let validSuits = ['S', 'H', 'D', 'C'];

    if (!validFaces.includes(face)) {
        throw new Error('Error');
    }
    if (!validSuits.includes(suit)) {
        throw new Error('Error');
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

try{
    console.log(createCard('10', 'H').toString());
}catch(e){
    console.log(e.message);
}
