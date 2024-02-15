using SimpleTransfer.UI;
using SimpleTransfer.UI.OtherItemUIs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SimpleTransfer.Items.Tools
{
    public class PipeWrench : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            base.Item.useStyle = ItemUseStyleID.HoldUp;
            base.Item.useAnimation = 20;
            base.Item.useTime = 20;
            base.Item.autoReuse = false;
            base.Item.channel = true;
            base.Item.shoot = base.Mod.Find<ModProjectile>("PipeWrenchProjectile").Type;
            base.Item.shootSpeed = 10f;
            base.Item.UseSound = SoundID.Item64;
            base.Item.mech = true;
        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                base.Item.shoot = ProjectileID.None;
                return false;
            }
            else
            {
                base.Item.shoot = base.Mod.Find<ModProjectile>("PipeWrenchProjectile").Type;
            }
            return true;
        }

        public override void HoldItem(Player player)
        {
            if (player.whoAmI == Main.myPlayer)
            {
                SimpleTransferUI.RightClickUIs<PipeUI>().holding = true;
            }
            player.InfoAccMechShowWires = true;
            player.rulerLine = true;
        }

        public override void UpdateInventory(Player player)
        {
            player.InfoAccMechShowWires = true;
            player.rulerLine = true;
        }

    }
}
