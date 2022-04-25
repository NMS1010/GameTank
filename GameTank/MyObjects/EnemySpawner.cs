using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace GameTank.MyObjects
{
    internal class EnemySpawner
    {
        public static int EnemyPerTurn;
        private static int count = 0;
        public static void Spawn(Graphics grp)
        {
            EnemyPerTurn = GameStage.enemyPerTurn;

            bool isSpawn = false;
            HashSet<int> numbers = Utilities.RandomNotDup(EnemyPerTurn, 0, GameStage.SampleEnemyTanks.Count - 1);
            foreach (int i in numbers)
            {
                if (GameStage.EnemyTanks.Count < EnemyPerTurn && !GameStage.EnemyTanks.Contains(GameStage.SampleEnemyTanks[i])
                    && GameStage.numberEnemy >= GameStage.enemyPerTurn)
                {
                    GameStage.SampleEnemyTanks[i].Health = 100;
                    GameStage.SampleEnemyTanks[i].LockMove = true;
                    GameStage.EnemyTanks.Add(GameStage.SampleEnemyTanks[i]);
                    isSpawn = true;
                }
            }
            GameStage.EnemyTanks.ForEach(o =>
            {
                o.DrawTank(grp);
                o.DrawBullets(grp);
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
            if(count == 10)
            {
                GameStage.EnemyTanks.ForEach(o => {
                    if (o.LockMove)
                        o.LockMove = false;
                });
                (sender as Timer).Stop();
            }
        }
    }
}
