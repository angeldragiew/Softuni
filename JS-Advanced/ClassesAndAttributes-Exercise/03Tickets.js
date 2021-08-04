function solve(arr, sorter) {
    class Ticket {
        constructor(destination, price, status) {
            this.destination = destination;
            this.price = Number(price);
            this.status = status;
        }


    }

    let allTickets = [];
    for (const currTicket of arr) {
        let [destination, price, status] = currTicket.split('|');
        allTickets.push(new Ticket(destination, price, status));
    }

    if (sorter === 'destination') {
        return allTickets.sort((a, b) => a.destination.localeCompare(b.destination));
    } else if (sorter === 'price') {
        return allTickets.sort((a, b) => a.price - b.price);
    }
    else if (sorter === 'status') {
        return allTickets.sort((a, b) => a.status.localeCompare(b.status));
    }
}

console.log(solve(['Philadelphia|94.20|available',
    'New York City|95.99|available',
    'New York City|95.99|sold',
    'Boston|126.20|departed'],
    'status'
));