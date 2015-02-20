(function () {

    $(app).on('configureRouting', function (e, $routeProvider) {

        var homeParamters = {
            templateUrl: '/home/dashboard',
            controller: 'homeController',
            title: "bienvenue."
        };

        $routeProvider
            .when('/', homeParamters)
            .when('/home', homeParamters)
            .when('/index', homeParamters)
            .when('/dashboard', homeParamters);

    });

    app.controller('homeController', ['$scope', function ($scope) {



    }]);

})();