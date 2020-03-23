using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Volcanit.Projectiles;

namespace Volcanit.Items
{
	public class SwordOfTheJungle : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Blade of the Jungle");
			Tooltip.SetDefault("Sends an explosive rose forth to blow up your enemies!");
		}

		public override void SetDefaults() 
		{
			item.damage = 20;
			item.melee = true;
			item.width = 38;
			item.height = 54;
			item.useTime = 20;
			item.useAnimation = 20;
			item.crit = 11;
			item.useStyle = 1;
			item.knockBack = 5;
			item.value = 100000;
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = ModContent.ProjectileType<Rose>();
			item.shootSpeed = 4f;
		}
	}
}