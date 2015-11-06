angular.module('app').controller('PropertyDetailController', function ($scope, $stateParams, Property, $state) {

    if ($stateParams.id) {
        $scope.property = Property.get({
            id: $stateParams.id
        });
    } else {
        $scope.property = new Property();
    }

    $scope.saveProperty = function () {
        //Validation
        if (($('#propertyName').val() === "")  || ($('#propertyCity').val() === "") || ($('#propertyState').val() === "") || ($('#propertyZip').val() === "")) {
            alert("Please enter all required fields");
            return false;
        }


        //Success Callback and Change of state
        var successfulCallback = function () {
            $state.go('app.property.grid');
        }


        if ($scope.property.PropertyId) {
            $scope.property.$update(successfulCallback);

        } else {
            $scope.property.$save(successfulCallback);
        };
        toastr.success('Property was added!', 'New Property was Saved!');
    }
});