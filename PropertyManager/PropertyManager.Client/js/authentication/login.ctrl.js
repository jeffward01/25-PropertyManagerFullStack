angular.module('app').controller('LoginController', function($scope, $state, authService){
    
    $scope.loginData ={
        username = "",
        password = ""
    };
    
    $scope.message = "";
    
    $scope.login = function(){
        
        authService.login($scope.loginData).then(function(response){
            $state.gp('app.dashboard');
        },
            function(err){
            if(err){
                alert(err.error_description);
            }
        
        });
    }; 
});