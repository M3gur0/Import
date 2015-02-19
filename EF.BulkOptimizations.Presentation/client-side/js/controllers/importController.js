(function () {

    $(app).on('configureRouting', function (e, $routeProvider) {

        $routeProvider.when('/import', {
            templateUrl: '/import/Index',
            controller: 'importController',
            title: 'Import'
        });

    });

    app.controller('importController', ['$scope', '$importService', function ($scope, $importService) {

        $scope.selectedFilename = 'Please select a file...';

        $scope.fileChanged = function ($event) {
            debugger;
            $scope.selectedFilename = $event;
        };

    }]);

})();