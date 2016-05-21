using Abp.Events.Bus;
using System;

namespace Sino.EventBus.Test
{
	public class AddEventData : EventData
	{
		public string Add { get; set; }

		public DateTime AddTime { get; set; }

		public int AddCount { get; set; }
	}
}
