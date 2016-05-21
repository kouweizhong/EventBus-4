using Abp;
using Abp.Modules;
using System.Reflection;

namespace Sino.EventBus.Test
{
	[DependsOn(typeof(AbpKernelModule))]
	public class EventDataModule : AbpModule
	{
		public override void Initialize()
		{
			IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
		}
	}
}
