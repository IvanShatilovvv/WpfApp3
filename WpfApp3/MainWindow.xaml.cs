using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace BlinkingLights
{
    public partial class MainWindow : Window
    {                                             //Объявялем частные поля, такие как:
        private List <Button> buttons;            //buttons - список кнопок
        private Random random = new Random();     //random является экземпляром класса Random
        public MainWindow()
        {
            InitializeComponent();   //Вызываем метод InitializeComponent
            buttons = new List<Button> { button1, button2, button3, button4, button5, button6, button7, button8 };  
            foreach (var кнопка in buttons)     //Создаём список кнопок, которые будут использоваться как лампочки гирлянды
            {                      //В цикле foreach для каждой кнопки из этого списка устанавливаем случайный цвет фона
                кнопка.Background = GetRandomColor(); //Вызываем метод GetRandomColor
            }
            CompositionTarget.Rendering += BlinkLights;
        }
        private void BlinkLights(object sender, EventArgs e)
        {    //Метод BlinkLights перебирает все кнопки из списка кнопок. Для каждой кнопки меняется цвет фона на случайный
            foreach (var кнопка in buttons)
            {
                if (random.Next(3) == 1)  //С вероятностью 1/3 меняется цвет на случайный
                {
                    кнопка.Background = GetRandomColor(); // Вызываем метод GetRandomColor
                }
            }
        }
        private SolidColorBrush GetRandomColor()  //используем метод GetRandomColor, который генерирует случайный цвет из 256 RGB
        {
            Color цвет = Color.FromRgb((byte)random.Next(256), (byte)random.Next(256), (byte)random.Next(256));
            return new SolidColorBrush(цвет);   //метод GetRandomColor создает новый объект SolidColorBrush с этим цветом, который затем возвращается
        }
    }
}