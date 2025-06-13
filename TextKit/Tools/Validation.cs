namespace TextKit.Tools
{
	internal class Validation
	{
		public static void CheckRead(FileStreamOptions streamOptions)
		{
			if (streamOptions.Access != FileAccess.Read && streamOptions.Access != FileAccess.ReadWrite)
			{
				throw new ArgumentException("Нет доступа для чтения файла.", nameof(streamOptions));
			}

			if (streamOptions.Mode != FileMode.Open)
			{
				throw new ArgumentException("FileMode должен быть Open.", nameof(streamOptions));
			}
		}

		public static void CheckRead(Stream stream)
		{
			if (stream.CanRead == false)
			{
				throw new ArgumentException("Поток должен быть открыт для чтения.", nameof(stream));
			}
		}

		public static void CheckWrite(FileStreamOptions streamOptions)
		{
			if (streamOptions.Access != FileAccess.Write && streamOptions.Access != FileAccess.ReadWrite)
			{
				throw new ArgumentException("Нет доступа для записи в файл.", nameof(streamOptions));
			}

			if (streamOptions.Mode != FileMode.Create && streamOptions.Mode != FileMode.CreateNew && streamOptions.Mode != FileMode.Append && streamOptions.Mode != FileMode.Truncate)
			{
				throw new ArgumentException("FileMode должен быть Create, CreateNew, Append, Truncate.", nameof(streamOptions));
			}
		}

		public static void CheckWrite(Stream stream)
		{
			if (stream.CanWrite == false)
			{
				throw new ArgumentException("Поток должен быть открыт для записи.", nameof(stream));
			}
		}
	}
}
