using System;

namespace AwsLocalSettings
{
    public class LocalSettingViewModel
    {
        public LocalSettingData LocalSetting { get; set; }

        public LocalSettingViewModel()
        {
            // TODO: Пока передаем null
            LocalSetting = new LocalSettingData(null);
        }
    }
}
