function solve(text){
    const regex = /\w+/gm;

    const found = text.match(regex).map(t=>t.toUpperCase());

    console.log(found.join(', '));
}

solve('Hi, how are you?');