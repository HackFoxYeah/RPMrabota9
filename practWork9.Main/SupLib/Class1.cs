using System.Collections.Generic;
using System.Windows.Controls;

namespace practWork9
{
    public class SupClass
    {
        public static void DataUpdate(DataGrid dG, ref float[][] data, List<PcInfo> pcList)
        {
            for (int i = 0; i < pcList.Count; i++)
            {
                data[i][0] = pcList[i].processorType;
                data[i][1] = pcList[i].memorySize;
                data[i][2] = pcList[i].hardDriveSize;
                data[i][3] = pcList[i].videoMemorySize;
            }
            dG.ItemsSource = VisualArray.ToDataTable(data).DefaultView;
        }

        public void IsRadioButtonChecked(float cpuType, float ramSize, float hddSize, float vidMemSize, List<PcInfo> pcList, params RadioButton[] radioButtons)
        {
            for (int i = 0; i < radioButtons.Length; i++)
            {
                if ((bool)radioButtons[i].IsChecked)
                {
                    pcList[i] = pcList[i] with
                    {
                        processorType = cpuType,
                        memorySize = ramSize,
                        hardDriveSize = hddSize,
                        videoMemorySize = vidMemSize
                    };
                }
            }
        }

        public void TbDataValidation(params TextBox[] textBoxes)
        {
            for (int i = 0; i < textBoxes.Length; i++)
            {
                if (textBoxes[i].BorderBrush == Brushes.Red)
                    textBoxes[i].BorderBrush = Brushes.Gray;

                if (!float.TryParse(textBoxes[i].Text, out _))
                    textBoxes[i].BorderBrush = Brushes.Red;
            }
        }
    }
}
