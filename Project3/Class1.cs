using System;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Project3
{
    public class FlipThroughTheBrushes : Window //наследованием от класса Windows объявляется класс FlipThroughTheBrushes
    {
        private int index = 0; //объявляется приватная переменная типа int
        private PropertyInfo[] props; //объявляется приватный массив props объектов класса PropertyInfo

        [STAThread] //атрибут для исполнения одопоточной модели
        public static void Main()
        {
            Application app = new Application();
            app.Run(new FlipThroughTheBrushes());
        }

        public FlipThroughTheBrushes()
        {
            props = typeof(Brushes).GetProperties(BindingFlags.Public | BindingFlags.Static); //массиву props присваиваются публичные и статичные свойства Brushes

        }

        protected override void OnKeyDown(KeyEventArgs e) //переопределение метода OnKeyDown класса KeyEventArgs
        {
            if (e.Key == Key.Down || e.Key == Key.Up) //проверка нажатия клавиш вверх или вниз
            {
                index += e.Key == Key.Up ? 1 : props.Length - 1; //в зависимости от нажатой клавиши изменяется значение index
                index %= props.Length; //остаток от данного деления определяет значение index (номера цвета)
                SetTitleAndBackground(); //вызывается метод SetTitleAndBackground
            }
            base.OnKeyDown(e); //вызывает конструктор OnKeyDown из родительского класса
        }

        void SetTitleAndBackground()
        {
            Title = "Flip through the brushes - " + props[index].Name; //Заголовок окна с указанием названия цвета
            Background = (Brush)props[index].GetValue(null, null); //Фону задаётся значение цвета под номером index
        }
    }
}