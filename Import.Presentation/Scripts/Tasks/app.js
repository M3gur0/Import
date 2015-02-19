var app = angular.module("task", ['ngRoute', 'angularFileUpload', 'ui.bootstrap']);


(function () {

    app.config(['$routeProvider', function ($routeProvider) {
        $routeProvider
            .when('/home', {
                templateUrl: '/home/dashboard',
                controller: 'homeController'
            })
            .when('/about', {
                templateUrl: '/home/about',
                controller: 'aboutController'
            })
            .otherwise('/home');
    }]);

    app.controller('homeController', ['$scope', '$http', '$upload', function ($scope, $http, $upload) {
        $scope.max = 100;

        $scope.model = {
            Name: 'File name',
            Type: 'File type'
        };

        $scope.post = function () {
            $scope.upload($scope.files);
        };

        $scope.pendingTask = 0;

        $http.get('/api/task').success(function (data) {
            $scope.pendingTask = data.length;
        });

        $scope.upload = function (files) {
            if (files && files.length) {
                for (var i = 0; i < files.length; i++) {
                    var file = files[i];
                    $upload.upload({
                        url: '/api/task',
                        fields: { 'model': $scope.model },
                        file: file
                    }).progress(function (evt) {
                        $scope.progression = parseInt(100.0 * evt.loaded / evt.total);
                    }).success(function (data, status, headers, config) {
                        $scope.pendingTask = data.pendingTask;

                        //$scope.progression = 0;
                        console.log('file ' + config.file.name + 'uploaded. Response: ' + data);
                    });
                }
            }
        };

    }]);

    app.controller('aboutController', ['$scope', '$http', function ($scope, $http) {
        $scope.pendingTask = 0;

        $http.get('/api/task').success(function (data) {
            $scope.pendingTask = data.length;
        });
    }]);
})();