﻿(function () {

    $(app).on('configureRouting', function (e, $routeProvider) {

        $routeProvider
            .when('/about', {
                templateUrl: '/home/about',
                controller: 'aboutController',
                title: 'about.'
            });

    });

    app.controller('aboutController', ['$scope', function ($scope) {



    }]);

})();