El listado de pedidos no puedeestar en cadetes, para ello debemos tener una lista que no pertenece al cadete, para ello ponemos una lista de pedidos en cadeteria.
Colocamos a cadete como un atributo de Pedido
Cadeteria{
    lista cadetes
    lista pedidos
    double Jornal (int index)
    {
        cadetes[index].jornal()
    }
}

NO es bueno dependencia doble ( Ej cadeteria dependa de cadetes y cadetes de pedido)
