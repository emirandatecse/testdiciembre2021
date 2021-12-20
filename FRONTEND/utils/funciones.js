export default class Funciones {
    static FechaActual(){
        var fecha = new Date();
        const fechaString = fecha.toISOString().slice(0,10).replace(/-/g,"");
        return fechaString;
    }
}