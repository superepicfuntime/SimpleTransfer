using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SimpleTransfer.Utility
{
    internal class Recipes : ModSystem
    {
        public override void AddRecipeGroups()
        {
            RecipeGroup g = new RecipeGroup(() => $"{Lang.GetItemNameValue(ItemID.CopperBar)}", ItemID.CopperBar, ItemID.TinBar);
            RecipeGroup.RegisterGroup(nameof(ItemID.CopperBar), g);

            g = new RecipeGroup(() => $"{Lang.GetItemNameValue(ItemID.SilverBar)}", ItemID.SilverBar, ItemID.TungstenBar);
            RecipeGroup.RegisterGroup(nameof(ItemID.CopperBar), g);

            g = new RecipeGroup(() => $"{Lang.GetItemNameValue(ItemID.GoldBar)}", ItemID.GoldBar, ItemID.PlatinumBar);
            RecipeGroup.RegisterGroup(nameof(ItemID.GoldBar), g);

            g = new RecipeGroup(() => $"{Lang.GetItemNameValue(ItemID.DemoniteBar)}", ItemID.DemoniteBar, ItemID.CrimtaneBar);
            RecipeGroup.RegisterGroup(nameof(ItemID.DemoniteBar), g);

            g = new RecipeGroup(() => $"{Lang.GetItemNameValue(ItemID.CobaltBar)}", ItemID.CobaltBar, ItemID.PalladiumBar);
            RecipeGroup.RegisterGroup(nameof(ItemID.CobaltBar), g);

            g = new RecipeGroup(() => $"{Lang.GetItemNameValue(ItemID.MythrilBar)}", ItemID.MythrilBar, ItemID.OrichalcumBar);
            RecipeGroup.RegisterGroup(nameof(ItemID.MythrilBar), g);

            g = new RecipeGroup(() => $"{Lang.GetItemNameValue(ItemID.AdamantiteBar)}", ItemID.AdamantiteBar, ItemID.TitaniumBar);
            RecipeGroup.RegisterGroup(nameof(ItemID.AdamantiteBar), g);

            base.AddRecipeGroups();
        }

        public override void AddRecipes()
        {
            Recipe r = Recipe.Create(ModContent.ItemType<Items.Tools.PipeWrench>());
            r.AddRecipeGroup("IronBar", 5);
            r.AddTile(TileID.WorkBenches);
            r.Register();

            r = Recipe.Create(ModContent.ItemType<Items.ItemPipe>());
            r.AddRecipeGroup("CopperBar", 1);
            r.AddTile(TileID.WorkBenches);
            r.Register();

            base.AddRecipes();
        }
    }
}
