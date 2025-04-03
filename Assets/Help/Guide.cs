//GU�A DE PROGRAMACI�N.

//A LA HORA DE CREAR UN SCRIPT:
//   *NUNCA usar espacios a la hora de nombrar un script.
//   *Escribir nombre de script en Pascal (MyFirstScript.)
//   *NO utilziar caracteres especiales (tildes, dieresis, emojis, etc.)

//COMENTARIOS: Utilizar doble barra (//) para escribir anotaciones y comentarios en nuestro c�digo.

//M�TODOS:
// *Es c�digo encapsulado que cumple un cierto prop�sito o funci�n. Creamos un m�todo indicando:
// void NombreDeMetodo() { entre las llaves va el c�digo a ejecutar al llamar al m�todo. }

//M�TODOS DE UNITY:
//  *Unity ya tiene m�todos predefinidos que se ejecutar�n autom�ticamente cuando asignemos un script dentro de un objeto en escena.
//  idelamente todo nuestro c�digo deber� ser ejecutado dentro de uno de estos m�todos.
//   *Start: se llama en el primer frame de "vida" del objeto que posee el script.
//           Lo utilizamos para inicializar valores, conseguir y asignar refrencias a otros componentes,
//           etc,
//   *Update: se llama una vez por frame. Lo utilizamos para conseguir comandos del jugador, contadores
//            de tiempo, etc.
//   *FixedUpdate: se llama una vez cada un tiempo fijo. Lo utilizamos para actualizar todo lo que se relacione a f�sicas/Rigidbody que necesite un llamado
//                 constante o de m�s de un frame.

//TIEMPOS DELTA:
//  *Para evitar problemas relacionados al frame rate, podemos multiplicar c�lculos que sean sensibles al llamado por Update/FixedUpdate por una variable
//  que devuelve el tiempo que pas� desde el �ltimo llamado del mismo para normalizarlos entre todas las m�quinas que ejecuten el programa.
//   *En el caso de que se llame desde Update, utilizamos Time.deltaTime.
//   *En el caso de que se llame desde FixedUpdate, utilizamos Time.fixedDeltaTime.

//VARIABLES: Almacenan distiontos tipos de datos necesarios para la ejecuci�n del c�digo. Las variables pueden ser p�blicas (editables por inspector),
//que se indica public antes del tipo de dato; o privadas, indicando private o dejando nada antes del tipo de dato.

//TIPOS DE DATOS:
//  *int = este tipo de dato almacena n�meros enteros. Su valor default es 0.
//   *Ejemplo = int totalClicks = 25;

//  *float = este tipo de dato nos permite almacenar n�meros con d�cimales. Se debe distinguir de un int agregando una f al final del n�mero.
//   *Ejemplo = float moveSpeed = 3.5f;

//  *string = este tipo de dato nos permite almacenar cadenas de caracteres. El texto debe estar escrito entre comillas (""), y agregando un s�mbolo pesos ($)
//  al comienzo nos permite ingresar valores de variables dentro del texto en s� ($"El jugador hizo un total de {totalClicks} clicks.")
//   *Ejemplo = string dialogueToShow = "Bienvendio a mi proyecto!";

//  *bool = este tipo de dato nos permite guardar una condici�n de verdadero (true) o falso (false.)
//   *Ejemplo = bool isInteractable = true;

//  *Vector3 = este tipo de dato nos permite guardar tres valores num�ricos correspondiendo a coordenadas en los ejes X, Y y Z. Lo estaremos usando m�s que
//  nada para guardar y modificar posisciones y rotaciones de distintos objetos y entidades.
//   *Ejemplo = Vector3 initialPosition = new Vector3(0.0f, 0.0f, 0.0f);

//  *Nosotros tambi�n podemos almacenar componentes dentro de una variable (por ejemplo, el Rigidbody del personaje) y manipularlo a nuestra conveniencia.
//  *Para hacer esto, debemos crear una variable del tipo de componente que queremos guardar y:
//   *A) Asignarla por inspector en el caso de que la variables sea p�blica.
//   *B) En el m�todo Awake/Start, utilizamos el GetComponent indicando el tipo de componente deseado (_rb = GetComponent<Rigidbody>();)

//INPUTS Y AXIS: Unity trae un sistema de inputs por default que nos permitir� recibir un valor positivo/negativo para utilizar como necesitemos.
//  *Input.GetAxis("eje") = este es el m�todo que utilizamos para conseguir el eje. Entre las comillas determinamos qu� eje queremos utilizar para recibir
//  valores.
//   *"Horizontal" = tiene de valor positivo (1.0f) las teclas D y la flecha derecha, y de valor negativo (-1.0f) las teclas A y flecha izquierda. 
//   *"Vertical" = tiene de valor positivo (1.0f) las teclas W y la flecha arriba, y de valor negativo (-1.0f) las teclas S y flecha abajo. 

//  *Input.GetKey(KeyCode.Tecla) / .GetKeyDown() / .GetKeyUp() = este son los m�todos que utilizmos para preguntar por un input espec�fico en momentos espec�ficos.
//  GetKeyDown lo consigue al apretarse la tecla (un solo frame), GetKeyUp al soltarse (un solo frame) y GetKey mientras la tecla se mantega apretada (varios frames.)
//  Entre los par�ntesis indicamos cu�l es la tecla por la que estamos preguntando (KeyCode.Tecla).

//RIGIDBODY = Es el componente que asignamos a un objeto dentro de la escena que nos permitir� utilizar el sistema de f�sicas de Unity.
