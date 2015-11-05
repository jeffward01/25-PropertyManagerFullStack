angular.module('app').controller('RegisterController', function ($scope, $state, authService) {

    $scope.go2login = function () {
        $state.go('login')
    }



    $scope.registerAccount = function () {
        //Validation for registering an account
        if ($('#inputUsername').val() === "" || $('#inputPassword').val() === "" || $('#inputConfirmPassword').val() === "") {
            alert("Please fill in all fields");
            return;
        }
        //if passwords are not the same
        var password1 = $('#inputPassword').val();
        var password2 = $('#inputConfirmPassword').val();   
        if(!(password1 == password2)) {
            $('#inputPassword').val("");
            $('#inputConfirmPassword').val("");      
            alert("Your passwords must match, please confirm and try again.");
            
            return;
           
        }

        authService.saveRegistration($scope.userData).then(function (response) {
                alert("Your login information has beens saved");
                $state.go('login');
            },
            function (err) {
                if (err) {
                    alert(err.error_description);
                }
            })
    }

});