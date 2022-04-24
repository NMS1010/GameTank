using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTank.MyObjects
{
    internal class EnemySpawner
    {
        public static int EnemyPerTurn;

        public static void Spawn()
        {
            EnemyPerTurn = GameStage.enemyPerTurn;
            for (int i = 0; i < EnemyPerTurn; i++)
            {
                Random random = new Random(i);
                int index = random.Next(GameStage.SampleEnemyTankStage.Count);
                if(GameStage.EnemyTankStage.Count < EnemyPerTurn)
                    GameStage.EnemyTankStage.Add(GameStage.SampleEnemyTankStage[index]);
            }
        }
    }
}
