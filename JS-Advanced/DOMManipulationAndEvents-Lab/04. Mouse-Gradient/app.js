function attachGradientEvents() {
    let gradientElement = document.getElementById('gradient');
    let resultElement = document.getElementById('result');

    gradientElement.addEventListener('mousemove', gradientMove);
    
    function gradientMove(e) {
        // let width = e.target.clientWidth - 1;
        // let percent = Math.trunc((e.offsetX / width) * 100);
        // resultElement.textContent = `${percent}%`;
        let width = e.currentTarget.clientWidth - 1;
        let percent = Math.trunc((e.offsetX / width) * 100);
        resultElement.textContent = `${percent}%`;
    } 
}