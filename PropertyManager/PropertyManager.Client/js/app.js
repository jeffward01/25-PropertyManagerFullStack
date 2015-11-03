angular.module('app', ['ui.router', 'ngResource', 'ngRoute', 'angular-loading-bar']).config(function ($stateProvider, $urlRouterProvider) {
    $urlRouterProvider.otherwise('/dashboard');

    $stateProvider
        //If state == dashboard
      //  .state('dashboard', { url: '/dashboard', templateUrl: '/templates/dashboard/dashboard.html' })


       //If state == property
        .state('property', { abstract: true, url: '/property', template: '<ui-view />' })
            .state('property.grid', { url: '/grid', templateUrl: '/templates/property/grid.html', controller: 'PropertyGridController' })
            .state('property.detail', { url: '/detail/:id', templateUrl: '/templates/property/detail.html', controller: 'PropertyDetailController' })

       //If state == tenants
         .state('tenant', { abstract: true, url: '/tenant', template: '<ui-view />' })
            .state('tenant.grid', { url: '/grid', templateUrl: '/templates/tenant/grid.html', controller: 'TenantGridController' })
            .state('tenant.detail', { url: '/detail/:id', templateUrl: '/templates/tenant/detail.html', controller: 'TenantDetailController' })

       //If state == lease
        .state('lease', { abstract: true, url: '/lease', template: '<ui-view />' })
            .state('lease.grid', { url: '/grid', templateUrl: '/templates/lease/grid.html', controller: 'LeaseGridController' })
            .state('lease.detail', { url: '/detail/:id', templateUrl: '/templates/lease/detail.html', controller: 'LeaseDetailController' })
});


angular.module('app').value('apiUrl', 'http://localhost:59964/api/');

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
