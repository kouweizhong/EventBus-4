using System;

namespace Sino.EventBus
{
	public class RemoteEventData : IRemoteEventData
	{
		public object EventSource { get; set; }

		public DateTime EventTime { get; set; } = DateTime.Now;
	}
}
