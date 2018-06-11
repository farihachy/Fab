(function (app) {

    'use strict';

    app.controller('productCtrl', productCtrl);

    productCtrl.$inject = ['$scope', '$uibModal', 'productService'];

    function productCtrl($scope, $uibModal, productService) {

        $scope.model = {};
        $scope.listProductCategory = [];
        $scope.listProduct = [];
        $scope.isFormHidden = false;
        $scope.isUpdate = false;

        init();

        $scope.onSubmit = function (isValid, model) {
            if (isValid) {
                if (!$scope.isUpdate) {
                    productService.AddNewProduct(model).then(function () {
                        alert('Success!!');
                    });
                }
                else {
                    productService.UpdateProduct(model).then(function () {
                        alert('Successfully Updated the data!!');
                        $scope.isUpdate = false;
                    });
                }
                $scope.model = {};
                $scope.productForm.$setPristine();
                $scope.productForm.$setUntouched();
            }
            else {
                alert('Some fields are missing or wrong input!');
            }
        };

        function init() {
            productService.GetAllProductCategory().then(function (response) {
                $scope.listProductCategory = response.data;
            });
        }

        $scope.showAllProducts = function () {
            productService.GetAllProducts().then(function (response) {
                $scope.isFormHidden = true;
                $scope.listProduct = response.data;
            });
        };


        $scope.hideProductList = function () {
            $scope.isFormHidden = false;
        };

        $scope.onUpdateProduct = function (product) {
            $scope.model = product;
            $scope.isFormHidden = !$scope.isFormHidden;
            $scope.isUpdate = true;
        };

        //$scope.onUpdateProduct = function () {
        //    var modalInstance = $uibModal.open({
        //        templateUrl: "assets/app/templates/modalDialog.html",
        //        controller: "dialogController",
        //        size: "sm",
        //        resolve: {
        //            params: function () {
        //                return {
        //                    name: "John",
        //                    age: 32
        //                };
        //            }
        //        }

        //    });

        //    modalInstance.result.then(function (result) {
        //        $scope.result = result;
        //    }, function () {
        //        console.log("Dialog dismissed");
        //    });
        //};

        $scope.onDeleteProduct = function (productInfo) {
            var result = confirm('Are you sure you want to delete ' + productInfo.Name + '?');
            if (result) {
                productService.DeleteProduct(productInfo.Id).then(function () {
                    alert('Data Deleted Successfully!');

                });
            }
        };
    }
})(angular.module('BusinessApp'));