using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SimpleTransfer.Items
{
    public class ItemPipe : ModItem
    {
        // The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.SimpleTransfer.hjson file.

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.maxStack = 1;
            Item.value = 1;
            Item.rare = ItemRarityID.Red;
            Item.consumable = true;
            Item.ammo = AmmoID.Gel;
            Item.maxStack = 9999;
        }
    }
}