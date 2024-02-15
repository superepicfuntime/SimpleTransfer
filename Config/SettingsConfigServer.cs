using Terraria.ModLoader.Config;

namespace SimpleTransfer.Config
{
    public class SimpleTransferConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;
        /*
        [Header("Potions")]

        [DefaultValue(true)]
        [ReloadRequired]
        public bool potionsEnable;

        [SliderColor(51, 204, 51)]
        [OptionStrings(new string[] { "Disabled", "Always", "1 Unlimited Potion Present" })]
        [DefaultValue("1 Unlimited Potion Present")]
        [ReloadRequired]
        public string vanillaPotionsEnable;

        [Header("Accessories")]

        [LabelArgs("miningcracks_take_on_luiafk/UnlimitedManaAccessory", "miningcracks_take_on_luiafk/UnlimitedManaAccessory1", "miningcracks_take_on_luiafk/UnlimitedManaAccessory2", "miningcracks_take_on_luiafk/UnlimitedManaAccessory3", "miningcracks_take_on_luiafk/UnlimitedManaAccessory4", "miningcracks_take_on_luiafk/UnlimitedManaAccessory5")]
        [DefaultValue(true)]
        [ReloadRequired]
        public bool manaEnable;
        */

    }
}
