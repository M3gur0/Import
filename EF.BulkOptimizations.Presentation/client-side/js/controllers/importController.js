(function () {

    $(app).on('configureRouting', function (e, $routeProvider) {

        $routeProvider.when('/import', {
            templateUrl: '/import/Index',
            controller: 'importController',
            title: 'import.'
        });

    });

    app.controller('importController', ['$scope', '$importService', '$upload', function ($scope, $importService, $upload) {

        $scope.model = {
            SpeciesId: 1,
            YearId: 11,
            CampaignId: 4,
            PublicationDate: new Date(2013, 9, 22, 0,0,0,0),
            SourceId: 1,
            VariableId: 1,
            UnitId : 1,
            SelectedFilename : ''
        };

        $scope.upload = function () {

            if ($scope.file && $scope.file.length == 1) {

                var file = $scope.file[0];

                $upload.upload({
                    url: '/api/import',
                    fields: { 'model': $scope.model },
                    file: file
                }).progress(function (evt) {
                    $scope.progression = parseInt(100.0 * evt.loaded / evt.total);
                }).success(function (data, status, headers, config) {
                    $scope.pendingTask = data.pendingTask;
                    console.log('file ' + config.file.name + 'uploaded. Response: ' + data);
                });

            }

        };

        $scope.$watch('file', function () {

            if ($scope.file) $scope.model.SelectedFilename = $scope.file[0].name;

        });

    }]);

})();