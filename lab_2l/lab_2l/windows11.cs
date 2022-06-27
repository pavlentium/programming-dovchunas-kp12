using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace lab_2l
{
    class Win1
    {
        public Win1()
        {
            initControls();
        }
        public static Brush Color(string clr)
        {
            var converter = new BrushConverter();
            var brush = (Brush)converter.ConvertFromString(clr);
            return brush;
        }
        Grid myGrid = new Grid();
        public Window wn = new Window();
        private void initControls()
        {
            wn.Title = "Student";
            wn.Width = 800; wn.Height = 400;
            myGrid.Width = 800; myGrid.Height = 400;
            
            myGrid.HorizontalAlignment = HorizontalAlignment.Center;
            myGrid.VerticalAlignment = VerticalAlignment.Center;
            for (int i = 0; i < 4; i++)
            {
                TextBox tb = new TextBox();
                tb.HorizontalAlignment = HorizontalAlignment.Left; tb.Height = 30;
                tb.Width = 251; tb.FontSize = 18; tb.TextWrapping = TextWrapping.Wrap;
                tb.VerticalAlignment = VerticalAlignment.Top;
                
                if (i != 3) tb.Margin = new Thickness(36, 50 + i * 35, 0, 0);
                else tb.Margin = new Thickness(36, 203, 0, 0);
                if (i == 0) tb.Name = "CreditBook";
                if (i == 1) tb.Name = "FullName";
                if (i == 2) tb.Name = "Data";
                if (i == 3) tb.Name = "CreditBookDlt";
                myGrid.Children.Add(tb);
            }
            for (int i = 0; i < 4; i++)
            {
                Label lbl = new Label();
                lbl.HorizontalAlignment = HorizontalAlignment.Left;
                lbl.VerticalAlignment = VerticalAlignment.Top;
                lbl.Height = 30; lbl.Width = 192; lbl.FontSize = 20;
                
                if (i != 3) lbl.Margin = new Thickness(292, 50 + i * 35, 0, 0);
                else lbl.Margin = new Thickness(292, 203, 0, 0);
                myGrid.Children.Add(lbl);
                if (i == 0 || i == 3) lbl.Content = "№Залікової книжки";
                if (i == 1) lbl.Content = "ПІП";
                if (i == 2) lbl.Content = "Особисті дані";
            }
            for (int i = 0; i < 4; i++)
            {
                Button btn = new Button
                {
                    Margin = new Thickness(529, i * 110 - 100, 50, 150),
                    Width = 183,
                    Height = 51,
               
                    FontSize = 18
                };
                if (i == 0)
                {
                    btn.Name = "WriteDataBtn";
                    btn.Content = "WRITE TO FILE";
                    btn.Click += Write_Btn;
                }
                if (i == 1)
                {
                    btn.Name = "CheckBtn";
                    btn.Content = "CHECK DATA";
                    btn.Click += Check_Btn;
                }
                if (i == 2)
                {
                    btn.Name = "DeleteDataBtn";
                    btn.Content = "DELETE DATA";
                    btn.Click += Delete_Btn;
                    btn.Margin = new Thickness(529, i * 110 - 100, 50, 100);
                }
                if (i == 3)
                {
                    btn.Click += Exit_Btn_Click;
                    btn.Name = "Exit_Btn_Click";
                    btn.Content = "main";
                    btn.Margin = new Thickness(0, 272, 0, 0);
                }
                myGrid.Children.Add(btn);
            }
            wn.Content = myGrid;
            wn.Show();
        }
        private void Exit_Btn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            wn.Close();
            mw.Show();
        }

        private void Write_Btn(object sender, RoutedEventArgs e)
        {
            string creditBook = "", fullName = "", data = "";
            foreach (TextBox b in myGrid.Children.OfType<TextBox>())
            {
                if (b.Name == "CreditBook") creditBook = b.Text;
                if (b.Name == "FullName") fullName = b.Text;
                if (b.Name == "Data") data = b.Text;
            }
            StreamReader file = new StreamReader("StudentData.txt");
            string dataFromFile = file.ReadToEnd();
            file.Close();
            StreamWriter MyFileA = new StreamWriter("StudentData.txt");
            MyFileA.Write(dataFromFile);
            MyFileA.Write($"№Залікової: {creditBook}; ПІП: {fullName}; Особисті дані:{data}\n");
            MyFileA.Close();
            foreach (TextBox b in myGrid.Children.OfType<TextBox>()) b.Text = "";
        }

        private void Delete_Btn(object sender, RoutedEventArgs e)
        {
            string creditBookDlt = "";
            foreach (TextBox b in myGrid.Children.OfType<TextBox>())
            {
                if (b.Name == "CreditBookDlt") creditBookDlt = b.Text;
                b.Text = "";
            }
            StreamReader fileRem = new StreamReader("StudentData.txt");
            string dataFromFile = fileRem.ReadToEnd();
            fileRem.Close();
            StreamReader file = new StreamReader("StudentData.txt");
            while (!file.EndOfStream)
            {
                string DeleteStr = file.ReadLine();

                if (creditBookDlt == DeleteStr.Split(' ')[1].Trim(';'))
                {
                    file.Close();
                    StreamWriter fileDlt = new StreamWriter("StudentData.txt");
                    fileDlt.Write(dataFromFile.Replace("\n" + DeleteStr, ""));
                    fileDlt.Close();
                    break;
                }
            }
            file.Close();
        }
        bool checkDataBtn = true;
        private void Check_Btn(object sender, RoutedEventArgs e)
        {
            StreamReader check = new StreamReader("StudentData.txt");
            if (checkDataBtn)
            {
                checkDataBtn = false;
                foreach (TextBox tb in myGrid.Children.OfType<TextBox>()) tb.Visibility = Visibility.Hidden;
                foreach (Label b in myGrid.Children.OfType<Label>()) b.Visibility = Visibility.Hidden;
                foreach (Button b in myGrid.Children.OfType<Button>())
                {
                    if (b.Name != "CheckBtn") b.IsEnabled = false;
                    else b.Content = "STOP CHECKING";
                }
                TextBlock textBlock = new TextBlock
                {
                    HorizontalAlignment = HorizontalAlignment.Left,
                    Margin = new Thickness(36, 27, 0, 0),
                    TextWrapping = TextWrapping.Wrap,
                    Text = check.ReadToEnd(),
                    Height = 240,
                    Width = 488,
                    VerticalAlignment = VerticalAlignment.Top,
                    Name = "CheckDataLabel",
                    FontSize = 16
                };
                check.Close();
                myGrid.Children.Add(textBlock);
            }
            else
            {
                foreach (TextBox textBox in myGrid.Children.OfType<TextBox>()) textBox.Visibility = Visibility.Visible;
                foreach (Label b in myGrid.Children.OfType<Label>()) b.Visibility = Visibility.Visible;
                foreach (Button b in myGrid.Children.OfType<Button>())
                {
                    if (b.Name != "CheckBtn")
                    {
                        b.IsEnabled = true;
                    }
                    else
                    {
                        b.Content = "CHECK DATA";
                    }
                }
                TextBlock tb = new TextBlock();
                foreach (TextBlock t in myGrid.Children.OfType<TextBlock>())
                {
                    if (t.Name == "CheckDataLabel")
                    {
                        tb = t;
                    }
                }
                myGrid.Children.Remove(tb);
                checkDataBtn = true;
            }
        }
    }
    class Win2
    {

        public Win2()
        {
            initControls();
        }
        public static Brush Color(string clr)
        {
            var converter = new BrushConverter();
            var brush = (Brush)converter.ConvertFromString(clr);
            return brush;
        }
        private void Exit_Btn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            wn.Close();
            mw.Show();
        }
        static bool check = false;
        static string FirstPart = "";
        static string SecondPart = "";
        static string Action = "";
        Label MainRect = new Label { Name = "MainRect" };
        Grid myGrid = new Grid();
        public Window wn = new Window();
        private void initControls()
        {
            wn.Title = "Calculator";
            wn.Width = 510; wn.Height = 680;
            myGrid.Width = 510; myGrid.Height = 680;
          
            myGrid.HorizontalAlignment = HorizontalAlignment.Center;
            myGrid.VerticalAlignment = VerticalAlignment.Center;
            Label lbl = new Label
            {
                
                Content = "",
                
                HorizontalAlignment = HorizontalAlignment.Left,
                Height = 90,
                Margin = new Thickness(20, 38, 0, 0),
                VerticalAlignment = VerticalAlignment.Top,
                Width = 471,
                FontSize = 46,
                Name = "MainRect",
                HorizontalContentAlignment = HorizontalAlignment.Right,
            };
            myGrid.Children.Add(lbl);
            foreach (Label lb in myGrid.Children.OfType<Label>())
            {
                if (lb.Name == "MainRect")
                {
                    MainRect = lb;
                    break;
                }
            }
            int counterBtn = 1;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Button btn = new Button
                    {
                        Margin = new Thickness(22 + j * 116, 150 + i * 83, 0, 0),
                        Height = 80,
                        Width = 114,
                        HorizontalAlignment = HorizontalAlignment.Left,
                        VerticalAlignment = VerticalAlignment.Top,
                        FontSize = 43,
                    };
                    if (i < 4 && i > 0 && j < 3)
                    {
                        btn.Content = counterBtn;
                        counterBtn++;
                    }
                    if (i == 4)
                    {
                        if (j == 1) btn.Content = 0;
                        if (j == 2) btn.Content = ",";
                    }
                    if (i == 0)
                    {
                        if (j == 1) btn.Content = "=";
                        if (j == 2) btn.Content = "C";
                        if (j == 3) btn.Content = "⌫";
                    }
                    btn.Click += NumBtn;
                    if (j == 1 && i == 0)
                    {
                        btn.Click -= NumBtn;
                        btn.Click += ActionFunc;
                    }
                    if (j == 3)
                    {
                        if (i == 1)
                        {
                            btn.Content = "÷";
                            btn.Click -= NumBtn;
                            btn.Click += ActionFunc;
                        }
                        if (i == 2)
                        {
                            btn.Content = "x";
                            btn.Click -= NumBtn;
                            btn.Click += ActionFunc;
                        }
                        if (i == 3)
                        {
                            btn.Content = "-";
                            btn.Click -= NumBtn;
                            btn.Click += ActionFunc;
                        }
                        if (i == 4)
                        {
                            btn.Content = "+";
                            btn.Click -= NumBtn;
                            btn.Click += ActionFunc;
                        }
                    }
                    if (i == 0 && j == 2) btn.Click += Clean;
                    if (i == 0 && j == 3) btn.Click += Rem;
                    myGrid.Children.Add(btn);
                }
            }
            Button Back = new Button
            {
                Content = "main",
                Margin = new Thickness(155, 571, 0, 0),
                VerticalAlignment = VerticalAlignment.Top,
                Width = 183,
                Height = 51,
                FontSize = 22,
                HorizontalAlignment = HorizontalAlignment.Left,
            };
            Back.Click += Exit_Btn_Click;
            myGrid.Children.Add(Back);
            wn.Content = myGrid;
            wn.Show();
        }
        private void Clean(object sender, RoutedEventArgs e)
        {
            foreach (Label b in myGrid.Children.OfType<Label>()) b.Content = "";
        }

        private void NumBtn(object sender, RoutedEventArgs e)
        {
            if (check)
            {
                MainRect.Content = "";
                check = false;
            }
            string num = sender.ToString().Split(' ')[1];
            MainRect.Content += num;
        }

        private void Rem(object sender, RoutedEventArgs e)
        {
            string content = MainRect.Content.ToString();
            if (content.Length > 0) MainRect.Content = content.Remove(content.Length - 1);
        }

        private void ActionFunc(object sender, RoutedEventArgs e)
        {
            if (FirstPart != "")
            {
                SecondPart = MainRect.Content.ToString();
                switch (Action)
                {
                    case "÷":
                        MainRect.Content = Convert.ToDouble(FirstPart) / Convert.ToDouble(SecondPart);
                        break;
                    case "x":
                        MainRect.Content = Convert.ToDouble(FirstPart) * Convert.ToDouble(SecondPart);
                        break;
                    case "-":
                        MainRect.Content = Convert.ToDouble(FirstPart) - Convert.ToDouble(SecondPart);
                        break;
                    case "+":
                        MainRect.Content = Convert.ToDouble(FirstPart) + Convert.ToDouble(SecondPart);
                        break;
                }
                Action = sender.ToString().Split(' ')[1];
                FirstPart = MainRect.Content.ToString();
            }
            else
            {
                Action = sender.ToString().Split(' ')[1];
                FirstPart = MainRect.Content.ToString();
            }
            check = true;
        }
    }
    class Win3
    {
        public Win3()
        {
            InitControls();
        }
        public static Brush Color(string clr)
        {
            var converter = new BrushConverter();
            var brush = (Brush)converter.ConvertFromString(clr);
            return brush;
        }
        Grid myGrid = new Grid();
        public Window wn = new Window();
        bool IsX = true;
        private void InitControls()
        {
            wn.Title = "TicTacToeWin";
            wn.Width = 350; wn.Height = 600;
            myGrid.Width = 350; myGrid.Height = 600;
            myGrid.Background = Color("#852AE4");
            myGrid.HorizontalAlignment = HorizontalAlignment.Center;
            myGrid.VerticalAlignment = VerticalAlignment.Center;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Button btn = new Button
                    {
                        HorizontalAlignment = HorizontalAlignment.Left,
                        Margin = new Thickness(40 + 53 * j, 27 + i * 55, 0, 0),
                        VerticalAlignment = VerticalAlignment.Top,
                        Content = "",
                        Width = 48,
                        Height = 50,
                        Name = $"But_{i}_{j}",
                        FontSize = 28,
                    };
                    btn.Click += Button_Click;
                    myGrid.Children.Add(btn);
                }
            }
            Button button = new Button
            {
                Content = "main",
                Margin = new Thickness(77, 507, 84, 0),
                VerticalAlignment = VerticalAlignment.Top,
                Width = 183,
                Height = 51,
                FontSize = 23,
                HorizontalAlignment = HorizontalAlignment.Center,
            };
            button.Click += Exit_Btn_Click;
            myGrid.Children.Add(button);
            Label lbl = new Label
            {
                Content = "",
                HorizontalAlignment = HorizontalAlignment.Left,
                Height = 50,
                Margin = new Thickness(40, 357, 0, 0),
                VerticalAlignment = VerticalAlignment.Top,
                Width = 200,
                FontSize = 36
            };
            myGrid.Children.Add(lbl);
            wn.Content = myGrid;
            wn.Show();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int[,] arrBtn = new int[5, 5];
            Button btn = (Button)e.OriginalSource;
            if (IsX) btn.Content = "X";
            else btn.Content = "O";
            IsX = !IsX;
            btn.IsEnabled = false;
            foreach (Button bttn in myGrid.Children.OfType<Button>())
            {
                if (bttn.Content.ToString() == "main") break;
                int i = Convert.ToInt32(bttn.Name.ToString().Split('_')[1]);
                int j = Convert.ToInt32(bttn.Name.ToString().Split('_')[2]);
                int toAdd;
                if (bttn.Content.ToString() == "") toAdd = -1;
                else if (bttn.Content.ToString() == "X") toAdd = 0;
                else toAdd = 1;
                arrBtn[i, j] = toAdd;
            }
            foreach (Label lbl in myGrid.Children.OfType<Label>())
            {
                lbl.Content = AnalyseWinner(arrBtn);
                if (lbl.Content.ToString() != "")
                {
                    foreach (Button bttn in myGrid.Children.OfType<Button>())
                    {
                        bttn.IsEnabled = false;
                        if (bttn.Content.ToString() == "main") bttn.IsEnabled = true;
                    }
                }
            }
        }
        private void Exit_Btn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            wn.Close();
            mw.Show();
        }
        private string AnalyseWinner(int[,] area)
        {
            int counterx = 0;
            int countero = 0;

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (area[i, j] == 0) counterx++;
                    if (area[i, j] == 1) countero++;
                }
                if (countero >= 4) return "Winner: O";
                if (counterx >= 4) return "Winner: X";
                counterx = countero = 0;
            }
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (area[j, i] == 0) counterx++;
                    if (area[j, i] == 1) countero++;
                }
                if (countero >= 4) return "Winner: O";
                if (counterx >= 4) return "Winner: X";
                counterx = countero = 0;
            }
            for (int i = 0; i < 5; i++)
            {
                if (area[i, i] == 0) counterx++; if (area[i, i] == 1) countero++;
                if (countero >= 4) return "Winner: O"; if (counterx >= 4) return "Winner: X";
            }
            countero = counterx = 0;
            for (int i = 0; i < 5; i++)
            {
                if (area[i, 4 - i] == 0) counterx++; if (area[i, 4 - i] == 1) countero++;
                if (countero >= 4) return "Winner: O"; if (counterx >= 4) return "Winner: X";
            }
            countero = counterx = 0;
            for (int i = 1; i < 5; i++)
            {
                if (area[i, i - 1] == 0) counterx++; if (area[i, i - 1] == 1) countero++;
                if (countero >= 4) return "Winner: O"; if (counterx >= 4) return "Winner: X";
            }
            countero = counterx = 0;
            for (int i = 1; i < 5; i++)
            {
                if (area[i - 1, i] == 0) counterx++; if (area[i - 1, i] == 1) countero++;
                if (countero >= 4) return "Winner: O"; if (counterx >= 4) return "Winner: X";
            }
            countero = counterx = 0;
            for (int i = 0; i < 4; i++)
            {
                if (area[i, 3 - i] == 0) counterx++; if (area[i, 3 - i] == 1) countero++;
                if (countero >= 4) return "Winner: O"; if (counterx >= 4) return "Winner: X";
            }
            countero = counterx = 0;
            for (int i = 1; i < 5; i++)
            {
                if (area[i, 5 - i] == 0) counterx++; if (area[i, 5 - i] == 1) countero++;
                if (countero >= 4) return "Winner: O"; if (counterx >= 4) return "Winner: X";
            }
            return "";
        }
    }
    class Win4
    {
        public Win4()
        {
            InitControls();
        }
        public static Brush Color(string clr)
        {
            var converter = new BrushConverter();
            var brush = (Brush)converter.ConvertFromString(clr);
            return brush;
        }
        private void Exit_Btn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            wn.Close();
            mw.Show();
        }
        Grid myGrid = new Grid();
        public Window wn = new Window();
        private void InitControls()
        {
            wn.Width = 800; wn.Height = 350;
            myGrid.Width = 800; myGrid.Height = 350;
            myGrid.HorizontalAlignment = HorizontalAlignment.Center;
            myGrid.VerticalAlignment = VerticalAlignment.Center;
            TextBlock label = new TextBlock
            {
                Text = "ПІП: Довчунас Павло Юрійович\nДата створення: 27.05.2022\nГрупа: КП-12",
                HorizontalAlignment = HorizontalAlignment.Left,
                Background = null,
                Height = 200,
                Margin = new Thickness(66, 88, 0, 0),
                VerticalAlignment = VerticalAlignment.Top,
                Width = 675,
                FontSize = 40
            };
            Button button = new Button
            {
                Content = "main",
                Margin = new Thickness(514, 252, 0, 0),
                VerticalAlignment = VerticalAlignment.Top,
                Width = 183,
                Height = 51,
                FontSize = 20,
                HorizontalAlignment = HorizontalAlignment.Center,
            };
            button.Click += Exit_Btn_Click;
            myGrid.Children.Add(button);
            myGrid.Children.Add(label);
            wn.Content = myGrid;
            wn.Show();
        }
    }
}