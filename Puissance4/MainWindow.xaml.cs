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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Puissance4
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string player = "Red";
        List<List<string>> TileColor = new List<List<string>>();
        
        


        Dictionary<int, int> PlayerMap = new Dictionary<int, int>()//numero de la colonne, nombre de pieces dans la colonne
        {
            {1, 0},
            {2, 0},
            {3, 0},
            {4, 0}, 
            {5, 0},
            {6, 0},
            {7, 0},
        };
        int playerPosition = 1;
        

        public MainWindow()
        {
            InitializeComponent();


            Canvas01.Focus();//nécéssaire au fonctionnement des keyDown
        }

        private void Canvas01_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                //faire se déplacer le jeton player
                case Key.Left:
                    if(playerPosition > 1)
                    {
                        Canvas.SetLeft(PlayerToken1, Canvas.GetLeft(PlayerToken1) - 50);
                        playerPosition--;
                    }
                    break;
                case Key.Right:
                    if(playerPosition < 7)
                    {
                        Canvas.SetLeft(PlayerToken1, Canvas.GetLeft(PlayerToken1) + 50);
                        playerPosition++;
                    }
                    break;
                //Faire apparaitre le jeton à l'emplacement voulu
                case Key.Down:
                    //fait apparaître le jeton joué à la case libre la plus basse sous le jeton player
                    drawEllipse(Canvas01, player);
                    //changement de joueur apres coup joué
                    if (player == "Red")
                    {

                        //check victory
                        checkVictory();
                        player = "Yellow";
                        PlayerToken1.Fill = new SolidColorBrush(Colors.Yellow);
                    }
                    else
                    {


                        //check victory
                        checkVictory();
                        player = "Red";
                        PlayerToken1.Fill = new SolidColorBrush(Colors.Red);
                    }
                    break;                    
            }
        }

        private Ellipse drawEllipse(Canvas myCanvas, string color)
        {
            return drawEllipse(myCanvas, color, PlayerMap);
        }

        private Ellipse drawEllipse(Canvas myCanvas, string color, Dictionary<int, int> playerMap)
        {
            //Creation d'un nouveau jeton
            Ellipse newEllipse = new Ellipse();
            newEllipse.Width = 50;
            newEllipse.Height = 50;
            newEllipse.Fill = new SolidColorBrush(color == "Red" ? Colors.Red : Colors.Yellow);//couleur du jeton
            myCanvas.Children.Add(newEllipse);
            Canvas.SetLeft(newEllipse, (double)PlayerToken1.GetValue(LeftProperty));

            Canvas.SetBottom(newEllipse, 50 * playerMap[playerPosition]);//positionne sur la case inoccupée la plus basse
            PlayerMap[playerPosition]++;//indique à la map que la case est maintenant occupée


            Canvas.SetZIndex(newEllipse, 2);

            return newEllipse;
        }

        private void checkVictory()
        {

        }

        private void Canvas01_KeyUp(object sender, KeyEventArgs e)
        {

        }
    }
}
