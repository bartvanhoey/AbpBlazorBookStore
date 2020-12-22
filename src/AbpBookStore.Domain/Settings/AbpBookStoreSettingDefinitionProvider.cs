using Volo.Abp.Settings;

namespace AbpBookStore.Settings
{
    public class AbpBookStoreSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(AbpBookStoreSettings.MySetting1));
        }
    }
}
