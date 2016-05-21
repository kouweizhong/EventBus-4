using Abp.Events.Bus;
using System;

namespace Sino.EventBus.Test
{
	public class DeleteEventData : EventData
	{
		public string Delete { get; set; }

		public DateTime DeleteTime { get; set; }

		public int DeleteCount { get; set; }
	}
}
