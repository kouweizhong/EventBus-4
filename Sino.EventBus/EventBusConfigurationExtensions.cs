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
		/// <summary>
		/// 服务总线连接字符串Name
		/// </summary>
		public static string ConnectionName { get; set; } = "Microsoft.ServiceBus.ConnectionString";

		/// <summary>
		/// 启用第三方事件总线
		/// </summary>
		/// <param name="connectionName">连接字符串名称</param>
		public static void UseEventBus(this IEventBusConfiguration eventBusConfiguration, string connectionName,int timeOut = 10,string queueName = "SinoQueue")
		{
			if (eventBusConfiguration == null)
				throw new ArgumentNullException("eventBusConfiguration");
			if (!string.IsNullOrEmpty(connectionName))
				ConnectionName = connectionName;

			var bus = Bus.Factory.CreateUsingAzureServiceBus(cfg =>
			{
				var host = cfg.Host(CloudConfigurationManager.GetSetting(connectionName), h =>
				{
					h.OperationTimeout = TimeSpan.FromSeconds(timeOut);
					h.TransportType = Microsoft.ServiceBus.Messaging.TransportType.NetMessaging;
				});
				cfg.ReceiveEndpoint(host, "SinoQueue", e =>
				{
					e.UseMessageScope();
					e.LoadFrom(IocManager.Instance.IocContainer);
				});
			});

			var eventBusExtensions = IocManager.Instance.Resolve<IEventBusExtensions>();

			//释放ABP自带的EventBus
			var releaseEventBus = IocManager.Instance.Resolve<IEventBus>();
			IocManager.Instance.Release(releaseEventBus);

			IocManager.Instance.IocContainer.Register(Component.For<IBus>().Instance(bus).Named("BusRegister"));
			IocManager.Instance.IocContainer.Register(Component.For<IBusControl>().Instance(bus).Named("BusControlRegister"));
			IocManager.Instance.IocContainer.Register(
				Component.For<IEventBus>().
				Instance(eventBusExtensions).
				IsDefault().
				Named("Sino.EventBus")
			);

			bus.Start();
		}
	}
}
