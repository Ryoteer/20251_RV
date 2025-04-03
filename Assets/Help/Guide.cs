//GUÍA DE PROGRAMACIÓN.

//A LA HORA DE CREAR UN SCRIPT:
//   *NUNCA usar espacios a la hora de nombrar un script.
//   *Escribir nombre de script en Pascal (MyFirstScript.)
//   *NO utilziar caracteres especiales (tildes, dieresis, emojis, etc.)

//COMENTARIOS: Utilizar doble barra (//) para escribir anotaciones y comentarios en nuestro código.

//MÉTODOS:
// *Es código encapsulado que cumple un cierto propósito o función. Creamos un método indicando:
// void NombreDeMetodo() { entre las llaves va el código a ejecutar al llamar al método. }

//MÉTODOS DE UNITY:
//  *Unity ya tiene métodos predefinidos que se ejecutarán automáticamente cuando asignemos un script dentro de un objeto en escena.
//  idelamente todo nuestro código deberá ser ejecutado dentro de uno de estos métodos.
//   *Start: se llama en el primer frame de "vida" del objeto que posee el script.
//           Lo utilizamos para inicializar valores, conseguir y asignar refrencias a otros componentes,
//           etc,
//   *Update: se llama una vez por frame. Lo utilizamos para conseguir comandos del jugador, contadores
//            de tiempo, etc.
//   *FixedUpdate: se llama una vez cada un tiempo fijo. Lo utilizamos para actualizar todo lo que se relacione a físicas/Rigidbody que necesite un llamado
//                 constante o de más de un frame.

//TIEMPOS DELTA:
//  *Para evitar problemas relacionados al frame rate, podemos multiplicar cálculos que sean sensibles al llamado por Update/FixedUpdate por una variable
//  que devuelve el tiempo que pasó desde el último llamado del mismo para normalizarlos entre todas las máquinas que ejecuten el programa.
//   *En el caso de que se llame desde Update, utilizamos Time.deltaTime.
//   *En el caso de que se llame desde FixedUpdate, utilizamos Time.fixedDeltaTime.

//VARIABLES: Almacenan distiontos tipos de datos necesarios para la ejecución del código. Las variables pueden ser públicas (editables por inspector),
//que se indica public antes del tipo de dato; o privadas, indicando private o dejando nada antes del tipo de dato.

//TIPOS DE DATOS:
//  *int = este tipo de dato almacena números enteros. Su valor default es 0.
//   *Ejemplo = int totalClicks = 25;

//  *float = este tipo de dato nos permite almacenar números con décimales. Se debe distinguir de un int agregando una f al final del número.
//   *Ejemplo = float moveSpeed = 3.5f;

//  *string = este tipo de dato nos permite almacenar cadenas de caracteres. El texto debe estar escrito entre comillas (""), y agregando un símbolo pesos ($)
//  al comienzo nos permite ingresar valores de variables dentro del texto en sí ($"El jugador hizo un total de {totalClicks} clicks.")
//   *Ejemplo = string dialogueToShow = "Bienvendio a mi proyecto!";

//  *bool = este tipo de dato nos permite guardar una condición de verdadero (true) o falso (false.)
//   *Ejemplo = bool isInteractable = true;

//  *Vector3 = este tipo de dato nos permite guardar tres valores numéricos correspondiendo a coordenadas en los ejes X, Y y Z. Lo estaremos usando más que
//  nada para guardar y modificar posisciones y rotaciones de distintos objetos y entidades.
//   *Ejemplo = Vector3 initialPosition = new Vector3(0.0f, 0.0f, 0.0f);

//  *Nosotros también podemos almacenar componentes dentro de una variable (por ejemplo, el Rigidbody del personaje) y manipularlo a nuestra conveniencia.
//  *Para hacer esto, debemos crear una variable del tipo de componente que queremos guardar y:
//   *A) Asignarla por inspector en el caso de que la variables sea pública.
//   *B) En el método Awake/Start, utilizamos el GetComponent indicando el tipo de componente deseado (_rb = GetComponent<Rigidbody>();)

//INPUTS Y AXIS: Unity trae un sistema de inputs por default que nos permitirá recibir un valor positivo/negativo para utilizar como necesitemos.
//  *Input.GetAxis("eje") = este es el método que utilizamos para conseguir el eje. Entre las comillas determinamos qué eje queremos utilizar para recibir
//  valores.
//   *"Horizontal" = tiene de valor positivo (1.0f) las teclas D y la flecha derecha, y de valor negativo (-1.0f) las teclas A y flecha izquierda. 
//   *"Vertical" = tiene de valor positivo (1.0f) las teclas W y la flecha arriba, y de valor negativo (-1.0f) las teclas S y flecha abajo. 

//  *Input.GetKey(KeyCode.Tecla) / .GetKeyDown() / .GetKeyUp() = este son los métodos que utilizmos para preguntar por un input específico en momentos específicos.
//  GetKeyDown lo consigue al apretarse la tecla (un solo frame), GetKeyUp al soltarse (un solo frame) y GetKey mientras la tecla se mantega apretada (varios frames.)
//  Entre los paréntesis indicamos cuál es la tecla por la que estamos preguntando (KeyCode.Tecla).

//RIGIDBODY = Es el componente que asignamos a un objeto dentro de la escena que nos permitirá utilizar el sistema de físicas de Unity.
