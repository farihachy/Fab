(function (app) {

    'use strict';

    app.service('productService', productService);

    productService.$inject = ['$http'];

    function productService($http) {

        var urlBase = "/api/product";

        this.GetAllProductCategory = function () {

            return $http.get(urlBase + '/GetAllProductCategory');
        };

        this.GetAllProducts = function () {

            return $http.get(urlBase + '/GetAllProducts');
        };

        this.AddNewProduct = function (productInfo) {

            return $http.post(urlBase + '/AddNewProduct', productInfo);
        };

        this.UpdateProduct = function (productInfo) {

            return $http.put(urlBase + '/UpdateProduct', productInfo);
        };

        this.DeleteProduct = function (id) {
            return $http.delete(urlBase + '/DeleteProduct/' + id);
        };

        /*Product Buy Services*/
        this.GetProductsByProductCategory = function (productCategoryId) {

            return $http.get(urlBase + '/GetProductsByProductCategory/' + productCategoryId);
        };

        /*Product Sell Services*/
    }
})(angular.module('BusinessApp'));
