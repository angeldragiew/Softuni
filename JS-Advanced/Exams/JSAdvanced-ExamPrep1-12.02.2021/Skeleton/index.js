function solve() {
    let buttonElement = document.querySelector('.form-control button');

    buttonElement.addEventListener('click', (e) => {
        e.preventDefault();
        let lectureNameElement = document.querySelector('input[name="lecture-name"]');
        let lectureDateElement = document.querySelector('input[name="lecture-date"]');
        let lectureModuleElement = document.querySelector('select[name="lecture-module"]');

        if (lectureDateElement.value === '' || lectureDateElement.value === null ||
            lectureNameElement.value === '' || lectureNameElement === null ||
            lectureModuleElement.value === 'Select module') {
        } else {
            let [date, hour] = lectureDateElement.value.split('T');
            date = date.split('-').join('/');
            let lectureName = lectureNameElement.value;
            let moduleName = lectureModuleElement.value;

            addLecture(moduleName, lectureName, date, hour);
        }

    });


    function addLecture(moduleName, lectureName, date, hour) {
        let modulesElementsArray = Array.from(document.querySelectorAll('.module'));
        let divElement;
        let isNewDiv = true;

        if (modulesElementsArray.some(e => e.textContent.includes(moduleName.toUpperCase() + '-MODULE'))) {
            divElement = modulesElementsArray.find(e => e.textContent.includes(moduleName.toUpperCase() + '-MODULE'));
            isNewDiv = false;
        } else {
            divElement = document.createElement('div');
            divElement.classList.add('module');
            let h3Element = document.createElement('h3');
            h3Element.textContent = moduleName.toUpperCase() + '-MODULE';
            divElement.appendChild(h3Element);
        }

        let ulElement = document.createElement('ul');

        let liElement = document.createElement('li');
        liElement.classList.add('flex');

        let h4Element = document.createElement('h4');
        h4Element.textContent = `${lectureName} - ${date} - ${hour}`;
        liElement.appendChild(h4Element);

        let delButtonElement = document.createElement('button');
        delButtonElement.classList.add('red');
        delButtonElement.textContent = 'Del';
        delButtonElement.addEventListener('click', (e) => {
            let deleteElement = e.target.parentElement.parentElement.parentElement;
            let currModuleElement = e.target.parentElement.parentElement;
            if (deleteElement.children.length === 2) {
                deleteElement.remove();
            } else {
                currModuleElement.remove();
            }
        });
        liElement.appendChild(delButtonElement);

        ulElement.appendChild(liElement);

        divElement.appendChild(ulElement);
        if (isNewDiv) {
            let modulesDivElement = document.querySelector('.modules');
            modulesDivElement.appendChild(divElement);
        }
        sortDates();
    }

    function sortDates() {
        let allModules = document.querySelectorAll('.module');

        for (const currModule of allModules) {
            let lecturesArr = Array.from(currModule.querySelectorAll('ul'));

            lecturesArr.sort((a, b) => {
                let aInfo = a.querySelector('h4');
                let bInfo = b.querySelector('h4');

                let [aname, aDate] = aInfo.textContent.split(' - ');
                let [bname, bDate] = bInfo.textContent.split(' - ');

                return aDate.localeCompare(bDate);
            });

            for (const lecture of lecturesArr) {
                currModule.appendChild(lecture);
            }
        }


    }
};