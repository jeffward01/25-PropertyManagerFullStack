angular.module('app').controller('DashboardController', function ($scope, $state, authService) {



    //Rent Income Count
    $scope.countTo = 10000;
    $scope.countFrom = 0;

    $scope.reCount = function () {
        $scope.countFrom = Math.ceil(Math.random() * 300);
        $scope.countTo = Math.ceil(Math.random() * 7000) -      Math.ceil(Math.random() * 600);
    };

    
    
    
});