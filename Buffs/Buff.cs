using Terraria;
using Terraria.ModLoader;

namespace Exam.Buffs
{
    public class Buff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = false;
            Main.buffNoTimeDisplay[Type] = false;
            Main.persistentBuff[Type] = true;
        }

        public override void Load()
        {
            var player = Main.LocalPlayer;

            player.HealEffect(healAmount: 12);
        }
    }
}
