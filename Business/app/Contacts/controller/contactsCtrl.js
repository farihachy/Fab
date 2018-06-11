(function (app) {

    'use strict';

    app.controller('contactsCtrl', contactsCtrl);

    contactsCtrl.$inject = ['$scope', 'contactService', 'contactRoleService'];

    function contactsCtrl($scope, contactService, contactRoleService) {

        $scope.model = {};
        $scope.contactRole = [];
        $scope.listContact = [];
        $scope.isFormHidden = false;
        $scope.isUpdate = false;

        init();

        $scope.onSubmit = function (isValid, model) {
            if (isValid) {
                if (!$scope.isUpdate) {
                    contactService.AddNewContact(model).then(function () {
                        alert('Success!!');
                    });
                }
                else {
                    contactService.UpdateContact(model).then(function () {
                        alert('Successfully Updated the data!!');
                    });
                }
                $scope.model = {};
                $scope.contactForm.$setPristine();
                $scope.contactForm.$setUntouched();
            }
            else {
                alert('Some fields are missing or wrong input!');
            }
        };

        function init()
        {
            contactRoleService.GetAllContactRole().then(function (response) {
                $scope.contactRole = response.data;
            });
        }

        $scope.showAllContacts = function () {
            contactService.GetAllContacts().then(function (response) {
                $scope.isFormHidden = true;
                $scope.listContact = response.data;

            });
        };

        $scope.hideContactList = function () {
            $scope.isFormHidden = false;
        };

        $scope.onUpdateContact = function (contact) {
            $scope.model = contact;
            $scope.isFormHidden = !$scope.isFormHidden;
            $scope.isUpdate = true;
        };

        $scope.onDeleteContact = function (contactInfo) {
            var result = confirm('Are you sure you want to delete ' + contactInfo.FirstName + '?');
            if (result) {
                contactService.DeleteContact(contactInfo.Id).then(function () {
                    alert('Data Deleted Successfully!');

                });
            }
        };
    }
})(angular.module('BusinessApp'));