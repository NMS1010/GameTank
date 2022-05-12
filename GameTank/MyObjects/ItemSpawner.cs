using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTank.MyObjects
{
    internal static class ItemSpawner
    {
        public static List<String> ItemNameSpawns = new List<String>() {"Health", "Damage", "Speed" };
        public static List<Item> ItemSpawns = new List<Item>();

        public static void Spawn(EnemyTank e)
        {
            Random rand = new Random();
            int res = rand.Next(ItemNameSpawns.Count);
            if (res == 0)
            {
                ItemSpawns.Add(new HealthItem(e.Loc, e.Width, e.Height, Properties.Resources.healthItem));
            }
            else if (res == 1)
            {
                ItemSpawns.Add(new DamageItem(e.Loc, e.Width, e.Height, Properties.Resources.damageItem));
            }
            else
            {
                ItemSpawns.Add(new BulletSpeedItem(e.Loc, e.Width, e.Height, Properties.Resources.bulletSpeedItem));
            }
            GameStage.MainGamePnl.Controls.Add(ItemSpawns[ItemSpawns.Count - 1].avatarItem);
        }

    }
}
