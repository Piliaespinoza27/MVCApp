var app = angular.module("App", []); //App emcotrara el angular para disponer de el

app.controller("Modulo", function ($scope, $http) { // ejecutara el angular



    $scope.ObtenerModulo = function () {
        $http({
            method: 'Post',
            url: '../Modulo/ObtenerModulo',
        }).then(function respuesta(r) {
            console.log(r);
            $scope.ModulosData = r.data;
        });
    }
    $scope.ObtenerModulo();


    $scope.EliminarModulo = function (id) {

        $http({
            method: 'Post',
            url: '../Modulo/EliminarModulo',
            data: {
                Id: id
            }
        }).then(function respuesta(r) {
            console.log(r);
            if (r.data == '1') {
                alert("Registro eliminado");
                $scope.ObtenerModulo();
            }
            else {
                alert("Registro no eliminado");
            }
        });
    }


    $scope.AgregarModulo = function () {
        $http({
            method: 'Post',
            url: '../Modulo/AgregarModulo',
            data: {
                Id: '',
                Nombre: $scope.Nombre,
                Id_Persona: $scope.Id_Persona
            }
        }).then(function respuesta(r) {
            console.log(r);
            if (r.data == 1) {
                alert("Registro Agregado");
                $scope.Nombre = '';
                $scope.Id_Persona = '';
                window.location.href = "../Modulo/Index";

            }
            else {
                alert("Registro no Agregado");
            }
        });
    }
    $scope.ObtenerModulo();


    $scope.ObtenerPersona = function () {
        $http({
            method: 'Post',
            url: '../Modulo/ObtenerPersona',
        }).then(function respuesta(r) {
            console.log('Persona', r);
            $scope.PersonasData = r.data;
        });
    }

    $scope.ObtenerPersona();

    $scope.SeleccionarModuloParaModificar = function (i) {
        //  $scope.ObtenerMaterias();
        $scope.mId = i.Id;
        $scope.mNombre = i.Nombre;
        $scope.mId_Persona = i.Id_Persona;
        $('#modalModificar').modal('show');
    }


    $scope.ModificarModulo = function () {
        console.log("snkladjklasjdklasd");
        debugger;
        $http({
            method: 'Post',
            url: '../Modulo/ModificarModulo',
            data: {
                Id: $scope.mId,
                Nombre: $scope.mNombre,
                Id_Persona: $scope.mId_Persona
            }
        }).then(function respuesta(r) {
            console.log(r);
            if (r.data == '1') {
                alert("Registro Modificado");
                $scope.mNombre = '';
                $scope.mId_Persona = '';
                $('#modalModificar').modal('hide');

            }
            else {
                alert("Registro no Modificado");
            }
        });
    }
});
