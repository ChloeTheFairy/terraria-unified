using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria.GameContent.UI;
using Terraria.ID;
using Terraria.UI.Chat;

namespace Terraria.Unified.Features;

internal static class FixHotbarItemName
{
	public static bool Enabled { get; set; } = true;

	public static void DrawItemName(SpriteBatch sb, Vector2 pos, string itemName, Item item)
	{
		var rare = item.rare;
		if (item.IsAir)
			rare = ItemRarityID.White;

		var color = ItemRarity.GetColor(rare);
		if (item.expert || rare == ItemRarityID.Expert) {
			color = new Microsoft.Xna.Framework.Color(Main.DiscoR, Main.DiscoG, Main.DiscoB);
		}
		else if (rare == ItemRarityID.Master) {
			color = new Microsoft.Xna.Framework.Color(255, (byte)(Main.masterColor * 200f), 0);
		}

		var alpha = Main.mouseTextColor / 255f;
		ChatManager.DrawColorCodedStringWithShadow(sb, FontAssets.MouseText.Value, itemName, pos, color * alpha, 0f, Vector2.Zero, Vector2.One);
	}
}
