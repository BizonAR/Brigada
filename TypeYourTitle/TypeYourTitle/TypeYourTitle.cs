using System;
using System.Windows;//пространство имен включающая в себя классы: Window, Application, base
using System.Windows.Input;// Пространство имен WPF System.Windows включающая в себя классы:TextCompositionEventArgs
namespace Baruzdin.TypeYourTitle
{
    public class TypeYourTitle : Window //создаем открытый класс TypeYourTitle, который является наследственником класса Window (window-производная от DispatcherObject)
    {
        [STAThread]//атрибут означающий, что основной программный поток приложения должен использовать однопточную модель. это необходимо для взаимодействия с подсистемой COM.
        public static void Main()  // метод Main
        {
            Application app = new Application();//(обьект Application - производная от DispatcherObject) в программе может быть единственным 
            app.Run(new TypeYourTitle());//метод Run(весь жизненый цикл программы проходит во время выполнения run, только после вызова метода Run объект Window  может реагировать на действия пользователя)
        }
        protected override void OnTextInput(TextCompositionEventArgs args)
        {
            base.OnTextInput(args);
            if (args.Text == "\b" && Title.Length > 0)//Backspace("\b")-единственный управляющий символ, если Title содержит хотя бы один символ
                Title = Title.Substring(0, Title.Length - 1);
            else if (args.Text.Length > 0 && !Char.IsControl(args.Text[0])) Title += args.Text;
        }
    }
}
