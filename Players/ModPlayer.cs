using Exam.Buffs;
using Terraria;
using Terraria.ModLoader;

namespace Exam.Players
{
    public class Player : ModPlayer
    {
        public override void PostUpdate()
        {
            if (Main.LocalPlayer.HasBuff<Buff>() && !Player.dead)
            {
                var player = Player;

                player.statDefense += 10;
                player.statLifeMax2 += 100;
                player.statLife += 100;
                player.statMana += 100;
                player.statManaMax2 += 100;
            }
        }
    }
}
