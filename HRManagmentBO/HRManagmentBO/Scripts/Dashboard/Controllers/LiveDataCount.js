var LiveDataCount = function ($scope, signalRHubProxy) {

    $scope.LiveDataCount = {
        NewlyRegistered: '...',
        SubscribedCustomers: '...',
        TopRatedCustomers: '...',
        PendingToApprove:'...'
    };

    var clientPushHubProxy = signalRHubProxy(
       signalRHubProxy.defaultServer, 'MyHub',
           { logging: true });

    clientPushHubProxy.on('LiveDataCount', function (data) {
        $scope.LiveDataCount = data;
        var x = clientPushHubProxy.connection.id;
    });

};