(function () {

    app.controller('layoutController', ['$scope', function ($scope) {

        $scope.scrollTo = function ($event) {

            var pos = $event.offsetY - $('.page-header').height();
            if (pos) $('html,body').animate({ scrollTop: 0 }, 'slow');

        }

    }]);

})();