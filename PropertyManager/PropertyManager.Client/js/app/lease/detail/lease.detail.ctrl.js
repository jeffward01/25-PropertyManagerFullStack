angular.module('app').controller('LeaseDetailController', function ($scope, $stateParams, Lease, Property, Tenant, $state) {

    $scope.tenants = Tenant.query();
    $scope.properties = Property.query();

    // If an ID was passed to state, then a lease is being edited: get the lease to update
    //  otherwise a lease is being added: create a new lease
    if ($stateParams.id) {
        $scope.lease = Lease.get({
            id: $stateParams.id
        });
    } else {
        $scope.lease = new Lease();
    }

    // Save lease:
    // If an ID was passed to state, then a lease is being edited: update the lease
    //  otherwise a lease is being added: save the lease
    // After updating or saving, change state to leases.list
    $scope.saveLease = function () {

        if (($('#leaseProperty').val() === "") || ($('#leaseTenant').val() === "") || ($('#leaseStartDate').val() === "") || ($('#leaseRent').val() === "")) {
            alert("Please enter all fields required fields");
            return false;
        }


        var successCallback = function () {
            $state.go('app.lease.grid');
        };

        $scope.lease.LeaseType = 2;
        if ($scope.lease.LeaseId) {
            $scope.lease.$update(successCallback);
        } else {
            $scope.lease.$save(successCallback);
        }
    };

    $('#leaseStartDate').datepicker({
        format: "mm/dd/yyyy"
    });

    $('#leaseEndDate').datepicker({
        format: "mm/dd/yyyy"
    });

});