app.controller("studentScoreListController", [
    "$scope", '$window', "$rootScope", "$modal", "$location", "studentService", "ipCookie",
    function($scope, $window, $rootScope, $modal, $location, studentService, ipCookie) {

        $scope.dataLoaded = false;
        $scope.dataUpdating = false;
   
        $scope.students = {};
        $scope.dataListShowLoading = false;
        $rootScope.currentPage = $location.path().replace("/", "");

        function getAllData() {
            $scope.dataListShowLoading = true;
            studentService.getStudents().then(function(data) {
                $scope.dataListShowLoading = false;
                $scope.students = data;
            });
        }

        getAllData();
    }
]);