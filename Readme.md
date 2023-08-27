¿Cuál de estas relaciones considera que se realiza por composición y cuál por
agregación?
Por agregacion: Cadete-Cadeteria, Cadete-Pedidos
Por composcicion: Pedidos-Cliente

¿Qué métodos considera que debería tener la clase Cadetería y la clase Cadete?

La clase cadeteria deberia tener los metodos:
    CambiarEstadoPedido()
    AsignarPedido()
    AgregarPedido()
    AgregarCadete()
    EliminarCadete()
La clase cadete deberia tener los metodos:
    TomarPedido()
    AbandonarPedido()

Teniendo en cuenta los principios de abstracción y ocultamiento, que atributos,
propiedades y métodos deberían ser públicos y cuáles privados.

Deberian ser publicos:
    En cliente: Todos
    En Pedidos: Estado
    En Cadete: Nombre, direccion y telefono
    En cadeteria: Nombre y telefono 

¿Cómo diseñaría los constructores de cada una de las clases?

Para Cliente y cadetería crearía un constructor vacío
Para Pedidos y Cadete crearía un constructor vacío menos en Id y Nro que haría que vaya aumentando en 1 de modo tal que nunca se repitan

¿Se le ocurre otra forma que podría haberse realizado el diseño de clases?
