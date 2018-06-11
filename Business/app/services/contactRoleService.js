(function (app) {

    'use strict';

    app.service('contactRoleService', contactRoleService);

    contactRoleService.$inject = ['$http'];

    function contactRoleService($http) {

        var urlBase = "/api/contactRole/";

        this.GetAllContactRole = function () {

            return $http.get(urlBase + 'GetAllContactRole');
        };
    }
})(angular.module('BusinessApp'));
