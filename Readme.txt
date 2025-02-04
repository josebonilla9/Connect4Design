Descripci�n de la aplicaci�n y c�mo ponerla en marcha:

Esta aplicaci�n es un juego digital del cl�sico "Conecta 4", dise�ado para ofrecer una experiencia interactiva en la que un jugador humano puede competir contra 
una inteligencia artificial (IA). El objetivo del juego es conectar cuatro fichas del mismo color en l�nea horizontal, vertical o diagonal antes que el oponente.

Caracter�sticas principales de la aplicaci�n:

- Interfaz de usuario intuitiva: El jugador interact�a con el tablero a trav�s de etiquetas (labels) que representan cada celda, permitiendo seleccionar la columna 
donde desea colocar su ficha.
- Modo de juego humano vs IA: La aplicaci�n gestiona autom�ticamente los turnos entre el jugador humano y la IA, alternando de forma din�mica.
- IA integrada: Utiliza un programa de IA que analiza el estado actual del tablero y toma decisiones estrat�gicas para competir contra el jugador humano.
- Gesti�n del estado del juego: Controla el flujo del juego verificando condiciones de victoria, empate y cambios de turno, proporcionando mensajes en tiempo real 
en un cuadro de chat para mantener al usuario informado.
- Funcionalidad de reinicio: Permite reiniciar el juego f�cilmente, restableciendo el tablero y los estados de turno para iniciar una nueva partida.
- Chat integrado: Incluye un cuadro de texto donde se muestran mensajes sobre el progreso del juego y una ventana de chat emergente para una comunicaci�n adicional.. 


Para ponerla en marcha, siga los siguientes pasos:

1. Clonar el repositorio del proyecto desde el repositorio de GitHub.
2. Abrir el proyecto en Visual Studio.
3. Restaurar los paquetes NuGet necesarios para el proyecto.
4. Configurar la API Key de Groq en el archivo de configuraci�n correspondiente.
	Para la inteligencia artificial hemos usado la API de Groq que facilita la integraci�n de IA en el desarrollo.
		- Lo primero que hay que hacer para su instalaci�n es iniciar sesi�n en su p�gina web (https://console.groq.com/playground).
		- Tras iniciar sesi�n hay que crear la API Key que se pone donde est� el mensaje "Aqu� va la API Key".
		- Si en alg�n momento se quisiera cambiar nuestra consulta se har�a donde pone "Aqu� va el contenido de nuestra consulta".
5. Compilar el proyecto para asegurarse de que no hay errores.
6. Ejecutar la aplicaci�n desde Visual Studio.

Una vez que la aplicaci�n est� en funcionamiento, podr� interactuar con la inteligencia artificial a trav�s de la interfaz de usuario proporcionada.