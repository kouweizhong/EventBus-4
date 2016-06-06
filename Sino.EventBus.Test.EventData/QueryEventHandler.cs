using Abp.Dependency;
using Abp.Events.Bus.Handlers;
using MassTransit;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Sino.EventBus.Test
{
	public class QueryEventHandler : IEventHandler<QueryEventData>, IConsumer<QueryEventData>, ITransientDependency
	{
		public Task Consume(ConsumeContext<QueryEventData> context)
		{
			HandleEvent(context.Message);
			return Task.Delay(0);
		}

		public void HandleEvent(QueryEventData eventData)
		{
			Debug.WriteLine("Get QueryEventData");
		}
	}
}
