(function () {
   /* myApp = */angular.module('BusinessApp', ['ui.router', 'ui.bootstrap'])

    .config(function ($stateProvider, $locationProvider) {
        var helloState = {
            name: 'hello',
            url: '/hello',
            controller: 'dashBoardCtrl',
            templateUrl: 'app/Home/html/dashboard.html'
        }

        var contacts = {
            name: 'contacts',
            url: '/contacts',
            controller: 'contactsCtrl',
            templateUrl: 'app/Contacts/html/contacts.html'
        }

        var product = {
            name: 'product',
            url: '/product',
            controller: 'productCtrl',
            templateUrl: 'app/Product/html/product.html'
        }

        var productBuy = {
            name: 'productBuy',
            url: '/productBuy',
            controller: 'productBuyCtrl',
            templateUrl: 'app/Product/html/productBuy.html'
        }

        $stateProvider.state(helloState);
        $stateProvider.state(contacts);
        $stateProvider.state(product);
        $stateProvider.state(productBuy);


       // $locationProvider.html5Mode(true);

        $locationProvider.html5Mode({
            enabled: true,
            requireBase: false
        });

    });
})();