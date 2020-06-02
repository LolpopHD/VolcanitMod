using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Volcanit.Items.TileItems.Ores
{
	public class TwiliteOre : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Twilite Ore");
		}

		public override void SetDefaults() 
		{
			item.width = 16;
			item.height = 16;
			item.value = 1000;
			item.rare = 10;
			item.useStyle = 1;
			item.useTime = 10;
			item.useAnimation = 15;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.maxStack = 999;
			item.consumable = true;
			item.createTile = mod.TileType("Twilite");
		}
	}
}