using Abp.Dependency;
using Abp.Events.Bus.Handlers;
using MassTransit;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Sino.EventBus.Test
{
	public class UpdateEventHandler : IEventHandler<UpdateEventData>, IConsumer<UpdateEventData>, ITransientDependency
	{
		public Task Consume(ConsumeContext<UpdateEventData> context)
		{
			HandleEvent(context.Message);
			return Task.Delay(0);
		}

		public void HandleEvent(UpdateEventData eventData)
		{
			Debug.WriteLine("Get UpdateEventData");
		}
	}
}
