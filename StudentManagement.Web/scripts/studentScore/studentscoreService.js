app.service('studentscoreService', ["httpProxy", function (httpProxy) {
    var studentscoreService = {};
    studentscoreService.edit = function (editStudentScoreModel) {
        return httpProxy.put("api/studentscore/", editStudentScoreModel);
    };
    studentscoreService.remove = function (id) {
        return httpProxy.Delete("api/studentscore/" + id);
    };

    studentscoreService.getStudents = function () {
        return httpProxy.get("api/studentscore");
    };
    studentscoreService.getStudentsByName = function (searchStudentScoreModel) {
        return httpProxy.post("api/studentscore/search/", searchStudentScoreModel);
    };
    studentscoreService.getStudentById = function (id) {
        return httpProxy.get("api/student/" + id);
    };
    return studentscoreService;
}]);