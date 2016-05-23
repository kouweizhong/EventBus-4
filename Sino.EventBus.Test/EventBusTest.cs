using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Abp.Events.Bus;
using Abp.Dependency;
using System.Threading;
using MassTransit;
using System.Threading.Tasks;

namespace Sino.EventBus.Test
{
	[TestClass]
	public class EventBusTest : TestBase
	{
		[TestInitialize]
		public void Init()
		{
			EventBusConfigurationExtensions.Ioc = LocalIocManager;
			EventBusConfigurationExtensions.UseEventBus(null);
		}

		[TestCleanup]
		public void Clean()
		{
			Thread.Sleep(2 * 1000);
			EventBusConfigurationExtensions.Stop();
		}

		[TestMethod]
		public void SendAddEventDataTest()
		{
			var eventBus = Resolve<IEventBus>();

			eventBus.Trigger(new AddEventData
			{
				Add = "Test Add Event",
				AddTime = DateTime.Now,
				AddCount = 1
			});
		}

		[TestMethod]
		public void SendUpdateEventDataTest()
		{
			var eventBus = Resolve<IEventBus>();
			eventBus.Trigger(new UpdateEventData
			{
				Update = "Test Update Event",
				UpdateTime = DateTime.Now,
				UpdateCount = 2
			});
		}

		[TestMethod]
		public void SendDeleteEventDataTest()
		{
			var eventBus = Resolve<IEventBus>();
			eventBus.Trigger(new DeleteEventData
			{
				Delete = "Test Delete Event",
				DeleteTime = DateTime.Now,
				DeleteCount = 3
			});
		}

		[TestMethod]
		public void SendQueryEventDataTest()
		{
			var eventBus = Resolve<IEventBus>();
			eventBus.Trigger(new QueryEventData
			{
				Query = "Test Query Evvent",
				QueryCount = 4,
				QueryTime = DateTime.Now
			});
		}

		[TestMethod]
		public async Task SendAddRequestTest()
		{
			var bus = Resolve<IBus>();
			IRequestClient<AddRequest,AddResponse> client = new PublishRequestClient<AddRequest, AddResponse>(bus, TimeSpan.FromSeconds(10));
			var response = await client.Request(new AddRequest
			{
				Add = "AddRequest",
				AddCount = 3,
				AddTime = DateTime.Now
			});

			Assert.IsNotNull(response);
			Assert.AreEqual(response.Add, "AddResponse");

			response = await client.Request(new AddRequest
			{
				Add = "AddRequest",
				AddCount = 3,
				AddTime = DateTime.Now
			});

			Assert.IsNotNull(response);
		}
	}
}
