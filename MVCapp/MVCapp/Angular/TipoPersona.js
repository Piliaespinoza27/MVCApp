var app = angular.module("App", []); //App emcotrara el angular para disponer de el

app.controller("TipoPersona", function ($scope, $http) { // ejecutara el angular

    

    $scope.ObtenerTipoPersona = function () {
        $http({
            method: 'Post',
            url: '../TipoPersona/ObtenerTipoPersona',
        }).then(function respuesta(r) {
            console.log(r);
            $scope.TipoPersonasData = r.data;
        });
    }
    $scope.ObtenerTipoPersona();


    $scope.EliminarTipoPersona = function (id) {
        $http({
            method: 'Post',
            url: '../TipoPersona/EliminarTipoPersona',
            data: {
                Id: id
            }
        }).then(function respuesta(r) {
            console.log(r);
            if (r.data == 1) {
                alert("Registro eliminado");
                $scope.ObtenerTipoPersona();
            }
            else {
                alert("Registro no eliminado");
            }
        });
    }

    $scope.AgregarTipoPersona = function () {
        $http({
            method: 'Post',
            url: '../TipoPersona/AgregarTipoPersona',
            data: {
                Id: '',
                Nombre: $scope.Nombre
            }
        }).then(function respuesta(r) {
            console.log(r);
            if (r.data == '1') {
                alert("Registro Agregado");
                $scope.Nombre = '';
                $scope.ObtenerTipoPersona();
                window.location.href = "../TipoPersona/Index";

            }
            else {
                alert("Registro no Agregado");
            }
        });
    }




    $scope.SeleccionarTipoPersonaParaModificar = function (i) {

        $scope.mId = i.Id;
        $scope.mNombre = i.Nombre;
        $('#modalModificar').modal('show');
    }

    $scope.ModificarTipoPersona = function () {
        console.log("snkladjklasjdklasd");
        debugger;
        $http({
            method: 'Post',
            url: '../TipoPersona/ModificarTipoPersona',
            data: {
                Id: $scope.mId,
                Nombre: $scope.mNombre
            }
        }).then(function respuesta(r) {
            console.log(r);
            if (r.data == '1') {
                alert("Registro Modificado");
                $scope.mNombre = '';
                $scope.ObtenerTipoPersona();
                $('#modalModificar').modal('hide');
            }
            else {
                alert("Registro no Modificado");
            }
        });

    }

});