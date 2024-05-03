using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Exam.Items.Weapons
{
    public class Sword : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
        }

        public override void SetDefaults()
        {
            Item.DamageType = DamageClass.Melee;
            Item.width = 32;
            Item.height = 32;
            Item.useTime = 10;
            Item.useAnimation = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.autoReuse = true;
            Item.damage = 15;
            Item.knockBack = 5;
            Item.value = Item.sellPrice(gold: 10, silver: 10, copper: 5);
            Item.rare = ItemRarityID.Blue;
            Item.UseSound = SoundID.Item1;
            Item.crit = 10;
            Item.scale = 4f;
        }

        public override void ModifyHitNPC(Player player, NPC target, ref NPC.HitModifiers modifiers)
        {
            if (!target.friendly && !NPCID.Sets.CountsAsCritter[target.type])
            {
                modifiers.CritDamage += 5;
                modifiers.Knockback += Main.rand.Next(10, 15);
            }
        }

        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (!target.friendly && !NPCID.Sets.CountsAsCritter[target.type])
            {
                target.AddBuff(BuffID.OnFire, 60 * 60);
                SoundEngine.PlaySound(SoundID.DD2_BetsyFireballImpact, target.Center);
            }
        }

        public override void AddRecipes()
        {
            RecipeGroup recipeGroup = new RecipeGroup(() => Lang.misc[37] + "New Group",
            [
                ItemID.LeadBar,
                ItemID.TungstenBar,
            ]);
            RecipeGroup.RegisterGroup("Exam:New Group", recipeGroup);

            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Silk, 1);
            recipe.AddRecipeGroup("Exam:New Group", 10);
            recipe.AddTile(TileID.Furnaces);
            recipe.Register();
        }
    }
}
