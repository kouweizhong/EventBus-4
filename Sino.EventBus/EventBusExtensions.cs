using System;
using System.Threading.Tasks;
using Abp.Events.Bus;
using Abp.Events.Bus.Factories;
using Abp.Events.Bus.Handlers;
using Abp.Dependency;
using Castle.Core.Logging;
using MassTransit;

namespace Sino.EventBus
{
	/// <summary>
	/// 对Abp EventBus的封装与扩展
	/// </summary>
	public class EventBusExtensions : IEventBusExtensions, ISingletonDependency
	{
		/// <summary>
		/// 日志
		/// </summary>
		protected ILogger Log { get; set; }

		protected IBusControl Bus { get; set; }

		public EventBusExtensions(IBusControl busControl)
		{
			if (busControl == null)
				throw new ArgumentNullException(nameof(busControl));

			Log = NullLogger.Instance;
			Bus = busControl;
		}

		#region Trigger

		public void Trigger(Type eventType, IEventData eventData)
		{
			Trigger(eventType, null, eventData);
		}

		public void Trigger(Type eventType, object eventSource, IEventData eventData)
		{
			Bus.Publish(eventData, eventType).Wait();
		}

		public void Trigger<TEventData>(TEventData eventData) where TEventData : IEventData
		{
			Trigger((object)null, eventData);
		}

		public void Trigger<TEventData>(object eventSource, TEventData eventData) where TEventData : IEventData
		{
			Trigger(typeof(TEventData), eventSource, eventData);
		}

		public Task TriggerAsync(Type eventType, IEventData eventData)
		{
			return TriggerAsync(eventType, null, eventData);
		}

		public Task TriggerAsync(Type eventType, object eventSource, IEventData eventData)
		{
			return Bus.Publish(eventData, eventType);
		}

		public Task TriggerAsync<TEventData>(TEventData eventData) where TEventData : IEventData
		{
			return TriggerAsync((object)null, eventData);
		}

		public Task TriggerAsync<TEventData>(object eventSource, TEventData eventData) where TEventData : IEventData
		{
			return Bus.Publish(eventData, typeof(TEventData));
		}

		#endregion

		#region UnAndRegister

		public IDisposable Register(Type eventType, IEventHandlerFactory handlerFactory)
		{
			throw new NotImplementedException();
		}

		public IDisposable Register(Type eventType, IEventHandler handler)
		{
			throw new NotImplementedException();
		}

		public IDisposable Register<TEventData>(IEventHandlerFactory handlerFactory) where TEventData : IEventData
		{
			throw new NotImplementedException();
		}

		public IDisposable Register<TEventData>(IEventHandler<TEventData> handler) where TEventData : IEventData
		{
			throw new NotImplementedException();
		}

		public IDisposable Register<TEventData>(Action<TEventData> action) where TEventData : IEventData
		{
			throw new NotImplementedException();
		}

		public IDisposable Register<TEventData, THandler>()
			where TEventData : IEventData
			where THandler : IEventHandler<TEventData>, new()
		{
			throw new NotImplementedException();
		}

		public void Unregister(Type eventType, IEventHandlerFactory factory)
		{
			throw new NotImplementedException();
		}

		public void Unregister(Type eventType, IEventHandler handler)
		{
			throw new NotImplementedException();
		}

		public void Unregister<TEventData>(IEventHandlerFactory factory) where TEventData : IEventData
		{
			throw new NotImplementedException();
		}

		public void Unregister<TEventData>(IEventHandler<TEventData> handler) where TEventData : IEventData
		{
			throw new NotImplementedException();
		}

		public void Unregister<TEventData>(Action<TEventData> action) where TEventData : IEventData
		{
			throw new NotImplementedException();
		}

		public void UnregisterAll(Type eventType)
		{
			throw new NotImplementedException();
		}

		public void UnregisterAll<TEventData>() where TEventData : IEventData
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}