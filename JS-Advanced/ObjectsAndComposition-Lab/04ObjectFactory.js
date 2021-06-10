function solve(library, orders) {
    let objects = [];
    for (const el of orders) {
        // let currObject = {
        //     name: el.template.name
        // };

        let currObject = el.template;

        for (const part of el.parts) {
            currObject[part] = library[part];
        }
        objects.push(currObject);
    }

    return objects;
}


const library = {
    print: function () {
        console.log(`${this.name} is printing a page`);
    },
    scan: function () {
        console.log(`${this.name} is scanning a document`);
    },
    play: function (artist, track) {
        console.log(`${this.name} is playing '${track}' by ${artist}`);
    },
};


const orders = [
    {
        template: { name: 'ACME Printer' },
        parts: ['print']
    },
    {
        template: { name: 'Initech Scanner' },
        parts: ['scan']
    },
    {
        template: { name: 'ComTron Copier' },
        parts: ['scan', 'print']
    },
    {
        template: { name: 'BoomBox Stereo' },
        parts: ['play']
    },
];

const products = solve(library, orders);
console.log(products);

