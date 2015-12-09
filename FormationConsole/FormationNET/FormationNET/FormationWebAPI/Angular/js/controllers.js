/// <reference path="angular.js" />
/// <reference path="angular-animate.js" />
/// <reference path="angular-route.js" />
/// <reference path="angular-resource.js" />
/// <reference path="services.js" />


(function () {
    var app = angular.module('PhonecatControllers', []);

    //PhonecatControllers.controller("PhoneDetailCtrl", ["$routeParams"], function ($routeParams) { this.phoneId = $routeParams.phoneId; });

    // Remplacer par votre code ici
    app.controller("PhoneListController", ['Phone', function (Phone) {
        this.phones = [];
        this.phones = Phone.query();
        this.orderProp = 'age';
        this.input = '';
    }]);


    app.controller("PhoneController", ['Phone', '$routeParams', 'Basket', function (Phone, $routeParams, Basket) {
        var store = this;
        this.phone = {};
        store.setImage = function (imageUrl) {
            store.mainImageUrl = imageUrl;
        };
        store.email = "james.bond@Mi6.co.uk";

        store.postPhone = function (phoneForm) {
            alert("Phone name : " + phoneForm.phone.name + "\nPhone id : " + phoneForm.phone.id + "\nEditor Email : " + phoneForm.email);
        };
        Phone.get({ phoneId: $routeParams.phoneId }, function (p) {
            store.phone = p;
            store.mainImageUrl = store.phone.images[0];
        });

        /*store.addToBasket(phone) = function (phone) {
            Basket.add(phone);
            alert(Basket.count());
        };*/
    }]);
    // Jusque ici

    app.controller("AboutController", ['Counter', function (Counter) {
            Counter.count();
            this.counter = Counter.getCount();
        }]
    );

})();
