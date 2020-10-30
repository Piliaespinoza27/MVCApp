var app = angular.module("App", []); //App emcotrara el angular para disponer de el

app.controller("Alumno", function ($scope, $http) { // ejecutara el angular

    

    $scope.ObtenerAlumnos = function () {
        $http({
            method: 'Post',
            url: '../Alumno/ObtenerAlumnos',
        }).then(function respuesta(r) {
            console.log(r);
            $scope.AlumnosData = r.data;
        });
    }
    $scope.ObtenerAlumnos();


    $scope.EliminarAlumnos = function (id) {

        $http({
            method: 'Post',
            url: '../Alumno/EliminarAlumnos',
            data: {
                Id:id
            }
        }).then(function respuesta(r) {
            console.log(r);
            if (r == 0) {
                alert("Registro eliminado");
                $scope.ObtenerAlumnos();
            }
            else {
                alert("Registro no eliminado");
            }
        });
    }


    $scope.AgregarAlumnos = function () {
        $http({
            method: 'Post',
            url: '../Alumno/AgregarAlumnos',
            data: {
                Id : '',
                Nombre: $scope.Nombre,
                Apellido: $scope.Apellido,
                Edad: $scope.Edad,
                Fk_Materia: $scope.Materia,
            }
        }).then(function respuesta(r) {
            console.log(r);
            if (r == 0) {
                alert("Registro Agregado");
               
            }
            else {
                alert("Registro no Agregado");
            }
        });
    }

});

