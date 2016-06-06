using Abp.Dependency;
using Abp.Events.Bus.Handlers;
using MassTransit;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Sino.EventBus.Test
{
	public class AddEventHandler : IEventHandler<AddEventData>, IConsumer<AddEventData>, ITransientDependency
	{
		public Task Consume(ConsumeContext<AddEventData> context)
		{
			HandleEvent(context.Message);
			return Task.Delay(0);
		}

		public void HandleEvent(AddEventData eventData)
		{
			Debug.WriteLine("Get AddEventData");
		}
	}
}
