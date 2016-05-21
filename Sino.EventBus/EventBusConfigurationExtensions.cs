using Abp.Configuration.Startup;
using Abp.Dependency;
using Abp.Events.Bus;
using Castle.MicroKernel.Registration;
using MassTransit;
using System;
using MassTransit.AzureServiceBusTransport;
using Microsoft.Azure;

namespace Sino.EventBus
{
	/// <summary>
	/// 事件总线配置扩展
	/// </summary>
	public static class EventBusConfigurationExtensions
	{
		public static IBusControl BusHub { get; set; }

		public static IIocManager Ioc { get; set; } = IocManager.Instance;

		/// <summary>
		/// 启用第三方事件总线
		/// </summary>
		/// <param name="connectionName">连接字符串名称</param>
		public static void UseEventBus(this IEventBusConfiguration eventBusConfiguration, string connectionName = "Microsoft.ServiceBus.ConnectionString", int timeOut = 10,string queueName = "SinoQueue")
		{
			if (string.IsNullOrEmpty(connectionName))
				throw new ArgumentNullException(nameof(connectionName));

			BusHub = Bus.Factory.CreateUsingAzureServiceBus(cfg =>
			{
				var host = cfg.Host(CloudConfigurationManager.GetSetting(connectionName), h =>
				{
					h.OperationTimeout = TimeSpan.FromSeconds(timeOut);
					h.TransportType = Microsoft.ServiceBus.Messaging.TransportType.NetMessaging;
				});
				cfg.ReceiveEndpoint(host, "SinoQueue", e =>
				{
					e.UseMessageScope();
					e.LoadFrom(Ioc.IocContainer);
				});
			});

			//释放ABP自带的EventBus
			var releaseEventBus = Ioc.Resolve<IEventBus>();
			Ioc.Release(releaseEventBus);

			Ioc.IocContainer.Register(Component.For<IBus>().Instance(BusHub).Named("BusRegister"));
			Ioc.IocContainer.Register(Component.For<IBusControl>().Instance(BusHub).Named("BusControlRegister"));

			var eventBusExtensions = Ioc.Resolve<IEventBusExtensions>();
			Ioc.IocContainer.Register(
				Component.For<IEventBus>().
				Instance(eventBusExtensions).
				IsDefault().
				Named("Sino.EventBus")
			);

			BusHub.Start();
		}

		public static void Stop()
		{
			BusHub.Stop();
		}
	}
}
