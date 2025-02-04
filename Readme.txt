Descripción de la aplicación y cómo ponerla en marcha:

Esta aplicación es un juego digital del clásico "Conecta 4", diseñado para ofrecer una experiencia interactiva en la que un jugador humano puede competir contra 
una inteligencia artificial (IA). El objetivo del juego es conectar cuatro fichas del mismo color en línea horizontal, vertical o diagonal antes que el oponente.

Características principales de la aplicación:

- Interfaz de usuario intuitiva: El jugador interactúa con el tablero a través de etiquetas (labels) que representan cada celda, permitiendo seleccionar la columna 
donde desea colocar su ficha.
- Modo de juego humano vs IA: La aplicación gestiona automáticamente los turnos entre el jugador humano y la IA, alternando de forma dinámica.
- IA integrada: Utiliza un programa de IA que analiza el estado actual del tablero y toma decisiones estratégicas para competir contra el jugador humano.
- Gestión del estado del juego: Controla el flujo del juego verificando condiciones de victoria, empate y cambios de turno, proporcionando mensajes en tiempo real 
en un cuadro de chat para mantener al usuario informado.
- Funcionalidad de reinicio: Permite reiniciar el juego fácilmente, restableciendo el tablero y los estados de turno para iniciar una nueva partida.
- Chat integrado: Incluye un cuadro de texto donde se muestran mensajes sobre el progreso del juego y una ventana de chat emergente para una comunicación adicional.. 


Para ponerla en marcha, siga los siguientes pasos:

1. Clonar el repositorio del proyecto desde el repositorio de GitHub.
2. Abrir el proyecto en Visual Studio.
3. Restaurar los paquetes NuGet necesarios para el proyecto.
4. Configurar la API Key de Groq en el archivo de configuración correspondiente.
	Para la inteligencia artificial hemos usado la API de Groq que facilita la integración de IA en el desarrollo.
		- Lo primero que hay que hacer para su instalación es iniciar sesión en su página web (https://console.groq.com/playground).
		- Tras iniciar sesión hay que crear la API Key que se pone donde está el mensaje "Aquí va la API Key".
		- Si en algún momento se quisiera cambiar nuestra consulta se haría donde pone "Aquí va el contenido de nuestra consulta".
5. Compilar el proyecto para asegurarse de que no hay errores.
6. Ejecutar la aplicación desde Visual Studio.

Una vez que la aplicación esté en funcionamiento, podrá interactuar con la inteligencia artificial a través de la interfaz de usuario proporcionada.