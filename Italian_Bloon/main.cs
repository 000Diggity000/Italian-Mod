using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.Bloons;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api.Scenarios;
using BTD_Mod_Helper.Extensions;
using Il2Cpp;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Bloons;
using Il2CppAssets.Scripts.Models.Difficulty;
using Il2CppAssets.Scripts.Models.Rounds;
using MelonLoader;
using System;

[assembly: MelonInfo(typeof(Italian_Bloon.main), "Italian Bloon", "1.0.0", "000Diggity000")]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]
namespace Italian_Bloon
{
    public class main : BloonsTD6Mod
    {
        class ItalianRounds : ModGameMode
        {
            public override string Difficulty => DifficultyType.Easy;

            public override string BaseGameMode => GameModeType.None;

            public override string DisplayName => "Italian Rounds";

            public override void ModifyBaseGameModeModel(ModModel gameModeModel)
            {
                gameModeModel.UseRoundSet<Spaghetti>();
            }
        }
        class Spaghetti : ModRoundSet
        {
            public override string BaseRoundSet => RoundSetType.Default;

            public override int DefinedRounds => 40;

            public override string DisplayName => "Italian Rounds";

            public override bool CustomHints => false;

            public override void ModifyEasyRoundModels(RoundModel roundModel, int round)
            {
                switch (round)
                {
                    case 22:
                        roundModel.AddBloonGroup<Italian>(5, 0, 600);
                        break;
                    case 23:
                        roundModel.AddBloonGroup<Italian>(10, 0, 900);
                        break;
                    case 29:
                        roundModel.AddBloonGroup<Italian>(3, 0, 900);
                        roundModel.AddBloonGroup<Italian>(6, 300, 900);
                        roundModel.AddBloonGroup<Italian>(12, 600, 900);
                        break;
                    case 35:
                        roundModel.AddBloonGroup<Italian>(6, 0, 900);
                        roundModel.AddBloonGroup<Italian>(12, 300, 900);
                        roundModel.AddBloonGroup<Italian>(24, 600, 900);
                        break;
                }
            }
            public class Italian : ModBloon
            {
                public override string BaseBloon => BloonType.Red;


                public override void ModifyBaseBloonModel(BloonModel bloonModel)
                {
                    bloonModel.speed *= 1.2f;
                    bloonModel.speedFrames *= 1.2f;

                    bloonModel.overlayClass = BloonOverlayClass.Red;

                    bloonModel.maxHealth = 1;
                    bloonModel.leakDamage = 5;

                    bloonModel.RemoveAllChildren();
                    bloonModel.AddToChildren(BloonType.Green);
                    bloonModel.AddToChildren(BloonType.White);
                    bloonModel.AddToChildren(BloonType.Red);

                    bloonModel.hasChildrenWithDifferentTotalHealths = true;
                    bloonModel.distributeDamageToChildren = false;
                }
            }

        }
    }
}