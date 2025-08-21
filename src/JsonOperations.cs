using System.Text.Json;

namespace KebabGGbab.Json
{
	/// <summary>
	/// Запись и чтение строк json-формата из файла и в него.
	/// </summary>
	public static class JsonOperations
	{
		#region Reading methods

		/// <summary>
		/// Прочитать содержимое файла и десериализовать его из JSON.
		/// </summary>
		/// <typeparam name="T">Класс, в который необходимо десериализировать содержимое файла.</typeparam>
		/// <param name="path">Путь к файлу.</param>
		/// <param name="streamOptions">Параметры потока.</param>
		/// <param name="options">Параметры десериализации.</param>
		/// <returns>Десериализованный объект.</returns>
		public static T? ReadJson<T>(string path, FileStreamOptions streamOptions, JsonSerializerOptions? options = null)
		{
			Validation.CanRead(streamOptions);

			using FileStream stream = new(path, streamOptions);

			return JsonSerializer.Deserialize<T>(stream, options);
		}

		/// <summary>
		/// Прочитать содержимое файла и десериализовать его из JSON.
		/// </summary>
		/// <param name="path">Путь к файлу.</param>
		/// <param name="target">Тип, в который необходимо десериализовать содержимое файла.</param>
		/// <param name="streamOptions">Параметры потока.</param>
		/// <param name="options">Параметры десериализации.</param>
		/// <returns>Десериализованный объект.</returns>
		public static object? ReadJson(string path, Type target, FileStreamOptions streamOptions, JsonSerializerOptions? options = null)
		{
			Validation.CanRead(streamOptions);

			using FileStream stream = new(path, streamOptions);

			return JsonSerializer.Deserialize(stream, target, options);
		}

		/// <summary>
		/// Асинхронно прочитать содержимое файла и десериализовать его из JSON.
		/// </summary>
		/// <typeparam name="T">Класс, в который необходимо десериализировать содержимое файла.</typeparam>
		/// <param name="path">Путь к файлу.</param>
		/// <param name="streamOptions">Параметры потока.</param>
		/// <param name="options">Параметры десериализации.</param>
		/// <returns>Десериализованный объект.</returns>
		public static async Task<T?> ReadJsonAsync<T>(string path, FileStreamOptions streamOptions, JsonSerializerOptions? options = null)
		{
			Validation.CanRead(streamOptions);

			using FileStream stream = new(path, streamOptions);

			return await JsonSerializer.DeserializeAsync<T>(stream, options).ConfigureAwait(false);
		}

		/// <summary>
		/// Асинхронно прочитать содержимое файла и десериализовать его из JSON.
		/// </summary>
		/// <param name="path">Путь к файлу.</param>
		/// <param name="target">Тип, в который необходимо десериализовать содержимое файла.</param>
		/// <param name="streamOptions">Параметры потока.</param>
		/// <param name="options">Параметры десериализации.</param>
		/// <returns>Десериализованный объект.</returns>
		public static async Task<object?> ReadJsonAsync(string path, Type target, FileStreamOptions streamOptions, JsonSerializerOptions? options = null)
		{
			Validation.CanRead(streamOptions);

			using FileStream stream = new(path, streamOptions);

			return await JsonSerializer.DeserializeAsync(stream, target, options).ConfigureAwait(false);
		}

		/// <summary>
		/// Прочитать содержимое потока и десериализовать его из JSON.
		/// </summary>
		/// <typeparam name="T">Класс, в который необходимо десериализировать содержимое потока.</typeparam>
		/// <param name="stream">Поток, в котором содержится сериализованная строка.</param>
		/// <param name="options">Параметры десериализации.</param>
		/// <returns>Десериализованный объект.</returns>
		public static T? ReadJson<T>(Stream stream, JsonSerializerOptions? options = null)
		{
			Validation.CanRead(stream);

			return JsonSerializer.Deserialize<T>(stream, options);
		}

		/// <summary>
		/// Прочитать содержимое потока и десериализовать его из JSON.
		/// </summary>
		/// <param name="stream">Поток, в котором содержится сериализованная строка.</param>
		/// <param name="target">Тип, в который необходимо десериализовать содержимое потока.</param>
		/// <param name="options">Параметры десериализации.</param>
		/// <returns>Десериализованный объект.</returns>
		public static object? ReadJson(Stream stream, Type target, JsonSerializerOptions? options = null)
		{
			Validation.CanRead(stream);

