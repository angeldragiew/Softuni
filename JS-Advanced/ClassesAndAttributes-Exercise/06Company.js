class Company {
    constructor() {
        this.departments = new Map();
    }

    addEmployee(username, salary, position, department) {
        this._validateValue(username);
        this._validateValue(salary);
        if (salary < 0) {
            throw new Error('Invalid input!');
        }
        this._validateValue(position);
        this._validateValue(department);

        let employee = {
            username,
            salary,
            position
        };

        if (this.departments.has(department)) {
            let employees = this.departments.get(department);
            employees.push(employee);
        } else {
            this.departments.set(department, [employee]);
        }

        return `New employee is hired. Name: ${username}. Position: ${position}`;
    }

    bestDepartment() {
        let bestAverageSalary = 0;
        let bestDepartmentName = '';

        for (let [key, value] of this.departments) {
            let currAverageSalary = value.reduce((acc, el) => {
                return acc += el.salary / value.length
            }, 0);
            if (currAverageSalary > bestAverageSalary) {
                bestAverageSalary = currAverageSalary;
                bestDepartmentName = key;
            }
        }

        let result = [`Best Department is: ${bestDepartmentName}`];
        result.push(`Average salary: ${bestAverageSalary.toFixed(2)}`);
        let bestDepartmentEmployees = this.departments.get(bestDepartmentName);
        bestDepartmentEmployees.sort((a, b) => {
            if (b.salary - a.salary !== 0) {
                return b.salary - a.salary
            } else {
                return a.username.localeCompare(b.username);
            }
        });
        for (const e of bestDepartmentEmployees) {
            result.push(`${e.username} ${e.salary} ${e.position}`)
        }
        return result.join('\n');
    }


    _validateValue(value) {
        if (value === '' || value === undefined || value === null) {
            throw new Error('Invalid input!');
        }
    }

}

let c = new Company();
let actual1 = c.addEmployee("Stanimir", 2000, "engineer", "Human resources");
// c.addEmployee("Stanimir", 2000, "engineer", "Construction");
// c.addEmployee("Pesho", 1500, "electrical engineer", "Construction");
// c.addEmployee("Slavi", 500, "dyer", "Construction");
// c.addEmployee("Stan", 2000, "architect", "Construction");
// c.addEmployee("Stanimir", 1200, "digital marketing manager", "Marketing");
// c.addEmployee("Pesho", 1000, "graphical designer", "Marketing");
// c.addEmployee("Gosho", 1350, "HR", "Human resources");
// console.log(c.bestDepartment());

