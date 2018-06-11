(function (app) {

    'use strict';

    app.service('contactService', contactService);

    contactService.$inject = ['$http'];

    function contactService($http) {

        var urlBase = "/api/contact";

        this.GetAllContacts = function () {

            return $http.get(urlBase + '/GetAllContacts');
        };

        this.AddNewContact = function (contactInfo) {

            return $http.post(urlBase + '/AddNewContact' , contactInfo);
        };

        this.UpdateContact = function (contactInfo) {

            return $http.put(urlBase + '/UpdateContact' , contactInfo);
        };

        this.DeleteContact = function (id) {
            return $http.delete(urlBase + '/DeleteContact/' + id);
        };
    }
})(angular.module('BusinessApp'));
