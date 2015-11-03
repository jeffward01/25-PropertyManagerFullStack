angular.module('app').factory('Lease', function ($resource, apiUrl) {
    return $resource(apiUrl + 'leases/:id', { id: '@LeaseId' }, {
        update: {
            method: 'PUT'
        }
    });
});