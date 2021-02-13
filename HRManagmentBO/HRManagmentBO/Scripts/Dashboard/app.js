/// <reference path="../ngDialog.js" />


var dashboardApp = angular.module('dashboardApp', ['ui.bootstrap', 'highcharts-ng', 'ngDialog']);

dashboardApp.service('chartdataService', ['$rootScope', '$http', chartdataService]);

dashboardApp.service('AMLService', function () {
    var AML = {};

    var addAML = function (newObj) {
        AML = newObj;
    };

    var getAML = function () {
        return AML;
    };

    return {
        addAML: addAML,
        getAML: getAML
    };

});

dashboardApp.config(['ngDialogProvider', function (ngDialogProvider) {
    ngDialogProvider.setDefaults({
        className: 'ngdialog-theme-default32',
        plain: false,
        showClose: true,
        closeByDocument: true,
        closeByEscape: true,
        appendTo: false,
        preCloseCallback: function () {
            console.log('default pre-close callback');
        }
    });
}]);

dashboardApp.factory('signalRHubProxy', ['$rootScope', signalRHubProxy]);
dashboardApp.controller('dashboardController', ['$scope','$log', dashboardController]);
dashboardApp.controller('LiveDataCount', ['$scope', 'signalRHubProxy', LiveDataCount]);
//dashboardApp.controller('chartController', ['$scope', '$http', '$log', '$timeout', '$interval', 'chartdataService', 'signalRHubProxy', chartController]);
dashboardApp.controller('piechartController', ['$scope', '$log', '$timeout', piechartController]);
dashboardApp.controller('linechartController', ['$scope', '$log', '$timeout', '$interval', 'chartdataService', linechartController]);
dashboardApp.controller('serverPerformanceController', ['$scope', 'signalRHubProxy', serverPerformanceController]);
dashboardApp.controller('Window', ['$window', window]);




