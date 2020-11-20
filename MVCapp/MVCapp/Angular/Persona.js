var app = angular.module("App", []); //App emcotrara el angular para disponer de el

app.controller("Persona", function ($scope, $http) { // ejecutara el angular



    $scope.ObtenerPersona = function () {
        $http({
            method: 'Post',
            url: '../Persona/ObtenerPersona',
        }).then(function respuesta(r) {
            console.log(r);
            $scope.PersonasData = r.data;
        });
    }
    $scope.ObtenerPersona();


    $scope.EliminarPersona = function (id) {
        $http({
            method: 'Post',
            url: '../Persona/EliminarPersona',
            data: {
                Id: id
            }
        }).then(function respuesta(r) {
            console.log(r);
            if (r.data == 1) {
                alert("Registro eliminado");
                $scope.ObtenerPersona();
            }
            else {
                alert("Registro no eliminado");
            }
        });
    }

    $scope.AgregarPersona = function () {
        $http({
            method: 'Post',
            url: '../Persona/AgregarPersona',
            data: {
                Id: '',
                Nombres: $scope.Nombres,
                Apellidos: $scope.Apellidos,
                Id_Tipo_Persona: $scope.Id_Tipo_Persona
            }
        }).then(function respuesta(r) {
            console.log(r);
            if (r.data == '1') {
                alert("Registro Agregado");
                $scope.Nombres = '';
                $scope.Apellidos = '';
                $scope.Id_Tipo_Persona = '';
                window.location.href = "../Persona/Index";

            }
            else {
                alert("Registro no Agregado");
            }
        });
    }

    $scope.ObtenerTipoPersona = function () {
        $http({
            method: 'Post',
            url: '../Persona/ObtenerTipoPersona',
        }).then(function respuesta(r) {
            console.log('TipoPersona', r);
            $scope.TipoPersonasData = r.data;
        });
    }

    $scope.ObtenerTipoPersona();


    $scope.SeleccionarPersonaParaModificar = function (i) {
        //  $scope.ObtenerMaterias();
        $scope.mId = i.Id;
        $scope.mNombres = i.Nombres;
        $scope.mApellidos = i.Apellidos;
        $scope.mId_Tipo_Persona = i.Id_Tipo_Persona;
        $('#modalModificar').modal('show');
    }


    $scope.ModificarPersona = function () {
        console.log("snkladjklasjdklasd");
        $http({
            method: 'Post',
            url: '../Persona/ModificarPersona',
            data: {
                Id: $scope.mId,
                Nombres: $scope.mNombres,
                Apellidos: $scope.mApellidos,
                Id_Tipo_Persona: $scope.mId_Tipo_Persona
            }
        }).then(function respuesta(r) {
            console.log(r);
            if (r.data == '1') {
                alert("Registro Modificado");
                $scope.mNombres = '';
                $scope.mApellidos = '';
                $scope.mId_Tipo_Persona = '';
                $scope.ObtenerPersona();
                $('#modalModificar').modal('hide');

            }
            else {
                alert("Registro no Modificado");
            }
        });
    }
});

