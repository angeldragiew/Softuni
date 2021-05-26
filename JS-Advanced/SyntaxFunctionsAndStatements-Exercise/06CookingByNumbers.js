function solve(number, arg1, arg2, arg3, arg4, arg5) {
    let array = [arg1, arg2, arg3, arg4, arg5];

    let num = Number(number);
    for (let i = 0; i < array.length; i++) {
        const element = array[i];

        switch (element) {
            case 'chop':
                num /= 2;
                break;
            case 'dice':
                num = Math.sqrt(num);
                break;
            case 'spice':
                num += 1;
                break;
            case 'bake':
                num *= 3;
                break;
            case 'fillet':
                num -= num * 0.20;
                break;
        }
        console.log(num);
    }
}

solve('32', 'chop', 'chop', 'chop', 'chop', 'chop');
console.log('');
solve('9', 'dice', 'spice', 'chop', 'bake', 'fillet');