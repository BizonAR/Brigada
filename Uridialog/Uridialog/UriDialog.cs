
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
namespace nikbarale.NavigateTheWeb
{
    class UriDialog : Window//Uri dialog наследик Window
    {
        TextBox txtbox;//создаем класс txtboc с помощью которого пользователь может вводить текст в приложении
        public UriDialog()//задаем значения нескольких свойств класса
        {
            Title = "Enter a URI";//заголовок окна
            ShowInTaskbar = false;//не показывается в панеле задач
            SizeToContent = SizeToContent.WidthAndHeight;//автоматически изменяет размер по размеру содержимого
            WindowStyle = WindowStyle.ToolWindow;//задаем стиль границы окна( допускается изменение размеров окна, но не имеет кнопок сворачивания/разворачивания)
            WindowStartupLocation = WindowStartupLocation.CenterOwner;// открывется по центру своего владельца
            txtbox = new TextBox();//инициализируем класс txtbox
            txtbox.Margin = new Thickness(48);//Свойство Margin определяет поле вокруг элемента управления, Thickness определяет толщину рамки
            Content = txtbox;//задаем содержимое обьекта ContentControl в виде нашего txtbox
            txtbox.Focus();//Возвращает значение, указывающее, имеется ли на txtbox фокус ввода.
        }
        public string Text//предоставляем доступ к свойству text элемента txtbox
        {
            set
            {
                txtbox.Text = value;//получаем строку
                txtbox.SelectionStart = txtbox.Text.Length;//перемещаем точку вставки справа от последнего символа
            }
            get
            {
                return txtbox.Text;//возвращаем полученную строку
            }
        }
        protected override void OnKeyDown(KeyEventArgs args)//переопределяем метод OnKeyDown, что бы можно было закрыть окно клавишей enter, KeyEventArgs - класс включающий в себя Key 
        {
            if (args.Key == Key.Enter) Close();// args.key получет данные с клавиатуры  
        }
    }
    public class NavigateTheWeb : Window 
    { 
        Frame frm;
        [STAThread] 
        public static void Main() 
        { 
            Application app = new Application();
            app.Run(new NavigateTheWeb());
        } 
        public NavigateTheWeb() 
        { 
            Title = "Navigate the Web";
            frm = new Frame();
            Content = frm;
            Loaded += OnWindowLoaded;
        } 
        void OnWindowLoaded(object sender, RoutedEventArgs args) 
        {
            UriDialog dlg = new UriDialog();
            dlg.Owner = this;
            dlg.Text = "http://";
            dlg.ShowDialog();
            try 
            {
                frm.Source = new Uri(dlg.Text); 
            } 
            catch (Exception exc) 
            { 
                MessageBox.Show(exc.Message, Title); 
            } 
        } 
    }
}