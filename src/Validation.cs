using System.Text;
using KebabGGbab.Json.Resources;

namespace KebabGGbab.Json
{
	internal static class Validation
	{
		private static readonly CompositeFormat _optionReadIncorrectFileAccess = CompositeFormat.Parse(ValidationStrings.OptionReadIncorrectFileAccessFormat);
		private static readonly CompositeFormat _optionReadIncorrectFileMode = CompositeFormat.Parse(ValidationStrings.OptionReadIncorrectFileModeFormat);
        private static readonly CompositeFormat _optionWriteIncorrectFileAccess = CompositeFormat.Parse(ValidationStrings.OptionWriteIncorrectFileAccessFormat);
		private static readonly CompositeFormat _optionWriteIncorrectFileMode = CompositeFormat.Parse(ValidationStrings.OptionWriteIncorrectFileModeFormat);

        public static void CanRead(FileStreamOptions streamOptions)
		{
			ArgumentNullException.ThrowIfNull(streamOptions);

			if (streamOptions.Access != FileAccess.Read && 
				streamOptions.Access != FileAccess.ReadWrite)
			{
				throw new ArgumentException(string.Format(null, _optionReadIncorrectFileAccess, streamOptions.Access), nameof(streamOptions));
			}

			if (streamOptions.Mode != FileMode.Open && 
				streamOptions.Mode != FileMode.OpenOrCreate)
			{
				throw new ArgumentException(string.Format(null, _optionReadIncorrectFileMode, streamOptions.Mode), nameof(streamOptions));
			}
		}

		public static void CanRead(Stream stream)
		{
			ArgumentNullException.ThrowIfNull(stream);

			if (stream.CanRead == false)
			{
				throw new ArgumentException(ValidationStrings.StreamNotOpenRead, nameof(stream));
			}
		}

		public static void CanWrite(FileStreamOptions streamOptions)
		{
			ArgumentNullException.ThrowIfNull(streamOptions);

			if (streamOptions.Access != FileAccess.Write && 
				streamOptions.Access != FileAccess.ReadWrite)
			{
				throw new ArgumentException(string.Format(null, _optionWriteIncorrectFileAccess, streamOptions.Access), nameof(streamOptions));
			}

			if (streamOptions.Mode != FileMode.Create &&
				streamOptions.Mode != FileMode.CreateNew &&
				streamOptions.Mode != FileMode.OpenOrCreate &&
				streamOptions.Mode != FileMode.Truncate &&
				streamOptions.Mode != FileMode.Append)
			{
				throw new ArgumentException(string.Format(null, _optionWriteIncorrectFileMode, streamOptions.Mode), nameof(streamOptions));
			}
		}

		public static void CanWrite(Stream stream)
		{
			ArgumentNullException.ThrowIfNull(stream);

			if (stream.CanWrite == false)
			{
				throw new ArgumentException(ValidationStrings.StreamNotOpenWrite, nameof(stream));
			}
		}
	}
}
