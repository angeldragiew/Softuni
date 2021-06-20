function encodeAndDecodeMessages() {
    let buttonsElements = document.querySelectorAll('button');
    let textAreaElements = document.querySelectorAll('textarea');

    buttonsElements[0].addEventListener('click', (e) => {
        let text = textAreaElements[0].value;

        let encodedText = '';
        for (let i = 0; i < text.length; i++) {
            let newChar = text.charCodeAt(i) + 1;
            encodedText += String.fromCharCode(newChar);
        }
        textAreaElements[1].value = encodedText;
        textAreaElements[0].value = '';
    });

    buttonsElements[1].addEventListener('click', (e) => {
        let text = textAreaElements[1].value;

        let decodedText = '';
        for (let i = 0; i < text.length; i++) {
            let newChar = text.charCodeAt(i) - 1;
            decodedText += String.fromCharCode(newChar);
        }
        textAreaElements[1].value = decodedText;
    });
}