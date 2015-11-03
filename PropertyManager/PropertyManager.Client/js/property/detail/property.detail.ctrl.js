angular.module('app').controller('PropertyDetailController', function ($scope, $stateParams, Property, $state) {

    if ($stateParams.id) {
        $scope.property = Property.get({ id: $stateParams.id });
    } else {
        $scope.property = new Property();
    }

    $scope.saveProperty = function () {
        if ($scope.property.PropertyId) {
            $scope.property.$update(function () {
                $state.go('property.grid');
            });
        } else {
            $scope.property.$save(function () {
                $state.go('property.grid');
            });
        }
    }

});