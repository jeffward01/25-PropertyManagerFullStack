angular.module('app').controller('DashboardController', function ($scope, $state, authService, $http, apiUrl, dashboardService) {






    //Properties Information 



    dashboardService.get().then(
        function (data) {
            // callback from deferred.resolve
            // bind data now!

            $scope.dashboard = data;

            //Rent Income Count
            $scope.countTo = $scope.dashboard.TotalMonthlyIncome;
            $scope.countFrom = 0;

            $scope.reCount = function () {
                $scope.countFrom = Math.ceil(Math.random() * 300);
                $scope.countTo = Math.ceil(Math.random() * 7000) - Math.ceil(Math.random() * 600);
            };





        },
        function (error) {
            // callback from deferred.reject
            // show sad faces :(
        }
    );
    
    //Need to calulcate percetange based on Date
    function getPercentage(){

        

  
        
        
        
    }
});