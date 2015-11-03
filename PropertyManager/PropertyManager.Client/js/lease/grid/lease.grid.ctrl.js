angular.module('app').controller('LeaseGridController', function ($scope, Lease, Property, Tenant) {

    $scope.leases = Lease.query();

    $scope.deleteLease = function (lease) {
        if (confirm('Are you sure you want to delete this lease?')) {
            Lease.delete({ id: lease.LeaseId }, function (data) {
                var index = $scope.leases.indexOf(lease);
                $scope.leases.splice(index, 1);
            });
        }
    }


});