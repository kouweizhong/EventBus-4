using Abp.Events.Bus;
using System;

namespace Sino.EventBus.Test
{
	public class UpdateEventData : EventData
	{
		public string Update { get; set; }

		public DateTime UpdateTime { get; set; }

		public int UpdateCount { get; set; }
	}
}
