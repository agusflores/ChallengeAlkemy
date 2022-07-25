# ChallengeAlkemy

Proyecto de API REST del Challenge de ingreso a la aceleracion de Alkemy

Bienvenido a mi proyecto del challenge de ingreso de Alkemy.

En este implemente el modelo de Code First para modelar la base de datos. El modelo de dominio esta compuesto por Personaje, Serie, Genero y una clase de relacion de tablas Many to many llamada PersonajeSerie.

Luego en la base de datos cargue 7 valores en la tabla de Genero para utilizarlos dentro del proyecto ya que, para crear una serie y asignarle un genero, este ya debe existir.

La logica presentada consiste en primero crear los generos, luego la serie y luego los personajes. Estos ultimos dos tienen sus operaciones de creacion, edicion y eliminacion, busqueda con parametros de query de sus atributos y tambien utilizando HttpGet muestro el listado de los personajes y/o series ya existentes.

Tambien cree la autenticacion de Usuarios tanto para logearse como para registrar nuevos.
