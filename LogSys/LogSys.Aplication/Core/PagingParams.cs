

namespace LogSys.Aplication.Core
{
	/// <summary>
	/// Params 4 paginator defaul pagesize 10 max 50
	/// </summary>
	public class PagingParams
	{
		private const int MaxPageSize = 50;
		public int PageNumber { get; set; } = 1;

		private int _pageSize = 10;

		public int PageSize
		{
			get => _pageSize;
			set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
		}

	}
}
