function solve(input) {
    let parsedInput = JSON.parse(input);

    let result = [];
    result.push('<table>')
    result.push(makeHeadRow(parsedInput));
    result.push(makeRows(parsedInput));
    result.push('</table>')
    function makeHeadRow(parsedInput) {
        let headRowNames = Object.keys(parsedInput[0]);

        let headRowResult = '<tr>';
        for (let i = 0; i < headRowNames.length; i++) {
            const element = headRowNames[i];
            headRowResult += `<th>${escapeHtml(element)}</th>`;
        }
        return `   ${headRowResult}</tr>`;
    }

    function makeRows(parsedInput) {
        let rowValues = Object.keys(parsedInput[0]);

        let rows = [];
        for (let i = 0; i < parsedInput.length; i++) {
            const currStudentInfo = parsedInput[i];
            let rowResult = '<tr>';
            for (let z = 0; z < rowValues.length; z++) {
                const value = rowValues[z];
                let element = currStudentInfo[value];
                rowResult += `<td>${escapeHtml(element)}</td>`;
            }
            rows.push(`   ${rowResult}</tr>`);
        }
        return rows.join('\n');
    }

    function escapeHtml(value) {
        return value
            .toString()
            .replace(/&/g, '&amp;')
            .replace(/</g, '&lt;')
            .replace(/>/g, '&gt;')
            .replace(/"/g, '&quot;')
            .replace(/'/g, '&#39;');
    }

    return result.join('\n');
}

console.log(solve('[{"Name":"Pesho","Score":4," Grade":8},{"Name":"Gosho","Score":5," Grade":8},{"Name":"Angel","Score":5.50," Grade":10}]'));