(function () {

    app.service('$importService', ['$http', function ($http) {

        var privateObj = {};

        return {

            post: function (importData) {
                privateObj.Name = "-'s-";
            },
            get: function () {
                return privateObj;
            }
        };

    }]);
    

})();