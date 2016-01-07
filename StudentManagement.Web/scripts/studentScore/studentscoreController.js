app.controller("studentscoreController", [
    "$scope", '$window', "$rootScope", "$modal", "$location", "studentscoreService", "ipCookie",
    function($scope, $window, $rootScope, $modal, $location, studentscoreService, ipCookie) {
        $scope.dataLoaded = false;
        $scope.dataUpdating = false;
        $scope.searchFirstName = "";
        $scope.searchLastName = "";
        $scope.studentScores = {};
        $scope.dataListShowLoading = false;
        $rootScope.currentPage = $location.path().replace("/", "");

        function getAllData() {
            $scope.dataListShowLoading = true;
            studentscoreService.getStudents().then(function(data) {
                $scope.dataListShowLoading = false;
                $scope.studentScores = data;
            });
        }

        getAllData();

        $scope.searchStudentScore = function() {
            if ($scope.searchFirstName === "" && $scope.searchLastName === "") {
                return;
            }
            var searchStudent = new searchStudentScoreModel($scope.searchFirstName, $scope.searchLastName);
            studentscoreService.getStudentsByName(searchStudent).then(function(data) {
                $scope.dataListShowLoading = false;
                $scope.studentScores = data;
            });
        }

        $scope.deleteStudentScore = function(studentScore) {

            var deleteStudentScore = $modal.open({
                templateUrl: 'deleteStudentScoreModal',
                controller: deleteStudentScoreCtrl,
                backdrop: 'static',
                resolve: { studentScore: function() { return studentScore; } }
            });

            deleteStudentScore.result.then(function(s) {
                getAllData();
            }, function(error) {

            });
        };

        var deleteStudentScoreCtrl = [
            "$scope", "$rootScope", "$modalInstance", "studentscoreService", "studentScore",
            function($scope, $rootScope, $modalInstance, studentscoreService, studentScore) {
                $scope.deleteStudentScore = studentScore;
                $scope.isUpdating = false;
                $scope.ok = function() {
                    $scope.isUpdating = true;
                    studentscoreService.remove(studentScore.Id).then(function() {
                        studentScore.Deleted = true;
                        $modalInstance.close(studentScore);
                    });
                };

                $scope.cancel = function() {
                    $modalInstance.dismiss();
                };
            }
        ];



        $scope.editStudentScore=function(studentScore) {
            var studentScoreCopy = new EditStudentScoreModel(studentScore);
            var editStudentScore = $modal.open({
                templateUrl: 'studentScoreModal',
                controller: editStudentScoreCtrl,
                backdrop: 'staic',
                resolve:{studentScore: function() { return studentScoreCopy; } }
            });
            editStudentScore.result.then(function(s) {
                    getAllData();
                }, function(error) {}
            );
        }

        var editStudentScoreCtrl = ["$scope", "$rootScope", "$modalInstance", "studentscoreService", "studentScore",
            function ($scope, $rootScope, $modalInstance, studentscoreService, studentScore) {
                $scope.editStudentScore = studentScore;
                $scope.studentScore = angular.copy(studentScore);
                $.isUpdating = false;
                $scope.ok=function() {
                    $scope.isUpdating = true;
                    studentscoreService.edit($scope.studentScore).then(function () {
                        $modalInstance.close();
                    }, function (error) {
                        $scope.isUpdating = false;
                    });
                }
                $scope.cancel = function () {
                    $modalInstance.dismiss();
                };
            }
        ];

        function searchStudentScoreModel(firstName, lastName) {
            return {
                FirstName: firstName,
                LastName: lastName
            };
        }


        function EditStudentScoreModel(studentScore) {
            return {
                Id: studentScore.Id,
                Course: studentScore.Course,
                Score: studentScore.Score,
                ExamTime: studentScore.ExamTime,
                StudentId:studentScore.Student.Id
            }
        }
    }
]);