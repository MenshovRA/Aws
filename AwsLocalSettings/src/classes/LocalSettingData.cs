using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Data;

namespace AwsLocalSettings
{
	public class LocalSettingData : INotifyPropertyChanged
	{
		public class Employee 
		{
			// TODO: это внешний класс
		}

		public class WorkstationInfo : INotifyPropertyChanged
		{
			private string name;
			public string Name 
			{
				get { return name; }
				set
				{
					name = value;
					OnPropertyChanged(nameof(Name));
				}
			}

			private OperationType.Info operationType;
			public OperationType.Info OperationType
			{
				get { return operationType; }
				set
				{
					operationType = value;
					OnPropertyChanged(nameof(OperationType));
				}
			}


            private ConnectionInfo connectionInfo;
            public ConnectionInfo ConnectionInfo
            {
                get { return connectionInfo; }
                set
                {
                    connectionInfo = value;
					OnPropertyChanged(nameof(ConnectionInfo));
                }
            }


            // TODO: это свойство необходимо после убрать - вместо него ConnectionInfo
			private ConnectionType connectionType;
			public ConnectionType ConnectionType
			{
				get { return connectionType; }
				set
				{
					connectionType = value;
					OnPropertyChanged(nameof(ConnectionType));
				}
			}

			private bool enabled;
			public bool Enabled
			{
				get { return enabled; }
				set
				{
					enabled = value;
					OnPropertyChanged(nameof(Enabled));
				}
			}

            // TODO:
			public List<Employee> Emple;

			public WorkstationInfo()
			{
				Emple = new List<Employee>();
                connectionInfo = new ConnectionInfo();
			}

			public event PropertyChangedEventHandler PropertyChanged;
			public void OnPropertyChanged([CallerMemberName] string prop = "")
			{
				if (PropertyChanged != null)
					PropertyChanged(this, new PropertyChangedEventArgs(prop));
			}
		}
        private List<WorkstationInfo> workstation;
		public List<WorkstationInfo> Workstation
        {
            get { return workstation; }
            set
            {
                workstation = Workstation;
                OnPropertyChanged(nameof(Workstation));
            }
        }

		public void ShowSettingPanel()
		{
			var form = new LocalSettingWindow();
			
			form.BtnApply.Click += (s, e) =>
			{
				form.Close();
			};

			form.BtnCancel.Click += (s, e) => form.Close();

			form.BtnAddWorkstation.Click += (s, e) =>
			{
				Workstation.Add(new WorkstationInfo()
				{
					Name = string.Format("Рабочее место №{0:D}", Workstation.Count + 1),
					OperationType = OperationType.GetData()[0],
					ConnectionType = ConnectionType.SERIAL,
					Enabled = false,
				});

                OnPropertyChanged(nameof(Workstation));
                // FIX
				//form.DgWorkstation.ItemsSource = null;
				//form.DgWorkstation.ItemsSource = Workstation;
			};

			form.BtnDelWorkstation.Click += (s, e) =>
			{
			};

            // FIX
			//form.DgWorkstation.ItemsSource = Workstation;
			form.ShowDialog();
		}

		public LocalSettingData(string store_path)
		{
			workstation = new List<WorkstationInfo>();
		}

		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged([CallerMemberName] string prop = "")
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(prop));
		}
	}
}