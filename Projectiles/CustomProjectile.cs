using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Exam.Projectiles
{
    public class CustomProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 9;
            Projectile.height = 9;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 200;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.aiStyle = -1;
            Projectile.scale = 1.1f;
            Projectile.damage = 58;
            Projectile.alpha = 255;
        }

        public override void AI()
        {
            for (int i = 0; i < Main.maxNPCs; i++)
            {
                NPC target = Main.npc[i];
                if (!target.friendly && target.active && !target.dontTakeDamage && !NPCID.Sets.CountsAsCritter[target.type])
                {
                    float distance = Vector2.Distance(target.Center, Projectile.Center);
                    if (distance < 400f)
                    {
                        for (int j = 0; j < Main.maxPlayers; j++)
                        {
                            Player player = Main.player[j];
                            if (player.active && !player.dead && Collision.CanHitLine(Projectile.Center, 1, 1, player.Center, 1, 1))
                            {
                                return;
                            }
                        }

                        Projectile.velocity = Vector2.Normalize(target.Center - Projectile.Center) * 20f;
                        if (distance < 20f)
                        {
                            Projectile.Kill();
                        }
                    }
                }
            }

            if (Projectile.alpha > 0)
            {
                Projectile.alpha -= 5;
                if (Projectile.alpha < 0)
                {
                    Projectile.alpha = 0;
                }
            }

            Lighting.AddLight(Projectile.Center, 1f, 1f, 1f);
            Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Platinum, 0.2f);
        }

        [System.Obsolete]
        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 10; i++)
            {
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Platinum, 1f);
            }
        }
    }
}
