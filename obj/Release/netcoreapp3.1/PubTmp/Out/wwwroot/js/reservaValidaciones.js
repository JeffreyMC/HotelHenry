total();
//Cant de habitacion seleccionada por defecto
document.getElementById("hab").innerHTML = 1;


function total() {

    //cantidad de días
    var dias = document.getElementById("cantDias").value;

    if (dias == "")
        dias = 1;

    //pasa el valor a texbox oculto para luego pasarlo a la bbdd
    document.getElementById("diasTotal").value = dias;


    if (document.getElementById("tipo").value == "1") {
        let estandarAdultos, estandarNinos;
        //se obtienen los precios
        estandarAdultos = document.getElementById("estandarAdultos").innerHTML;
        estandarNinos = document.getElementById("estandarNinos").innerHTML;

        //operaciones
        var mayores = document.getElementById("cantMayores").value;
        var ninos = document.getElementById("cantNinos").value;
        var totalMN = parseInt(((+mayores) + (+ninos)) * estandarNinos);
        var adultos = document.getElementById("cantAdultos").value;
        var totalAdultos = parseInt(adultos * estandarAdultos);
        var total = (totalAdultos + totalMN) * dias;
        document.getElementById("total").innerHTML = total;
        //llena el modal con el total a pagar
        document.getElementById("cost").innerHTML = "$" + total;
        document.getElementById("costoFinal").value = total;
    }
    else if (document.getElementById("tipo").value == "2") {
        let juniorAdultos, juniorNinos;
        //se obtienen los precios
        juniorAdultos = document.getElementById("juniorAdultos").innerHTML;
        juniorNinos = document.getElementById("juniorNinos").innerHTML;

        //operaciones
        var mayores = document.getElementById("cantMayores").value;
        var ninos = document.getElementById("cantNinos").value;
        var totalMN = parseInt(((+mayores) + (+ninos)) * juniorNinos);
        var adultos = document.getElementById("cantAdultos").value;
        var totalAdultos = adultos * juniorAdultos;
        var total = (totalAdultos + totalMN) * dias;
        document.getElementById("total").innerHTML = total;
        //llena el modal con el total a pagar
        document.getElementById("cost").innerHTML = "$" + total;
        document.getElementById("costoFinal").value = total;
    }
    else if (document.getElementById("tipo").value == "3") {
        let deluxeAdultos, deluxeNinos;
        //se obtienen los precios
        deluxeAdultos = document.getElementById("deluxeAdultos").innerHTML;
        deluxeNinos = document.getElementById("deluxeNinos").innerHTML;

        //operaciones
        var mayores = document.getElementById("cantMayores").value;
        var ninos = document.getElementById("cantNinos").value;
        var totalMN = parseInt(((+mayores) + (+ninos)) * deluxeNinos);
        var adultos = document.getElementById("cantAdultos").value;
        var totalAdultos = adultos * deluxeAdultos;
        var total = (totalAdultos + totalMN) * dias;
        document.getElementById("total").innerHTML = total;
        //llena el modal con el total a pagar
        document.getElementById("cost").innerHTML = "$" + total;
        document.getElementById("costoFinal").value = total;
    }


}

//Calcula la cantidad de días
function GetDays() {
    var llegada = new Date(document.getElementById("fechaLlegada").value);
    var salida = new Date(document.getElementById("fechaSalida").value);

    var total = parseInt((salida - llegada) / (24 * 3600 * 1000));

    //si se escoge fechas anteriores envía el error
    if ((llegada || salida) < getFechaHoy()) {
        document.getElementById("fechaLlegada").value = "";
        document.getElementById("fechaSalida").value = "";
        return "No puede ingresar fechas previas";
    }

    if (total < 1) {
        document.getElementById("fechaLlegada").value = "";
        document.getElementById("fechaSalida").value = "";
        return "Ingrese fechas válidas";
    }
    else {
        //llena el modal con la cantidad de días
        document.getElementById("days").innerHTML = total;
        return total;
    }

}

function calcDias() {

    //llama a total para calcular
    if (document.getElementById("fechaLlegada")) {
        document.getElementById("cantDias").value = GetDays();
    }
}

//cada vez que se selecciona la cantidad de habitaciones se actualiza
function cantHab() {
    //llenar el modal con la cantidad de días
    var hab = document.getElementById("opciones").value;
    document.getElementById("hab").innerHTML = hab;
}

//devuelve la fecha del día de hoy
function getFechaHoy() {
    var today = new Date(document.getElementById("hoy").innerHTML);
    return today;

}



