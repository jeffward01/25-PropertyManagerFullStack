angular.module('app').factory('Property', function ($resource, apiUrl) {

    

    return $resource(apiUrl + 'properties/:id', { id: '@PropertyId' }, {
        update: {
            method: 'PUT'
        }
    });
});