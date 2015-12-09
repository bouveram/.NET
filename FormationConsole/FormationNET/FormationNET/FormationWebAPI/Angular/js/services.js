/// <reference path="angular-resource.js" />

var phonecatServices = angular.module('PhonecatServices', ['ngResource']);

phonecatServices.factory('Counter', function() {
	var s = {};              
	var i = 0;
             
	s.count = function() {
		i++;
	};
	
	s.getCount = function() {
		return i;
	}
                    
    return s;
});

phonecatServices.factory('Phone', ['$resource', function ($resource) {
    return $resource('http://localhost:62155/api/phone/:phoneId', {}, {
        query: { method: 'GET', params: { phoneId: 'list' }, isArray: true }
    });
}]);

phonecatServices.value('User', {
	user: {
		firstname: 'Cyril',
		lastname: 'Vincent',
    },
	role: 'admin'
});


var basket = function() {
	this.phones = [];
	
	this.add = function(p) {
		this.phones.push(p);
	}
	
	this.count = function() {
		return this.phones.length;
	}
}

phonecatServices.service('Basket', [basket]);

