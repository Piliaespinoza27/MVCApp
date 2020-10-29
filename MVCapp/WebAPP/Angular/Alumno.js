var app = angular.module("App", []); //App emcotrara el angular para disponer de el

app.controller("Alumno", function ($scope, $http) { // ejecutara el angular

    $scope.ObtenerAlumnos();

    $scope.ObtenerAlumnos = function () {
        $http({
            method: 'Post',
            url: '../Alumno/ObtenerAlumnos',
        }).then(function respuesta(r) {
            console.log(r);
            $scope.AlumnosData = r.data;
        });
    }

});

