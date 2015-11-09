angular.module('app', ['ui.router', 'ngResource', 'ngRoute', 'angular-loading-bar', 'LocalStorageModule', 'countTo', 'ngMaterial']).config(function ($stateProvider, $httpProvider, $urlRouterProvider) {
    $httpProvider.interceptors.push('authInterceptorService');
    
    $urlRouterProvider.otherwise('/login');

    $stateProvider
        .state('login', {url:'/login', templateUrl: '/templates/authentication/login.html', controller: 'LoginController'})
        .state('register', {url : '/register', templateUrl: '/templates/authentication/register.html', controller: 'RegisterController'})
       
        
        .state('app', {url: '/app', templateUrl: '/templates/app/app.html', authenticate: true, controller: 'AppController'})
            .state('app.dashboard', {url: '/dashboard', templateUrl: '/templates/app/dashboard/dashboard.html', authenticate: true, controller: 'DashboardController'})
    
       //If state == property
        .state('app.property', { abstract: true, url: '/property', template: '<ui-view />', authenticate: true })
            .state('app.property.grid', { url: '/grid', templateUrl: '/templates/app/property/grid.html', controller: 'PropertyGridController' })
            .state('app.property.detail', { url: '/detail/:id', templateUrl: '/templates/app/property/detail.html', controller: 'PropertyDetailController' })

       //If state == tenants
         .state('app.tenant', { abstract: true, url: '/tenant', template: '<ui-view />', authenticate: true })
            .state('app.tenant.grid', { url: '/grid', templateUrl: '/templates/app/tenant/grid.html', controller: 'TenantGridController' })
            .state('app.tenant.detail', { url: '/detail/:id', templateUrl: '/templates/app/tenant/detail.html', controller: 'TenantDetailController' })

       //If state == lease
        .state('app.lease', { abstract: true, url: '/lease', template: '<ui-view />', authenticate: true })
            .state('app.lease.grid', { url: '/grid', templateUrl: '/templates/app/lease/grid.html', controller: 'LeaseGridController' })
            .state('app.lease.detail', { url: '/detail/:id', templateUrl: '/templates/app/lease/detail.html', controller: 'LeaseDetailController' })
});

//Web Server Address
angular.module('app').value('apiUrl', 'http://localhost:59964/api/');

angular.module('app').value('serviceUrl', 'http://localhost:59964/');

//Run block
angular.module('app').run(function ($rootScope, authService, $state){
    authService.fillAuthData();
    
    $rootScope.$on("$stateChangeStart", function (event, toState, toParams, fromState, fromParams){
        if(toState.authenticate && !authService.authentication.isAuth){
            $state.go('login');
            event.preventDefault();
        }
    })
});

//Telephone Filter Code
angular.module('ng').filter('tel', function () {
    return function (tel) {
        if (!tel) { return ''; }

        var value = tel.toString().trim().replace(/^\+/, '');

        if (value.match(/[^0-9]/)) {
            return tel;
        }

        var country, city, number;

        switch (value.length) {
            case 10: // +1PPP####### -> C (PPP) ###-####
                country = 1;
                city = value.slice(0, 3);
                number = value.slice(3);
                break;

            case 11: // +CPPP####### -> CCC (PP) ###-####
                country = value[0];
                city = value.slice(1, 4);
                number = value.slice(4);
                break;

            case 12: // +CCCPP####### -> CCC (PP) ###-####
                country = value.slice(0, 3);
                city = value.slice(3, 5);
                number = value.slice(5);
                break;

            default:
                return tel;
        }

        if (country == 1) {
            country = "";
        }

        number = number.slice(0, 3) + '-' + number.slice(3);

        return (country + " (" + city + ") " + number).trim();
    };
});
