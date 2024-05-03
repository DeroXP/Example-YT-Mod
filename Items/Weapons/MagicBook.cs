using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Exam.Items.Weapons
{
    public class MagicBook : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 45;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 34;
            Item.height = 40;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.mana = 18;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.knockBack = 4;
            Item.value = Item.buyPrice(0, 2, 0, 0);
            Item.rare = ItemRarityID.Green;
            Item.UseSound = SoundID.DD2_DarkMageAttack;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<Projectiles.CustomProjectile>();
            Item.shootSpeed = 7f;
        }

        public override void AddRecipes()
        {
            RecipeGroup group = new(() => Lang.misc[37] + " Goldinum Bars",
            [
                ItemID.PlatinumBar,
                ItemID.GoldBar
            ]);
            RecipeGroup.RegisterGroup("Exam:Goldnium Bars", group);

            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Topaz, 5);
            recipe.AddIngredient(ItemID.BookofSkulls, 1);
            recipe.AddRecipeGroup("Exam:Goldnium Bars", 3);
            recipe.Register();
        }
    }
}
