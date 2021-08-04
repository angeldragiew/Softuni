class List {
    constructor() {
        this.innerList = [];
        this.size = this.innerList.length;
    }

    add(elemenent) {
        this.innerList.push(elemenent);
        this.innerList.sort((a, b) => a - b);
        this.size++;
        return;
    }

    remove(index) {
        if (index >= 0 && index < this.innerList.length) {
            this.innerList.splice(index, 1);
            this.size--;
            return;
        }
    }

    get(index) {
        if (index >= 0 && index < this.innerList.length) {
            return this.innerList[index];
        }
    }
}


let list = new List();
list.add(5);
list.add(6);
list.add(7);
console.log('size ' + list.size);
console.log(list.get(1));
list.remove(1);
console.log(list.get(1));
