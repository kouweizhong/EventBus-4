using Abp.Events.Bus;
using System;

namespace Sino.EventBus.Test
{
	public class QueryEventData : EventData
	{
		public string Query { get; set; }

		public DateTime QueryTime { get; set; }

		public int QueryCount { get; set; }
	}
}
