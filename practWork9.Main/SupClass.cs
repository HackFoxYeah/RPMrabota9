using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;
using Пример_таблицы_WPF;

namespace practWork9
{
    /// <summary>
    /// Вспомогательный класс.
    /// </summary>
    public class SupClass
    {
        /// <summary>
        /// Реализует работу с радиокнопками.
        /// </summary>
        /// <param name="cpuType">Целочисленное число.</param>
        /// <param name="ramSize">Вещественное число типа float.</param>
        /// <param name="hddSize">Вещественное число типа float.</param>
        /// <param name="vidMemSize">Вещественное число типа float.</param>
        /// <param name="pcList">Список для записи.</param>
        /// <param name="radioButtons">Две и более радиокнопки.</param>
        public static void IsRadioButtonChecked(int cpuType, float ramSize, float hddSize, float vidMemSize, List<PcInfo> pcList, params RadioButton[] radioButtons)
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

        /// <summary>
        /// Реализует валидацию входных данных.
        /// </summary>
        /// <param name="textBoxes">Один или более экземпляров класса TextBox.</param>
        public static void TbDataValidation(params TextBox[] textBoxes)
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