			return JsonSerializer.Deserialize(stream, target, options);
		}

		/// <summary>
		/// Асинхронно прочитать содержимое потока и десериализовать его из JSON.
		/// </summary>
		/// <typeparam name="T">Класс, в который необходимо десериализировать содержимое потока.</typeparam>
		/// <param name="stream">Поток, в котором содержится сериализованная строка.</param>
		/// <param name="options">Параметры десериализации.</param>
		/// <returns>Десериализованный объект.</returns>
		public static async Task<T?> ReadJsonAsync<T>(Stream stream, JsonSerializerOptions? options = null)
		{
			Validation.CanRead(stream);

			return await JsonSerializer.DeserializeAsync<T>(stream, options).ConfigureAwait(false);
		}

		/// <summary>
		/// Асинхронно прочитать содержимое потока и десериализовать его из JSON.
		/// </summary>
		/// <param name="stream">Поток, в котором содержится сериализованная строка.</param>
		/// <param name="target">Тип, в который необходимо десериализовать содержимое потока.</param>
		/// <param name="options">Параметры десериализации.</param>
		/// <returns>Десериализованный объект.</returns>
		public static async Task<object?> ReadJsonAsync(Stream stream, Type target, JsonSerializerOptions? options = null)
		{
			Validation.CanRead(stream);

			return await JsonSerializer.DeserializeAsync(stream, target, options).ConfigureAwait(false);
		}

		#endregion

		#region Writing methods

		/// <summary>
		/// Сериализует объект в строку json-формата и записывает в файл.
		/// </summary>
		/// <typeparam name="T">Класс, который необходимо сериализировать в JSON.</typeparam>
		/// <param name="path">Путь к файлу.</param>
		/// <param name="obj">Объект для сериализации.</param>
		/// <param name="streamOptions">Параметры потока.</param>
		/// <param name="options">Параметры сериализации.</param>
		public static void WriteJson<T>(string path, T obj, FileStreamOptions streamOptions, JsonSerializerOptions? options = null)
		{
			Validation.CanWrite(streamOptions);

			using FileStream stream = new(path, streamOptions);

			JsonSerializer.Serialize(stream, obj, options);
		}

		/// <summary>
		/// Асинхронно сериализует объект в строку json-формата и записывает в файл.
		/// </summary>
		/// <typeparam name="T">Класс, который необходимо сериализировать в JSON.</typeparam>
		/// <param name="path">Путь к файлу.</param>
		/// <param name="obj">Объект для сериализации.</param>
		/// <param name="streamOptions">Параметры потока.</param>
		/// <param name="options">Параметры сериализации.</param>
		public static async Task WriteJsonAsync<T>(string path, T obj, FileStreamOptions streamOptions, JsonSerializerOptions? options = null)
		{
			Validation.CanWrite(streamOptions);

			using FileStream stream = new(path, streamOptions);

			await JsonSerializer.SerializeAsync(stream, obj, options).ConfigureAwait(false);
		}

		/// <summary>
		/// Сериализует объект в строку json-формата и записывает в поток.
		/// </summary>
		/// <typeparam name="T">Класс, который необходимо сериализировать в JSON.</typeparam>
		/// <param name="stream">Поток, в который будет записана десериализованная строка json-формата.</param>
		/// <param name="obj">Объект для сериализации.</param>
		/// <param name="options">Параметры сериализации.</param>
		public static void WriteJson<T>(Stream stream, T obj, JsonSerializerOptions? options = null)
		{
			Validation.CanWrite(stream);

			JsonSerializer.Serialize(stream, obj, options);
		}

		/// <summary>
		/// Асинхронно сериализует объект в строку json-формата и записывает в поток.
		/// </summary>
		/// <typeparam name="T">Класс, который необходимо сериализировать в JSON.</typeparam>
		/// <param name="stream">Поток, в который будет записана десериализованная строка json-формата.</param>
		/// <param name="obj">Объект для сериализации.</param>
		/// <param name="options">Параметры сериализации.</param>
		public static async Task WriteJsonAsync<T>(Stream stream, T obj, JsonSerializerOptions? options = null)
		{
			Validation.CanWrite(stream);

			await JsonSerializer.SerializeAsync(stream, obj, options).ConfigureAwait(false);
		}

		#endregion
	}
}
