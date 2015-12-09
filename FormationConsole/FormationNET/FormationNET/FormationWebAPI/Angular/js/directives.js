(function () {
    var app = angular.module('PhonecatDirectives', ['PhonecatServices']);

    app.directive('phoneItem', function () {
        return {
            restrict: 'E',
            templateUrl: 'views/phone-item-directive.html'
        };
    });

    app.directive('addToBasket', ['Basket', function (Basket) {
        return {
            restrict: 'E',
            templateUrl: 'views/add-to-basket-directive.html',
            controller: function () {
                this.addToBasket = function (phone) {
                    Basket.add(phone);
                    alert(Basket.count());
                };
            },
            controllerAs: 'd'
        }
    }])
})();