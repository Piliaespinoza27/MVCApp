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
            if (r.data == '1') {
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
                Fk_Materia: $scope.Fk_Materia
            }
        }).then(function respuesta(r) {
            console.log(r);
            if (r.data == '1') {
                alert("Registro Agregado");
                $scope.Nombre = '';
                $scope.Apellido = '';
                $scope.Edad = '';
                $scope.Fk_Materia = '';
                window.location.href = "../Alumno/Index";
               
            }
            else {
                alert("Registro no Agregado");
            }
        });
    }

    $scope.ObtenerMaterias = function () {
        $http({
            method: 'Post',
            url: '../Alumno/ObtenerMaterias',
        }).then(function respuesta(r) {
            console.log(r);
            $scope.MateriasData = r.data;
        });
    }

    $scope.ObtenerMaterias();


    $scope.SeleccionarAlumnosParaModificar = function (i) {
      //  $scope.ObtenerMaterias();
        $scope.mId = i.Id;
        $scope.mNombre = i.Nombre;
        $scope.mApellido = i.Apellido;
        $scope.mEdad = i.Edad;
        $scope.mFk_Materia = i.Fk_Materia;
        $('#modalModificar').modal('show');
    }

});

