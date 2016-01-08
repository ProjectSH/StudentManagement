﻿app.controller("dircetiveTestController", ["$scope",
function($scope) {
    $scope.things = [1, 2, 3, 4, 5, 6]; 
    $scope.title = '点击展开';
    $scope.text = '这里是内部的内容。';
}]);
app.directive('hello', function () {
    return {
        restrict: 'E',
        template: '<div>Hi there</div>',
        replace: true
    }
}).directive('two', function () {
    return {
        restrict: 'E',
        template: '<div>Hi there <span ng-transclude><div>123</div></span></div>',
        transclude: true,
        relace:true
    }
}).directive('three', function () {
    return {
        restrict: 'E',
        template: '<div>Hi this is three</div>',
        transclude: true,
        relace: true
    }
}).directive('four', function() {
    return {
        restrict : 'E',
        replace : true,
        transclude : true,
        scope : {
            title : '=fourTitle'
        },
        template : '<div>'
                 + '<div class="title" ng-click="toggle()">{{title}}</div>'
                 + '<div class="body" ng-show="showMe" ng-transclude></div>'
                 + '</div>',
        link : function(scope, element, attrs) {
            scope.showMe = false;
            scope.toggle = function toggle() {
                scope.showMe = !scope.showMe;
            }
        }
    }
}).directive('accordion', function () {
    return {
        restrict: 'EA',
        replace: true,
        transclude: true,
        template: '<div ng-transclude></div>',
        controller: function () {
            var expanders = [];
            this.gotOpened = function (selectedExpander) {
                angular.forEach(expanders, function (expander) {
                    if (selectedExpander != expander) {
                        expander.showMe = false;
                    }
                });
            }
            this.addExpander = function (expander) {
                expanders.push(expander);
            }
        }
    }
}).directive('expander', function() {
    return {
        restrict : 'EA',
        replace : true,
        transclude : true,
        require : '^?accordion',
        scope : {
            title : '=expanderTitle'
        },
        template : '<div>'
                   + '<div class="title" ng-click="toggle()">{{title}}</div>'
                   + '<div class="body" ng-show="showMe" ng-transclude></div>'
                   + '</div>',
        link : function(scope, element, attrs, accordionController) {
            scope.showMe = false;
            accordionController.addExpander(scope);
            scope.toggle = function toggle() {
                scope.showMe = !scope.showMe;
                accordionController.gotOpened(scope);
            }
        }
    }
});
app.controller("fourController", ["$scope",
function ($scope) {
    $scope.title = '点击展开';
    $scope.text = '这里是内部的内容。';
}]);

app.controller("FiveController", function ($scope) {
    $scope.expanders = [{
        title: 'Click me to expand',
        text: 'Hi there folks, I am the content that was hidden but is now shown.'
    }, {
        title: 'Click this',
        text: 'I am even better text than you have seen previously'
    }, {
        title: 'Test',
        text: 'test'
    }];
});

