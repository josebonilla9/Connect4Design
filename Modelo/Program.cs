using GroqApiLibrary;
using System.Text.Json.Nodes;

class Program
{
    static async Task Main(string[] args)
    {
        var apiKey = "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"; //Aquí va la API Key
        var groqApi = new GroqApiClient(apiKey);

        // Lista para almacenar el contexto de la conversación
        var messages = new JsonArray
        {
            new JsonObject
            {
                ["role"] = "user",

                //Aquí va el contenido de nuestra consulta
                ["content"] = "Quiero jugar al 3 en raya, la esquina superior izquierda es la coordenada 1-1 (fila 1 y columna 1), y la inferior derecha es 3-3 (fila 3 y columna 3), yo he puesto mi primera ficha en 2-2, ¿Dónde seguirás tú?"
            }
        };

        // Realizar la primera consulta
        var request = new JsonObject
        {
            ["model"] = "llama3-70b-8192",
            ["messages"] = messages
        };

        var result = await groqApi.CreateChatCompletionAsync(request);
        var response = result?["choices"]?[0]?["message"]?["content"]?.ToString();
        Console.WriteLine("Asistente: " + response);

        // Agregar la respuesta del asistente al contexto
        messages.Add(new JsonObject
        {
            ["role"] = "assistant",
            ["content"] = response
        });

        // Permitir interacción continua desde la consola
        while (true)
        {
            Console.Write("Tú: ");
            var userInput = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(userInput))
            {
                Console.WriteLine("Terminando la conversación...");
                break;
            }

            // Agregar el input del usuario al contexto
            messages.Add(new JsonObject
            {
                ["role"] = "user",
                ["content"] = userInput
            });

            // Enviar la nueva solicitud con el contexto actualizado
            request["messages"] = messages;

            result = await groqApi.CreateChatCompletionAsync(request);
            response = result?["choices"]?[0]?["message"]?["content"]?.ToString();
            Console.WriteLine("Asistente: " + response);

            // Agregar la respuesta del asistente al contexto
            messages.Add(new JsonObject
            {
                ["role"] = "assistant",
                ["content"] = response
            });
        }
    }
}
