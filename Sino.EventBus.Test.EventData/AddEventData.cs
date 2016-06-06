using System;

namespace Sino.EventBus.Test
{
	public class AddEventData : RemoteEventData
	{
		public string Add { get; set; }

		public DateTime AddTime { get; set; }

		public int AddCount { get; set; }
	}
}
