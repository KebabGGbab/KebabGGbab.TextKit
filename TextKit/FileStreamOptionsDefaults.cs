namespace KebabGGbab.Extensions.TextKit
{
	public static class FileStreamOptionsDefaults
	{
		public static FileStreamOptions Read 
		{ 
			get
			{
				return new FileStreamOptions()
				{
					Mode = FileMode.Open,
					Access = FileAccess.Read,
					Share = FileShare.Read
				};
			} 
		}

		public static FileStreamOptions Write
		{
			get
			{
				return new FileStreamOptions()
				{
					Mode = FileMode.OpenOrCreate,
					Access = FileAccess.Write,
					Share = FileShare.None
				};
			}
		}
	}
}
