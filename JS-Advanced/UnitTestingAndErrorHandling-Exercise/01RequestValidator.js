function requestValidator(obj) {
    validateMethod(obj);
    validateUri(obj);
    validateVersion(obj);
    validateMessage(obj);

    function validateMethod(obj) {
        let validMethods = ['GET', 'POST', 'DELETE', 'CONNECT'];
        if (!obj.hasOwnProperty('method') || !validMethods.includes(obj.method)) {
            throw new Error('Invalid request header: Invalid Method');
        }
    }

    function validateUri(obj) {
        let regex = /^\*$|^([A-Za-z.0-9]+)$/;
        if (!obj.hasOwnProperty('uri') || regex.test(obj.uri) === false) {
            throw new Error('Invalid request header: Invalid URI')
        }
    }

    function validateVersion(obj) {
        let validVersions = ['HTTP/0.9', 'HTTP/1.0', 'HTTP/1.1', 'HTTP/2.0'];
        if (!obj.hasOwnProperty('version') || !validVersions.includes(obj.version)) {
            throw new Error('Invalid request header: Invalid Version');
        }
    }

    function validateMessage(obj) {
        let regex = /^[^<>\\&'"]*$/;
        if (!obj.hasOwnProperty('message') || regex.test(obj.message) === false) {
            throw new Error('Invalid request header: Invalid Message')
        }
    }
    return obj;
}

console.log(requestValidator(
    {
        method: 'GET',
        uri: 'svn.public.catalog',
        version: 'HTTP/1.1',
        message: ''
    }

));