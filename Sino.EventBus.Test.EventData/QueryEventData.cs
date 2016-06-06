using System;

namespace Sino.EventBus.Test
{
	public class QueryEventData : RemoteEventData
	{
		public string Query { get; set; }

		public DateTime QueryTime { get; set; }

		public int QueryCount { get; set; }
	}
}
