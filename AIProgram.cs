using System.Text.Json.Nodes;
using GroqApiLibrary;

/// <summary>
/// Clase principal para interactuar con la API de Groq.
/// </summary>
public class AIProgram
{
    private readonly GroqApiClient groqApi;

    /// <summary>
    /// Mensajes intercambiados con la IA.
    /// </summary>
    public JsonArray Messages { get; }

    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="AIProgram"/>.
    /// </summary>
    /// <param name="apiKey">Clave API para autenticar con el servicio de Groq.</param>
    public AIProgram(string apiKey)
    {
        groqApi = new GroqApiClient(apiKey);
        Messages = new JsonArray();
    }

    /// <summary>
    /// Obtiene una respuesta de la IA basada en el estado actual del tablero.
    /// </summary>
    /// <param name="boardState">Estado actual del tablero.</param>
    /// <returns>Respuesta de la IA indicando la columna donde debería jugar.</returns>
    /// <exception cref="Exception">Se lanza si no se obtiene respuesta de la IA.</exception>
    public async Task<string> GetAIResponseAsync(string boardState)
    {
        Messages.Add(new JsonObject
        {
            ["role"] = "user",
            ["content"] = $"¿Dónde debería jugar la IA?, solo tiene que poner la columna. El tablero actual es: {boardState}"
        });

        var request = new JsonObject
        {
            ["model"] = "llama3-70b-8192",
            ["messages"] = new JsonArray(Messages.Select(m => JsonNode.Parse(m.ToJsonString())).ToArray())
        };

        var result = await groqApi.CreateChatCompletionAsync(request);
        var response = result?["choices"]?[0]?["message"]?["content"]?.ToString();

        if (string.IsNullOrEmpty(response))
        {
            throw new Exception("No se obtuvo respuesta de la IA.");
        }

        Messages.Add(new JsonObject
        {
            ["role"] = "assistant",
            ["content"] = response
        });

        return response;
    }
}
