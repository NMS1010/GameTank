using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using GameTank.Constants;

namespace GameTank.MyObjects
{
    internal static class EnemySpawner
    {
        public static int EnemyPerTurn;
        private static int count = 0;
        public static bool IsLockDamage = true;
        public static List<PictureBox> spawnLocation = new List<PictureBox>();
        public static Bitmap portal;

        static EnemySpawner()
        {
            using (Image portalImg = Image.FromFile("../../Image/portal.png"))
            {
                portal = new Bitmap(portalImg);
            }
        }
        private static bool CheckHaveEnemy(Point p)
        {
            foreach(EnemyTank e in GameStage.EnemyTanks)
            {
                if (e.Loc.X == p.X && e.Loc.Y == p.Y)
                {
                    return true;
                }
            }
            return false;
        }
        public static void Spawn(Graphics grp)
        {
            EnemyPerTurn = GameStage.EnemyPerTurn;
            bool isSpawn = false;
            if (GameStage.EnemyTanks.Count < EnemyPerTurn)
            {
                HashSet<int> numbers = Utilities.RandomNotDup(EnemyPerTurn, 0, GameStage.SpawEnemyPoint.Count - 1);
                foreach (int i in numbers)
                {
                    if (GameStage.EnemyTanks.Count < EnemyPerTurn && !CheckHaveEnemy(GameStage.SpawEnemyPoint[i])
                        && GameStage.NumberEnemy >= GameStage.EnemyPerTurn)
                    {
                        IsLockDamage = true;
                        EnemyTank t = new EnemyTank(loc: GameStage.SpawEnemyPoint[i], isOfPlayer: false, bulletColor: Color.Red,
                            bulletSpeed: 100 - 10 * GameStage.CurrentState, bulletDamage: 20 * GameStage.CurrentState, health: (int)TANK.ENEMY_HEALTH * GameStage.CurrentState);
                        t.LockMove = true;
                        GameStage.EnemyTanks.Add(t);
                        spawnLocation.Add(new PictureBox() { Location = t.Loc, Width = t.Width, Height = t.Height, Image = portal, SizeMode = PictureBoxSizeMode.StretchImage, BackColor = Color.Black });
                        isSpawn = true;
                    }
                }
            }
            GameStage.EnemyTanks.ForEach(o =>
            {
                if (o.LockMove)
                {
                    GameStage.MainGamePnl.Controls.AddRange(spawnLocation.ToArray());
                }
                else
                {
                    o.DrawTank(grp);
                    o.DrawBullets(grp);
                }
            });
            if (isSpawn)
            {
                count = 0;
                Timer t = new Timer();
                t.Tick += T_Tick;
                t.Start();
            }
        }

        private static void T_Tick(object sender, EventArgs e)
        {
            count++;
            if (count == 15)
            {
                IsLockDamage = false;
                GameStage.EnemyTanks.ForEach(o =>
                {
                    if (o.LockMove)
                        o.LockMove = false;
                });
                spawnLocation.ForEach(p => {
                    GameStage.MainGamePnl.Controls.Remove(p);
                });
                (sender as Timer).Stop();
            }
            else
            {
            }
        }
    }
}
