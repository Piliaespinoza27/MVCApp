var app = angular.module("App", []); //App emcotrara el angular para disponer de el

app.controller("Materia", function ($scope, $http) { // ejecutara el angular



    $scope.ObtenerMateria = function () {
        $http({
            method: 'Post',
            url: '../Materia/ObtenerMateria',
        }).then(function respuesta(r) {
            console.log(r);
            $scope.MateriaData = r.data;
        });
    }
    $scope.ObtenerMateria();


    $scope.EliminarMateria = function (id) {
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

    $scope.AgregarMateria = function () {
        $http({
            method: 'Post',
            url: '../Materia/AgregarMateria',
            data: {
                Id : '',
                Nombre: $scope.Nombre
            }
        }).then(function respuesta(r) {
            console.log(r);
            if (r.data == '1') {
                alert("Registro Agregado");
                $scope.Nombre = '';
                window.location.href = "../Materia/Index";
               
            }
            else {
                alert("Registro no Agregado");
            }
        });
    }

    $scope.ObtenerMaterias = function () {
        $http({
            method: 'Post',
            url: '../Materia/ObtenerMaterias',
        }).then(function respuesta(r) {
            console.log(r);
            $scope.MateriasData = r.data;
        });
    }

    $scope.ObtenerMaterias();


    $scope.SeleccionarMateriasParaModificar = function (i) {
        //  $scope.ObtenerMaterias();
        $scope.mId = i.Id;
        $scope.mNombre = i.Nombre;
        $('#modalModificar').modal('show');
    }

    $scope.ModificarMateria= function () {
        console.log("snkladjklasjdklasd");
        debugger;
        $http({
            method: 'Post',
            url: '../Materia/ModificarMateria',
            data: {
                Id: $scope.mId,
                Nombre: $scope.mNombre
            }
        }).then(function respuesta(r) {
            console.log(r);
            if (r.data == '1') {
                alert("Registro Modificado");
                $scope.mNombre = '';
                $scope.ObtenerMaterias();
                $('#modalModificar').modal('hide');

            }
            else {
                alert("Registro no Modificado");
            }
        });
    }

});