angular.module('app', ['ui.router', 'ngResource']).config(function ($stateProvider, $urlRouterProvider) {
    $urlRouterProvider.otherwise('/dashboard');

    $stateProvider
        //If state == dashboard
        .state('dashboard', { url: '/dashboard', templateUrl: '/templates/dashboard/dashboard.html' })


    //If state == property
        .state('property', { abstract: true, url: '/property', template: '<ui-view />' })
            .state('property.grid', { url: '/grid', templateUrl: '/templates/property/grid.html', controller: 'PropertyGridController' })
            .state('property.detail', { url: '/detail/:id', templateUrl: '/templates/property/detail.html', controller: 'PropertyDetailController' })

    //If state == tenants
         .state('tenant', { abstract: true, url: '/tenant', template: '<ui-view />' })
            .state('tenant.grid', { url: '/grid', templateUrl: '/templates/tenant/grid.html', controller: 'TentantGridController' })
            .state('tenant.detail', { url: '/detail/:id', templateUrl: '/templates/tenant/detail.html', controller: 'TentantDetailController' })

    //If state == lease
        .state('lease', { abstract: true, url: '/lease', template: '<ui-view />' })
            .state('tenant.grid', { url: '/grid', templateUrl: '/templates/lease/grid.html', controller: 'LeaseGridController' })
            .state('tenant.detail', { url: '/detail/:id', templateUrl: '/templates/lease/detail.html', controller: 'LeaseDetailController' })
});


angular.module('app').value('apiUrl', 'http://localhost:49803/api/');