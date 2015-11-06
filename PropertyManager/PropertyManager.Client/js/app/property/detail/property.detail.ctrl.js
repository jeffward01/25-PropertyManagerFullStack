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
        if (($('#propertyName').val() === "") || $(('#propertyAddress1').val() === "") || ($('#propertyCity').val() === "") || ($('#propertyState').val() === "") || ($('#propertyZip').val() === "")) {
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
    }
});