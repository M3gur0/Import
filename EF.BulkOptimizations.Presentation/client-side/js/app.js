var app = angular.module("importApp", ['ngRoute', 'angularFileUpload']);

(function () {

    app.config(['$routeProvider', function ($routeProvider) { 

        $(app).trigger("configureRouting", $routeProvider);
        
    }]);

    app.run(['$rootScope', '$route', function ($rootScope, $route) {

        var offset = 100;
        var duration = 500;

        $rootScope.$on('$routeChangeSuccess', function (newVal, oldVal) {

            $rootScope.title = $route.current.title;

            if (oldVal !== newVal) {
                document.title = 'Sticky notes - ' + $route.current.title;
            }

        });

        $(window).scroll(function () {

            if ($(this).scrollTop() > offset) $('.scroll-to-top').fadeIn(duration);
            else $('.scroll-to-top').fadeOut(duration);

        });

    }]);

})();