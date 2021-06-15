function solve() {
   document.querySelector('#btnSend').addEventListener('click', onClick);

   function onClick() {
      let input = JSON.parse(document.querySelector('#inputs textarea').value);

      let restaurants = {};
      for (let i = 0; i < input.length; i++) {
         let inputSplitted = input[i].split(' - ');
         let restaurantName = inputSplitted[0];
         let workers = inputSplitted[1]
            .split(', ')
            .map(x => {
               workerInfo = x.split(' ');
               return x = {
                  name: workerInfo[0],
                  salary: Number(workerInfo[1])
               };
            });

         if (!restaurants[restaurantName]) {
            restaurants[restaurantName] = {};
         }
         for (const worker of workers) {
            if (!restaurants[restaurantName][worker.name]) {
               restaurants[restaurantName][worker.name] = worker;
            }

         }
      }
      let bestAverageSalary = 0;
      let bestRestaurant = '';
      for (const key in restaurants) {
         let totalSalary = 0;
         let count = 0;
         for (const worker in restaurants[key]) {
            totalSalary += restaurants[key][worker].salary;
            count++;
         }
         if (bestAverageSalary < (totalSalary / count)) {
            bestAverageSalary = totalSalary / count
            bestRestaurant = key;
         }
      }

      let bestRestaurantWorkers = Object.values(restaurants[bestRestaurant]);
      bestRestaurantWorkers.sort((a, b) => b.salary - a.salary);
      let bestSalary = bestRestaurantWorkers[0].salary;

      let bestRestaurantElement = document.querySelector('#bestRestaurant p');
      bestRestaurantElement.textContent =
         `Name: ${bestRestaurant} Average Salary: ${bestAverageSalary.toFixed(2)} Best Salary: ${bestSalary.toFixed(2)}`;

      let workersElement = document.querySelector('#workers p');
      workersElement.textContent = bestRestaurantWorkers.map(x => `Name: ${x.name} With Salary: ${x.salary}`).join(' ');
   }
}