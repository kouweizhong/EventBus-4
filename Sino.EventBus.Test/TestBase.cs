using Abp.TestBase;
using Abp.Collections;
using Abp.Modules;

namespace Sino.EventBus.Test
{
	public abstract class TestBase : AbpIntegratedTestBase
	{
		protected override void PreInitialize()
		{
			base.PreInitialize();
		}

		protected override void AddModules(ITypeList<AbpModule> modules)
		{
			base.AddModules(modules);
			modules.Add<EventDataModule>();
			modules.Add<EventBusModule>();
		}
	}
}
