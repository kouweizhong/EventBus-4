using System;

namespace Sino.EventBus.Test
{
	public class UpdateEventData : RemoteEventData
	{
		public string Update { get; set; }

		public DateTime UpdateTime { get; set; }

		public int UpdateCount { get; set; }
	}
}
