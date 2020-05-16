using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace Volcanit.Npcs
{    
    public class HellianeFleshling1Body : ModNPC
    {
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Helliane Fleshling");
	}
        public override void SetDefaults()
        {
            npc.width = 62;
            npc.height = 62;
            npc.damage = 75;
            npc.defense = 17;
            npc.lifeMax = 9001;
            npc.knockBackResist = 0.0f;
            npc.behindTiles = true;
            npc.noTileCollide = true;
            npc.netAlways = true;
            npc.noGravity = true;
	    npc.buffImmune[24] = true;
            npc.dontCountMe = true;
            npc.HitSound = SoundID.NPCHit1;
           
        }
	public override void HitEffect(int hitDirection, double damage) {
			if (npc.life <= 0) {
				if(Main.rand.Next(2) == 0) {
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/HellianeFleshlingBody1"), npc.scale);
				} else {
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/HellianeFleshlingBody2"), npc.scale);
				}
				VolcanitWorld.downedHelliane = true;
			}
		}
 
        public override bool PreAI()
        {
            if (npc.ai[3] > 0)
                npc.realLife = (int)npc.ai[3];
            if (npc.target < 0 || npc.target == byte.MaxValue || Main.player[npc.target].dead)
                npc.TargetClosest(true);
            if (Main.player[npc.target].dead && npc.timeLeft > 300)
                npc.timeLeft = 300;
 
            if (Main.netMode != 1)
            {
                if (!Main.npc[(int)npc.ai[1]].active)
                {
                    npc.life = 0;
                    npc.HitEffect(0, 10.0);
                    npc.active = false;
                }
            }
 
            if (npc.ai[1] < (double)Main.npc.Length)
            {
                Vector2 npcCenter = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
                float dirX = Main.npc[(int)npc.ai[1]].position.X + (float)(Main.npc[(int)npc.ai[1]].width / 2) - npcCenter.X;
                float dirY = Main.npc[(int)npc.ai[1]].position.Y + (float)(Main.npc[(int)npc.ai[1]].height / 2) - npcCenter.Y;
                npc.rotation = (float)Math.Atan2(dirY, dirX) + 1.57f;
                float length = (float)Math.Sqrt(dirX * dirX + dirY * dirY);
                float dist = (length - (float)npc.width) / length;
                float posX = dirX * dist;
                float posY = dirY * dist;
 
                npc.velocity = Vector2.Zero;
                npc.position.X = npc.position.X + posX;
                npc.position.Y = npc.position.Y + posY;
            }
            return false;
        }
 
        public override bool PreDraw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Color drawColor)
        {
            Texture2D texture = Main.npcTexture[npc.type];
            Vector2 origin = new Vector2(texture.Width * 0.5f, texture.Height * 0.5f);
            Main.spriteBatch.Draw(texture, npc.Center - Main.screenPosition, new Rectangle?(), drawColor, npc.rotation, origin, npc.scale, SpriteEffects.None, 0);
			if (Main.npc[(int)npc.ai[1]].life <= 9000)
            {
				spriteBatch.Draw(mod.GetTexture("Npcs/HellianeFleshling2Body"), npc.Center - Main.screenPosition, new Rectangle?(), drawColor, npc.rotation, origin, npc.scale, SpriteEffects.None, 0);
				npc.damage = 100;
            }
			return false;
        }
        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
 
            return false;
        }
    }
}