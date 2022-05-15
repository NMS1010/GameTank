using GameTank.Constants;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameTank.MyObjects
{
    internal static class GameStage
    {
        public static Panel MainGamePnl;

        public static List<Obstacle> ObstaclesStage;
        public static List<PartialObstacle> PartialObstacle;

        public static List<EnemyTank> EnemyTanks;
        public static PlayerTank PlayerTank;   
        public static List<Point> SpawEnemyPoint;


        public static PictureBox TotalPlayerHealth;
        public static PictureBox CurrentPlayerHealth;
        public static Panel CurrentNumberEnemyContainer;
        public static PictureBox PlayerSkin;
        public static Bitmap avatarTank;

        public static int HealthPlayer = (int)TANK.PLAYER_HEALTH;
        public static int DamagePlayer = 20;
        public static int BulletSpeedPlayer = 100;
        public static int EnemyPerTurn;
        public static int NumberEnemy;
        public static int MaxNumberEnemy;
        public static int CurrentStage = 0;
        public static int MaxStage = 6;
        public static List<int> TotalScore;
        public static List<int> TotalTime;
        public static int NumberItem;
        static GameStage()
        {
            SpawEnemyPoint = new List<Point>() {
                new Point(30,30),
                new Point(100,30),
                new Point(400,30),
                new Point(600,30)
            };
            using (Image tankImg = Properties.Resources.enemy1)
            {
                avatarTank = new Bitmap(tankImg);
            }
            TotalScore = new List<int>();
            TotalTime = new List<int>();
        }
        private static void DisplayCurrentNumberEnemy()
        {
            int nRow = (int)Math.Ceiling(NumberEnemy / 4.0);
            int nCol = 4;

            PictureBox PrePtrb = new PictureBox() { Size = new Size(0, 0), Location = new Point(0, 0) };
            PictureBox CurrPtrb;
            for (int i = 0; i < nRow; i++)
            {
                for (int j = 0; j < nCol; j++)
                {
                    if (i * 4 + j >= NumberEnemy)
                        return;
                    CurrPtrb = new PictureBox()
                    {
                        Size = new Size(45, 45),
                        Location = new Point(PrePtrb.Location.X + PrePtrb.Size.Width + 5, PrePtrb.Location.Y),
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Image = avatarTank
                    };
                    CurrentNumberEnemyContainer.Controls.Add(CurrPtrb);
                    PrePtrb = CurrPtrb;
                }
                PrePtrb = new PictureBox() { Size = new Size(0, 0), Location = new Point(0, PrePtrb.Location.Y + 50) };
            }
        }
        public static void Stage1()
        {
            List<Tuple<Point, int, int, bool>> obs = new List<Tuple<Point, int, int, bool>>() {
                new Tuple<Point, int, int, bool>(new Point(80, 80), 40, 180, true),
                new Tuple<Point, int, int, bool>(new Point(200, 80), 40, 180, true),
                new Tuple<Point, int, int, bool>(new Point(320, 80), 40, 140, true),
                new Tuple<Point, int, int, bool>(new Point(360, 120), 80, 60, false),
                new Tuple<Point, int, int, bool>(new Point(440, 80), 40, 140, true),
                new Tuple<Point, int, int, bool>(new Point(560, 80), 40, 180, true),
                new Tuple<Point, int, int, bool>(new Point(680, 80), 40, 180, true),
                new Tuple<Point, int, int, bool>(new Point(20, 320), 40, 20, true),
                new Tuple<Point, int, int, bool>(new Point(20, 340), 40, 20, false),
                new Tuple<Point, int, int, bool>(new Point(120, 320), 120, 40, true),
                new Tuple<Point, int, int, bool>(new Point(320, 280), 40, 40, true),
                new Tuple<Point, int, int, bool>(new Point(440, 280), 40, 40, true),
                new Tuple<Point, int, int, bool>(new Point(560, 320), 120, 40, true),
                new Tuple<Point, int, int, bool>(new Point(740, 320), 40, 20, true),
                new Tuple<Point, int, int, bool>(new Point(740, 340), 40, 20, false),
                new Tuple<Point, int, int, bool>(new Point(80, 420), 40, 130, true),
                new Tuple<Point, int, int, bool>(new Point(200, 420), 40, 130, true),
                new Tuple<Point, int, int, bool>(new Point(560, 420), 40, 130, true),
                new Tuple<Point, int, int, bool>(new Point(680, 420), 40, 130, true),
                new Tuple<Point, int, int, bool>(new Point(320, 380), 40, 140, true),
                new Tuple<Point, int, int, bool>(new Point(360, 440), 80, 40, false),
                new Tuple<Point, int, int, bool>(new Point(440, 380), 40, 140, true),
            };

            RenderStage(obs,numberItem: 3, currStage: 1, enemyPerTurn: 2, numberEnemy: 7);
        }

        public static void Stage2()
        {
            List<Tuple<Point, int, int, bool>> obs = new List<Tuple<Point, int, int, bool>>() {
                new Tuple<Point, int, int, bool>(new Point(283 + 30, 70), 180, 60, true),
                new Tuple<Point, int, int, bool>(new Point(343 + 30, 130), 60, 40, false),
                new Tuple<Point, int, int, bool>(new Point(131 + 30, 170), 480, 50, true),
                new Tuple<Point, int, int, bool>(new Point(192 + 30, 220), 360, 50, true),
                new Tuple<Point, int, int, bool>(new Point(232 + 30, 270), 280, 50, true),
                new Tuple<Point, int, int, bool>(new Point(272 + 30, 320), 200, 60, true),
                new Tuple<Point, int, int, bool>(new Point(232 + 30, 380), 40, 60, true),
                new Tuple<Point, int, int, bool>(new Point(470 + 30, 380), 40, 60, true),
                new Tuple<Point, int, int, bool>(new Point(152 + 30, 487), 80, 40, false),
                new Tuple<Point, int, int, bool>(new Point(510 + 30, 487), 80, 40, false),
                new Tuple<Point, int, int, bool>(new Point(283 + 30, 562), 180, 40, true),
                new Tuple<Point, int, int, bool>(new Point(20, 270), 40, 80, true),
                new Tuple<Point, int, int, bool>(new Point(740, 270), 40, 80, true),
                new Tuple<Point, int, int, bool>(new Point(60, 290), 40, 40, true),
                new Tuple<Point, int, int, bool>(new Point(700, 290), 40, 40, true),
            };
            RenderStage(obs, numberItem: 4, currStage: 2, enemyPerTurn: 2, numberEnemy: 9);
        }
        public static void Stage3()
        {
            List<Tuple<Point, int, int, bool>> obs = new List<Tuple<Point, int, int, bool>>() {
                new Tuple<Point, int, int, bool>(new Point(70, 70), 60, 100, true), //1
                new Tuple<Point, int, int, bool>(new Point(210, 0), 60, 100, false), //2
                new Tuple<Point, int, int, bool>(new Point(210, 70+100), 60, 100, true), //3
                new Tuple<Point, int, int, bool>(new Point(450, 0), 60, 60, false), //5
                new Tuple<Point, int, int, bool>(new Point(450, 60), 60, 100, true), //6
                new Tuple<Point, int, int, bool>(new Point(390, 100), 60, 60, true), //4
                new Tuple<Point, int, int, bool>(new Point(560, 60), 60, 100, true), //7
                new Tuple<Point, int, int, bool>(new Point(560, 160), 60, 40, false), //8
                new Tuple<Point, int, int, bool>(new Point(620, 120), 60, 40, false), //10
                new Tuple<Point, int, int, bool>(new Point(680, 60), 60, 100, true), //11
                new Tuple<Point, int, int, bool>(new Point(560, 200), 60, 40, true), //9
                new Tuple<Point, int, int, bool>(new Point(680, 200), 60, 40, true), //20
                new Tuple<Point, int, int, bool>(new Point(740, 200), 40, 40, false), //21
                new Tuple<Point, int, int, bool>(new Point(70, 320), 200, 40, true), //12
                new Tuple<Point, int, int, bool>(new Point(210, 360), 60, 100, false), //15
                new Tuple<Point, int, int, bool>(new Point(210, 460), 60, 40, true), //16
                new Tuple<Point, int, int, bool>(new Point(0, 400), 60, 40, false), //13
                new Tuple<Point, int, int, bool>(new Point(60, 400), 60, 140, true), //14
                new Tuple<Point, int, int, bool>(new Point(330, 200), 60, 200, true), //17
                new Tuple<Point, int, int, bool>(new Point(450, 280), 60, 60, false), //18
                new Tuple<Point, int, int, bool>(new Point(450, 360), 60, 100, true), //19
                new Tuple<Point, int, int, bool>(new Point(210, 540), 60, 60, true), //22
                new Tuple<Point, int, int, bool>(new Point(330, 460), 60, 140, true), //23
                new Tuple<Point, int, int, bool>(new Point(450, 520), 60, 40, false), //24
                new Tuple<Point, int, int, bool>(new Point(560, 420), 60, 40, false), //25
                new Tuple<Point, int, int, bool>(new Point(620, 320), 60, 180, true), //26
                new Tuple<Point, int, int, bool>(new Point(680, 520), 100, 40, true), //27
            };
            RenderStage(obs, numberItem: 5, currStage: 3, enemyPerTurn: 3, numberEnemy: 12);
        }
        public static void Stage4()
        {
            List<Tuple<Point, int, int, bool>> obs = new List<Tuple<Point, int, int, bool>>() {
                new Tuple<Point, int, int, bool>(new Point(60, 90), 280, 40, true), //1
                new Tuple<Point, int, int, bool>(new Point(470, 90), 280, 40, true), //3
                new Tuple<Point, int, int, bool>(new Point(21, 200), 60, 100, true), //4
                new Tuple<Point, int, int, bool>(new Point(80, 230), 100, 40, true), //5
                new Tuple<Point, int, int, bool>(new Point(718, 200), 60, 100, true), //8
                new Tuple<Point, int, int, bool>(new Point(618, 230), 100, 40, true), //7
                new Tuple<Point, int, int, bool>(new Point(190, 320), 40, 40, false), //9
                new Tuple<Point, int, int, bool>(new Point(568, 320), 40, 40, false), //11
                new Tuple<Point, int, int, bool>(new Point(21, 370), 60, 100, true), //12
                new Tuple<Point, int, int, bool>(new Point(80, 400), 100, 40, true), //13
                new Tuple<Point, int, int, bool>(new Point(60, 540), 280, 40, true), //14
                new Tuple<Point, int, int, bool>(new Point(618, 400), 100, 40, true), //16
                new Tuple<Point, int, int, bool>(new Point(718, 370), 60, 100, true), //17
                new Tuple<Point, int, int, bool>(new Point(470, 540), 280, 40, true), //18
                new Tuple<Point, int, int, bool>(new Point(385, 140), 50, 100, false), //2
                new Tuple<Point, int, int, bool>(new Point(385, 300), 50, 80, true), //6
                new Tuple<Point, int, int, bool>(new Point(385, 440), 50, 100, false), //10 - bo 15 
            };
            RenderStage(obs, numberItem: 6, currStage: 4, enemyPerTurn: 3, numberEnemy: 15);
        }
        public static void Stage5()
        {
            List<Tuple<Point, int, int, bool>> obs = new List<Tuple<Point, int, int, bool>>() {
                new Tuple<Point, int, int, bool>(new Point(90,100), 140, 30, false),
                new Tuple<Point, int, int, bool>(new Point(90,100), 40, 150, true),
                new Tuple<Point, int, int, bool>(new Point(190,250), 40, 110, true),
                new Tuple<Point, int, int, bool>(new Point(90,360), 140, 40, false),
                new Tuple<Point, int, int, bool>(new Point(300,100), 40, 290, true),
                new Tuple<Point, int, int, bool>(new Point(380,150), 60, 190, false),
                new Tuple<Point, int, int, bool>(new Point(480,100), 40, 290, true),
                new Tuple<Point, int, int, bool>(new Point(630,100), 100, 30, true),
                new Tuple<Point, int, int, bool>(new Point(590,100), 40, 150, false),
                new Tuple<Point, int, int, bool>(new Point(690,250), 40, 150, false),
                new Tuple<Point, int, int, bool>(new Point(590,360), 100, 40, true),
                new Tuple<Point, int, int, bool>(new Point(120,475), 570, 40, false),
            };
            RenderStage(obs, numberItem: 7, currStage: 5, enemyPerTurn: 4, numberEnemy: 16);
        }
        public static void Stage6()
        {
            List<Tuple<Point, int, int, bool>> obs = new List<Tuple<Point, int, int, bool>>() {
                new Tuple<Point, int, int, bool>(new Point(200 ,0), 360, 40, false),

                new Tuple<Point, int, int, bool>(new Point(120,100), 60, 180, true),
                new Tuple<Point, int, int, bool>(new Point(270,100), 60, 150, false),
                new Tuple<Point, int, int, bool>(new Point(420,100), 60, 150, true),
                new Tuple<Point, int, int, bool>(new Point(570,100), 60, 180, false),
                new Tuple<Point, int, int, bool>(new Point(720,100), 60, 150, true),

                new Tuple<Point, int, int, bool>(new Point(0,320), 300, 30, false),
                new Tuple<Point, int, int, bool>(new Point(440,340), 240, 30, false),

                new Tuple<Point, int, int, bool>(new Point(80,400), 100, 150, true),
                new Tuple<Point, int, int, bool>(new Point(300,400), 80, 200, false),
                new Tuple<Point, int, int, bool>(new Point(480,350), 60, 180, true),
                new Tuple<Point, int, int, bool>(new Point(620,450), 200, 200, true),
            };
            RenderStage(obs, numberItem: 8, currStage: 6, enemyPerTurn: 4, numberEnemy: 20);
        }
        private static void RenderStage(List<Tuple<Point, int, int, bool>> obs, int numberItem, int currStage, int enemyPerTurn, int numberEnemy)
        {
            ItemSpawner.ItemSpawns.Clear();
            NumberItem = numberItem;
            CurrentStage = currStage;
            Bound.DrawBound();
            EnemyPerTurn = enemyPerTurn;
            NumberEnemy = numberEnemy;
            MaxNumberEnemy = NumberEnemy;
            ObstaclesStage = new List<Obstacle>();
            PartialObstacle = new List<PartialObstacle>();
            EnemyTanks = new List<EnemyTank>();

            for (int i = 0; i < obs.Count; i++)
            {
                Obstacle temp = new Obstacle(obs[i].Item1, obs[i].Item2, obs[i].Item3, obs[i].Item4);
                ObstaclesStage.Add(temp);
                PartialObstacle.AddRange(temp.Obs);
            }
            DrawStage(ObstaclesStage);
            DisplayCurrentNumberEnemy();
        }
        public static void ClearStage()
        {
            MainGamePnl.Controls.Clear();
            CurrentNumberEnemyContainer.Controls.Clear();
            EnemySpawner.spawnLocation.Clear();
            PlayerTank?.Bullets.Clear();
            PartialObstacle = null;
            ObstaclesStage = null;
            EnemyTanks = null;

        }
        public static void DrawStage(List<Obstacle> ObstaclesStage)
        {
            ObstaclesStage.ForEach(o => o.DrawObstacle());
        }
        public static void NextState()
        {
            switch (CurrentStage)
            {
                case 1:
                    Stage1();
                    break;
                case 2:
                    Stage2();
                    break;
                case 3:
                    Stage3();
                    break;
                case 4:
                    Stage4();
                    break;
                case 5:
                    Stage5();
                    break;
                case 6:
                    Stage6();
                    break;
            }
            PlayerTank playerTank = new PlayerTank(loc: new Point(20, 540), isOfPlayer: true, bulletColor: Color.Yellow, bulletSpeed: BulletSpeedPlayer, bulletDamage: DamagePlayer, health: HealthPlayer);
            PlayerTank = playerTank;
            GameStage.CurrentPlayerHealth.Width = (GameStage.PlayerTank.Health * GameStage.TotalPlayerHealth.Width) / (int)TANK.PLAYER_HEALTH;
            playerTank.UpdateAvatar(PlayerSkin.Tag as Image);
        }
    }
}
