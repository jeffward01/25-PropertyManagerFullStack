angular.module('app').controller('PropertyDetailController', function ($scope, $stateParams, Property, $state) {

    if ($stateParams.id) {
        $scope.property = Property.get({ id: $stateParams.id });
    } else {
        $scope.property = new Property();
    }

    $scope.saveProperty = function () {

        var successfulCallback = function () {
            $state.go('properties.grid');
        }


        if ($scope.property.PropertyId) {
            $scope.property.$update(successfulCallback);
            
        } else {
            $scope.property.$save(successfulCallback);
        };
    }
});

