using Abp.Dependency;
using MassTransit;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Sino.EventBus.Test
{
	public class AddRequestHandler : IConsumer<AddRequest>, ITransientDependency
	{
		public async Task Consume(ConsumeContext<AddRequest> context)
		{
			Debug.WriteLine($"{context.Message.Add},Time:{context.Message.AddTime},Count:{context.Message.AddCount}");
			await context.RespondAsync(new AddResponse
			{
				Add = "AddResponse",
				AddTime = DateTime.Now,
				AddCount = 3
			});
		}
	}
}
