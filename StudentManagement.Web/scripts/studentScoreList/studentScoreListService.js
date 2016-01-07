app.service('studentScoreListService', ["httpProxy", function (httpProxy) {
    var studentScoreListService = {};

    studentScoreListService.create = function (student) {
        return httpProxy.post("api/student/", student);
    };
   
    studentScoreListService.getStudents = function () {
        return httpProxy.get("api/student");
    };
   
    return studentScoreListService;
}]);
