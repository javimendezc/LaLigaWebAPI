La solución consta de 3 proyectos:
- Conexión: Es la capa de persistencia, con el modelo EF de la base de datos
	He hecho que el modelo implemente una interfaz "ILaLigaEntities" para poder utilizarla luego en el IoC y poder desacoplar el componente de la parte del Web Api

- LaLigaWebAPI: Es el API Web con los servicios REST. He considerado separar el comportamiento en capas:
	* DAO: Es la capa que se comunica directamente con el modelo EF. Todos los objetos de esta capa implementan su propia interfaz y heredan todos de la clase abstracta DAO, que me sirve
	para ofrecer un constructor base común que instancie los objetos de la interfaz ILaLigaEntities
	* Gestores: es la capa que recibe los datos del DAO EF y hace la transformación a objetos de lo modelos con los que luego trabajaremos y que se enviarán al front. Todos implementan 
	su propia interfaz e instancian objetos de las interfaces de la capa DAO.
	* Controllers: es la capa que recibe las peticiones http. Los controladore instancias objetos de las interfaces de la capa Gestores

	He utilizado un contenedor de IoC Unity para resolver las inyecciones de dependencias. La configuración está en App_Start/UnityConfig.cs
	En el App_Start/WebApiConfig.cs he configurado que los datos se envíen al front sólo por JSON

- LaLigaConsumer: Es el front-end, implementado con ASP .Net MVC 5
	El mapa de la aplicación sería el siguiente:
	
	Listado de clubes
	|	|_ Nuevo club
	|	|_ Editar presupuesto
	|	|_ Listado de jugadores del club
	|		|_ Fichar a un nuevo jugador libre (que no esté asignado ya a un equipo)
	|		|_ Eliminar la ficha del jugador
	Listado de jugadores
		|_ Nuevo jugador


Se entrega un script de la base de datos con las tablas y los datos que he utilizado para hacer pruebas

Se entrega una colección postman con las llamadas a los servicios de la interfaz web api

IMPORTANTE!!!
Para ejecutar correctamente la solución desde el IDE, en las propiedades de inicio del archivo de solución, debe marcarse la opción "proyectos de inicio múltiples", y seleccionar la Acción "Iniciar" en "LaLigaConsumer" y "LaLigaWebAPI"