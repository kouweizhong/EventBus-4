using Abp.Dependency;
using Abp.Events.Bus.Handlers;
using MassTransit;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Sino.EventBus.Test
{
	public class DeleteEventHandler : IEventHandler<DeleteEventData>, IConsumer<DeleteEventData>, ITransientDependency
	{
		public Task Consume(ConsumeContext<DeleteEventData> context)
		{
			HandleEvent(context.Message);
			return Task.Delay(0);
		}

		public void HandleEvent(DeleteEventData eventData)
		{
			Debug.WriteLine("Get DeleteEventData");
		}
	}
}
