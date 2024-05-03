using Exam.Buffs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Exam.Items.Consumables
{
    public class Potion : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 30;
            Item.useTime = 17;
            Item.useAnimation = 17;
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.UseSound = SoundID.Item3;
            Item.consumable = true;
            Item.maxStack = 30;
            Item.value = Item.buyPrice(silver: 5);
            Item.rare = ItemRarityID.Green;
            Item.buffType = ModContent.BuffType<Buff>();
            Item.buffTime = 60 * 15;
        }
    }
}
