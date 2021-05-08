El proyecto fue desarrollado y probado en Visual Studio 2019


	El proyecto ya esta configurado para crear la base de datos automaticamente, los datos de prueba se generaran al iniciar la aplicacion.

	1-Para probar la aplicación es necesario configurar las propiedades de la solución para que permita iniciar proyectos multiples "Multiple Startup projects"
	 los proyectos simultaneos deben ser:
		-JugueteriaEvaluacionTecnicaBackend
		-JugueteriaFrontend

	2-Ejecutar el proyecto.

	Información de la solucion:

	Para utilizar el patron de desarrollo IRepository se añaden dos proyectos (DataAccess.EFCore y Domain)
		-DataAccess.EFCore : Se utilizó para aislar el Contexto de la base de datos, desde este proyecto se maneja la logica de BD
		-Domain: El proyecto se encarga de mantener los modelos de la base de datos y las interfaces que dictarán la declaracion de funciones en DataAccess.EFCore

	El backend "JugueteriaEvaluacionTecnicaBackend" de la aplicacion fue desarrollado en Net Core 3.1;
		-Se encarga de exponer el API que atiende las Request que vienen del Frontend y por medio de INYECCION DE DEPENDENCIAS se obtiene el Contexto de la base de datos para poder realizar las operaciones solicitadas por el Frontend

	El frontend "JugueteriaFrontend" fue realizado en Net core 3.1;
		-Se hace uso de la arquitectura MVC para servir la pagina inicial, al no utilizar un framework para frontend como Angular o React, todas las acciones realizadas al "Agregar, editar y eliminar" fueron manejadas 
		por medio de llamadas Jquery-AJAX, esto con la finalildad de no recargar la página en cada interacción (Agregar, editar y eliminar) fue realizada hacia el proyecto del Backend (JugueteriaEvaluacionTecnicaBackend) por medio de un Cliente Http.