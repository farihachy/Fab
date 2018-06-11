(function (app) {

    'use strict';

    app.controller('productBuyCtrl', productBuyCtrl);

    productBuyCtrl.$inject = ['$scope', '$uibModal', 'productService'];

    function productBuyCtrl($scope, $uibModal, productService) {

        $scope.model = {};
        $scope.listProductCategory = [];
        $scope.quantity = 0;
        $scope.

        init();

        $scope.onSubmit = function (isValid, model) {
            if (isValid) {
                
            }
            else {
                alert('Some fields are missing or wrong input!');
            }
        };

        $scope.onSelectProductCategory = function (productCategoryId) {
            productService.GetProductsByProductCategory(productCategoryId).then(function (response) {
                $scope.listProduct = response.data;
            });
        };

        function init() {
            productService.GetAllProductCategory().then(function (response) {
                $scope.listProductCategory = response.data;
            });
        }
    }
})(angular.module('BusinessApp'));