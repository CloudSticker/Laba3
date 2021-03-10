using System;
using System.Collections.Generic;
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
using System.Text.RegularExpressions;
using System.Globalization;

namespace X_0
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 
    
    public partial class MainWindow : Window
    {
        Graph graph = new Graph();
        WhoIsWin trn = new WhoIsWin();
        List<Line> lineList = new List<Line>();
        List<Line> Cross = new List<Line>();
        public static double CanvasX;
        public static double CanvasY;
        public static double BlockX;
        public static double BlockY;
        public static int CountOfCell = 10;
        public static int[,] arr = new int[CountOfCell, CountOfCell];
        internal bool Turn = true;
        static string name1 = "Player2";
        static string name2 = "Player1";
        static int Pl1Count = 0;
        static int Pl2Count = 0;
        public static bool gameStop = true;

        public MainWindow()
        {
            InitializeComponent();
            lineList = graph.Grid(Canvas1.Height, Canvas1.Width, CountOfCell);
            for (int i = 0; i < CountOfCell; i++)
                for (int j = 0; j < CountOfCell; j++)
                    arr[i, j] = 0;

            
           

            ClearCanvas();
            CanvasX = Canvas1.Width;
            CanvasY = Canvas1.Height;
        }

        public void ClearCanvas()
        {
            Canvas1.Children.Clear();
            Canvas1.Background = Brushes.White;
            

            for (int i = 0; i < lineList.Count; i++)
                Canvas1.Children.Add(lineList[i]);

            Line line = new Line();
            line.X1 = 0;
            line.Y1 = 0;
            line.X2 = Canvas1.Width;
            line.Y2 = 0;
            line.StrokeThickness = 5;
            line.Stroke = Brushes.Green;
            Canvas1.Children.Add(line);

            Line line1 = new Line();
            line1.X1 = 0;
            line1.Y1 = 0;
            line1.X2 = 0;
            line1.Y2 = Canvas1.Height;
            line1.StrokeThickness = 5;
            line1.Stroke = Brushes.Green;
            Canvas1.Children.Add(line1);

            Line line2 = new Line();
            line2.X1 = 0;
            line2.Y1 = Canvas1.Height;
            line2.X2 = Canvas1.Width;
            line2.Y2 = Canvas1.Height;
            line2.StrokeThickness = 5;
            line2.Stroke = Brushes.Green;
            Canvas1.Children.Add(line2);

            Line line3 = new Line();
            line3.X1 = Canvas1.Width;
            line3.Y1 = 0;
            line3.X2 = Canvas1.Width;
            line3.Y2 = Canvas1.Height;
            line3.StrokeThickness = 5;
            line3.Stroke = Brushes.Green;
            Canvas1.Children.Add(line3);
        }
        void  CoordinatesXY(ref double X, ref double Y)
        {
            X = Math.Round(CanvasX / CountOfCell) * Math.Floor(X / Math.Round(CanvasX / CountOfCell));
            Y = Math.Round(CanvasY / CountOfCell) * Math.Floor(Y / Math.Round(CanvasY / CountOfCell));  
        }

        private void Canvas1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
            name1 = Name1.Text;
            name2 = Name2.Text;

            Point p = Mouse.GetPosition(Canvas1);
            BlockX = p.X;
            BlockY = p.Y;
            CoordinatesXY(ref BlockX, ref BlockY);

           if (gameStop)
            {

            
               if (arr[Convert.ToInt32(Math.Floor(BlockX / Math.Round(CanvasX / CountOfCell))), Convert.ToInt32(Math.Floor(BlockY / Math.Round(CanvasY / CountOfCell)))] == 0)
                {
                    if (Turn)
                    {
                        Turn = !Turn;
                        Cross = graph.DrawCross(BlockX, BlockY, Canvas1.Width, Canvas1.Height, CountOfCell);
                        for (int i = 0; i < Cross.Count; i++)
                        {
                            Canvas1.Children.Add(Cross[i]);
                        }
                    }
                    else
                    {
                        Turn = !Turn;
                        Canvas1.Children.Add(graph.DrawCircle(BlockX, BlockY, Canvas1.Width, Canvas1.Height, CountOfCell)); 
                    }
                
                }
                if (Turn)
                {
                    arr[Convert.ToInt32(Math.Floor(BlockX / Math.Round(CanvasX / CountOfCell))), Convert.ToInt32(Math.Floor(BlockY / Math.Round(CanvasY / CountOfCell)))] = 1;
                }
                else
                {
                    arr[Convert.ToInt32(Math.Floor(BlockX / Math.Round(CanvasX / CountOfCell))), Convert.ToInt32(Math.Floor(BlockY / Math.Round(CanvasY / CountOfCell)))] = 2;
                }
                int[] Ansarr = trn.CheckTurn(arr);


                for (int t = 0; t < 4; t++)
                { 
                    if (Ansarr[t] != 0)
                    {
                    
                        WinBox task1 = new WinBox();
                        if (Turn)
                        {
                            Pl1Count++;
                            task1.nameSet(name1);
                        }
                        else
                        {
                            Pl2Count++;
                            task1.nameSet(name2);
                        }

                        name1 = Name1.Text;
                        name2 = Name2.Text;
                        gameStop = false;

                        task1.Show();
                        break;
                    }
                }
            }
        }


        private void MainWindow1_Activated(object sender, EventArgs e)
        {
            ScoreLbl.Content = $"{Pl2Count}:{Pl1Count}";
            Name1.Text = name1;
            Name2.Text = name2;
        }

        private void RestartScore_Click(object sender, RoutedEventArgs e)
        {
            gameStop = true;
            ClearCanvas();
            for (int i = 0; i < CountOfCell; i++)
                for (int j = 0; j < CountOfCell; j++)
                    arr[i, j] = 0;
        }

        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            ClearCanvas();
            Pl1Count = 0;
            Pl2Count = 0;
            ScoreLbl.Content = $"{Pl2Count}:{Pl1Count}";
            for (int i = 0; i < CountOfCell; i++)
                for (int j = 0; j < CountOfCell; j++)
                    arr[i, j] = 0;
        }
    }
}
