namespace TextKit.Tools
{
	internal class Validation
	{
		public static void CheckRead(FileStreamOptions streamOptions)
		{
			if (streamOptions.Access != FileAccess.Read && streamOptions.Access != FileAccess.ReadWrite)
			{
				throw new ArgumentException("No permission to read file.", nameof(streamOptions));
			}

			if (streamOptions.Mode != FileMode.Open)
			{
				throw new ArgumentException("FileMode must be equal to FileMode.Open.", nameof(streamOptions));
			}
		}

		public static void CheckRead(Stream stream)
		{
			if (stream.CanRead == false)
			{
				throw new ArgumentException("The stream must be open for reading.", nameof(stream));
			}
		}

		public static void CheckWrite(FileStreamOptions streamOptions)
		{
			if (streamOptions.Access != FileAccess.Write && streamOptions.Access != FileAccess.ReadWrite)
			{
				throw new ArgumentException("No permission to write to file.", nameof(streamOptions));
			}

			if (streamOptions.Mode != FileMode.Create && streamOptions.Mode != FileMode.CreateNew && streamOptions.Mode != FileMode.Append && streamOptions.Mode != FileMode.Truncate)
			{
				throw new ArgumentException("FileMode должен быть равен Create, CreateNew, Append, Truncate.", nameof(streamOptions));
			}
		}

		public static void CheckWrite(Stream stream)
		{
			if (stream.CanWrite == false)
			{
				throw new ArgumentException("The stream must be open for writing.", nameof(stream));
			}
		}
	}
}
