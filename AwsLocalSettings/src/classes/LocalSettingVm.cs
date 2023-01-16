using System;
using System.Windows.Input;

namespace AwsLocalSettings
{
    public class LocalSettingViewModel
    {
        public LocalSettingData LocalSetting { get; set; }

        public void AddWorkstation()
        {
            // TODO: доработать
        }

        public ICommand ClickAdd
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
                    AddWorkstation();
                });
            }
        }

        public LocalSettingViewModel()
        {
            // TODO: Пока передаем null
            LocalSetting = new LocalSettingData(null);
        }
    }
}
