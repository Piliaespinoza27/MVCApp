var app = angular.module("App", []); //App emcotrara el angular para disponer de el

app.controller("Materia", function ($scope, $http) { // ejecutara el angular



    $scope.ObtenerAlumnos = function () {
        $http({
            method: 'Post',
            url: '../Materia/ObtenerMateria',
        }).then(function respuesta(r) {
            console.log(r);
            $scope.AlumnosData = r.data;
        });
    }
    $scope.ObtenerMateria();


    $scope.EliminarMateria = function (id) {
        debugger;
        $http({
            method: 'Post',
            url: '../Materia/EliminarMateria',
            data: {
                Id: id
            }
        }).then(function respuesta(r) {
            console.log(r);
            if (r == 0) {
                alert("Registro eliminado");
                $scope.ObtenerMateria();
            }
            else {
                alert("Registro no eliminado");
            }
        });
    }

});