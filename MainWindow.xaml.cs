using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace XandO
{
    public partial class MainWindow : Window
    {
        Button[] buttons;
        bool user = true;
        public MainWindow()
        {
            InitializeComponent();
            buttons = new Button[] { b1, b2, b3, b4, b5, b6, b7, b8, b9 };
        }

        Random rnd = new Random();
        private void AI(bool III)
        {
            Button[] buttons = new Button[] { b1, b2, b3, b4, b5, b6, b7, b8, b9 };
            int box = 0;

            for (int attempt = 0; attempt < 10; attempt++)
            {
                int choice = rnd.Next(buttons.Length);

                if (string.IsNullOrEmpty(buttons[choice].Content as string))
                {
                    buttons[choice].Content = III ? "O" : "X";
                    break;
                }

                box++;
            }
        }
        private void START_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                Button button = buttons[i];
                button.IsEnabled = true;
                button.Content = "";
            }

            START.Content = "Reset";

            if (!user)
            {
                AI(user);
            }

            Label.Content = "";
        }

        double player = 0;
        private void b1_Click(object sender, RoutedEventArgs e)
        {
            switch (player)
            {
                case 0:
                    sender.GetType().GetProperty("Content").SetValue(sender, "X");
                    player = 1;
                    Label.Content = "Игрок 1";
                    break;
                case 1:
                    sender.GetType().GetProperty("Content").SetValue(sender, "O");
                    player = 0;
                    Label.Content = "Игрок 2";
                    break;
            }
            WinCheck();
        }

        void WinCheck()
        {
            if (b1.Content == b2.Content && b2.Content == b3.Content && b1.Content != "")
            {
                MessageBox.Show("Победа!!!");
            }
            else if (b4.Content == b5.Content && b5.Content == b6.Content && b4.Content != "")
            {
                MessageBox.Show("Победа!!!");
            }
            else if (b7.Content == b8.Content && b8.Content == b9.Content && b7.Content != "")
            {
                MessageBox.Show("Победа!!!");
            }
            else if (b1.Content == b4.Content && b4.Content == b7.Content && b1.Content != "")
            {
                MessageBox.Show("Победа!!!");
            }
            else if (b2.Content == b5.Content && b5.Content == b8.Content && b2.Content != "")
            {
                MessageBox.Show("Победа!!!");
            }
            else if (b3.Content == b6.Content && b6.Content == b9.Content && b3.Content != "")
            {
                MessageBox.Show("Победа!!!");
            }
            else if (b1.Content == b5.Content && b5.Content == b9.Content && b9.Content != "")
            {
                MessageBox.Show("Победа!!!");
            }
            else if (b3.Content == b5.Content && b5.Content == b7.Content && b3.Content != "")
            {
                MessageBox.Show("Победа!!!");
            }

        }

        private void WonMessage(bool user)
        {
            Label.Content = user ? "Победа!" : "Бот победил :(";
        }

        private void WonFriends()
        {
            Label.Content = "Ничья 0-0";
        }


    }
}