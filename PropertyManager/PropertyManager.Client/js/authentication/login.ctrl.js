angular.module('app').controller('LoginController', function ($scope, $state, authService) {

    //Login Information
    $scope.loginData = {
        username: "",
        password: ""
    };

    $scope.message = "";

    $scope.login = function () {

        authService.login($scope.loginData).then(function (response) {
                $state.go('app.dashboard');
            },
            function (err) {
                if (err) {
                    alert(err.error_description);
                }

            });
    };

    $scope.CreateAccount = function () {
        $state.go('register');
    }
});