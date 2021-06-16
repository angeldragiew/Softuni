function focused() {
    let inputsList = document.querySelectorAll('input');
    for (const input of inputsList) {
        input.addEventListener('focus', focusHandle)
        input.addEventListener('blur',blurHandler)
    }
 
    function focusHandle(e){
        e.target.parentElement.className = 'focused';
    }
    function blurHandler(e){
        e.target.parentElement.className='';
    }
}