namespace KebabGGbab.TextKit.Tools
{
	internal static class Validation
	{
		public static void CanRead(FileStreamOptions streamOptions)
		{
			ArgumentNullException.ThrowIfNull(streamOptions);

			if (streamOptions.Access != FileAccess.Read && 
				streamOptions.Access != FileAccess.ReadWrite)
			{
				throw new ArgumentException($"Для чтения файла FileAccess должен быть 'Read' или 'ReadWrite'. Текущее значение '{streamOptions.Access}'.", nameof(streamOptions));
			}

			if (streamOptions.Mode != FileMode.Open && 
				streamOptions.Mode != FileMode.OpenOrCreate)
			{
				throw new ArgumentException($"Для чтения файла FileMode должен быть 'Open' или 'OpenOrCreate'. Текущее значение '{streamOptions.Mode}'.", nameof(streamOptions));
			}
		}

		public static void CanRead(Stream stream)
		{
			ArgumentNullException.ThrowIfNull(stream);

			if (stream.CanRead == false)
			{
				throw new ArgumentException("Поток должен быть открыт для чтения.", nameof(stream));
			}
		}

		public static void CanWrite(FileStreamOptions streamOptions)
		{
			ArgumentNullException.ThrowIfNull(streamOptions);

			if (streamOptions.Access != FileAccess.Write && 
				streamOptions.Access != FileAccess.ReadWrite)
			{
				throw new ArgumentException($"Для записи в файл FileAccess должен быть 'Write' или 'ReadWrite'. Текущее значение '{streamOptions.Access}'.", nameof(streamOptions));
			}

			if (streamOptions.Mode != FileMode.Create &&
				streamOptions.Mode != FileMode.CreateNew &&
				streamOptions.Mode != FileMode.OpenOrCreate &&
				streamOptions.Mode != FileMode.Truncate &&
				streamOptions.Mode != FileMode.Append)
			{
				throw new ArgumentException($"Для записи в файл FileMode должен быть 'Create', 'CreateNew', 'OpenOrCreate', 'Truncate' или 'Append'. Текущее значение '{streamOptions.Mode}'.", nameof(streamOptions));
			}
		}

		public static void CanWrite(Stream stream)
		{
			ArgumentNullException.ThrowIfNull(stream);

			if (stream.CanWrite == false)
			{
				throw new ArgumentException("Поток должен быть открыт для записи.", nameof(stream));
			}
		}
	}
}
