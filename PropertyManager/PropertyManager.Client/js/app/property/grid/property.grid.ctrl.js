angular.module('app').controller('PropertyGridController', function ($scope, Property) {
    $scope.properties = Property.query();

    $scope.deleteProperty = function (property) {

        if (confirm("are you sure you want to delete this property?  This cannot be undone.")) {
            Property.delete({ id: property.PropertyId }, function (data) {
                var index = $scope.properties.indexOf(property);
                $scope.properties.splice(index, 1);
            });
        }
                toastr.error('Property entry was erased!', 'Property Erased!');

    }




});