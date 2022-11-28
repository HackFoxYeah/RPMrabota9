using System;
using System.Collections.Generic;
using System.Windows;
using Пример_таблицы_WPF;

namespace practWork9
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            dataGrid.ItemsSource = _pcList.ToDataTable().DefaultView;
        }

        public List<PcInfo> _pcList = new()
        {
            new PcInfo { processorType = 0, hardDriveSize = 0, memorySize = 0, videoMemorySize = 0 },
            new PcInfo { processorType = 0, hardDriveSize = 0, memorySize = 0, videoMemorySize = 0 },
            new PcInfo { processorType = 0, hardDriveSize = 0, memorySize = 0, videoMemorySize = 0 },
            new PcInfo { processorType = 0, hardDriveSize = 0, memorySize = 0, videoMemorySize = 0 },
            new PcInfo { processorType = 0, hardDriveSize = 0, memorySize = 0, videoMemorySize = 0 }
        };

        private void DataGridCreate_Click(object sender, RoutedEventArgs e)
        {
            _pcList = new()
            {
                new PcInfo { processorType = 0, hardDriveSize = 3500,  memorySize = 3000, videoMemorySize = 2048 },
                new PcInfo { processorType = 1, hardDriveSize = 3600,  memorySize = 4000, videoMemorySize = 3072 },
                new PcInfo { processorType = 2, hardDriveSize = 3700,  memorySize = 5000, videoMemorySize = 4092 },
                new PcInfo { processorType = 3, hardDriveSize = 3800,  memorySize = 6000, videoMemorySize = 5120 },
                new PcInfo { processorType = 4, hardDriveSize = 3900,  memorySize = 7000, videoMemorySize = 6144 }
            };

            dataGrid.ItemsSource = _pcList.ToDataTable().DefaultView;
        }

        private void InsertData_Click(object sender, RoutedEventArgs e)
        {
            SupClass.TbDataValidation(TBcpuType, TBhddSize, TBmemorySize, TBvidRamSize);

            int cpuType;
            float ramSize,
                  hddSize,
                  vidMemSize;

            try
            {
                cpuType = int.Parse(TBcpuType.Text);
                ramSize = float.Parse(TBmemorySize.Text);
                hddSize = float.Parse(TBhddSize.Text);
                vidMemSize = float.Parse(TBvidRamSize.Text);
            }
            catch (FormatException)
            {
                SupClass.TbDataValidation(TBcpuType, TBhddSize, TBmemorySize, TBvidRamSize);
                return;
            }

            SupClass.IsRadioButtonChecked(cpuType, ramSize, hddSize, vidMemSize, _pcList, RBfirst, RBsecond, RBthird, RBfourth, RBfifth);

            dataGrid.ItemsSource = _pcList.ToDataTable().DefaultView;
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            _pcList = new()
            {
                new PcInfo { processorType = 0, hardDriveSize = 0, memorySize = 0, videoMemorySize = 0 },
                new PcInfo { processorType = 0, hardDriveSize = 0, memorySize = 0, videoMemorySize = 0 },
                new PcInfo { processorType = 0, hardDriveSize = 0, memorySize = 0, videoMemorySize = 0 },
                new PcInfo { processorType = 0, hardDriveSize = 0, memorySize = 0, videoMemorySize = 0 },
                new PcInfo { processorType = 0, hardDriveSize = 0, memorySize = 0, videoMemorySize = 0 }
            };

            dataGrid.ItemsSource = _pcList.ToDataTable().DefaultView;
        }
    }
}