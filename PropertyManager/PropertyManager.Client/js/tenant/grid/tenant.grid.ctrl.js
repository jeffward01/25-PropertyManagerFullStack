angular.module('app').controller('TenantGridController', function ($scope, Tenant) {

    $scope.tenants = Tenant.query();

    $scope.deleteTenant = function (tenant) {
        if (confirm('Are you sure you want to delete this tenant?')) {
            Tenant.delete({ id: tenant.TenantId }, function (data) {
                var index = $scope.tenants.indexOf(tenant);
                $scope.tenants.splice(index, 1);
            });
        }
    }

});