using System.Linq;
using System.Threading.Tasks;
using ff14bot;
using ff14bot.Managers;
using Magitek.Enumerations;
using Magitek.Extensions;
using Magitek.Models.DarkKnight;
using Magitek.Utilities;
using Auras = Magitek.Utilities.Auras;

namespace Magitek.Logic.DarkKnight
{
    internal static class Buff
    {
        public static async Task<bool> Grit()
        {
            if (!DarkKnightSettings.Instance.Grit)
            {
                if (Core.Me.HasAura(Auras.Grit))
                {
                    return await Spells.Grit.Cast(Core.Me);
                }

                return false;
            }

            if (Core.Me.HasAura(Auras.Grit))
                return false;
                
            return await Spells.Grit.Cast(Core.Me);
        }

        public static async Task<bool> LivingShadow()
        {
            return await Spells.LivingShadow.Cast(Core.Me);
        }

        public static async Task<bool> BloodWeapon()
        {
            if (!DarkKnightSettings.Instance.BloodWeapon)
                return false;

            return await Spells.BloodWeapon.Cast(Core.Me);
        }

        public static async Task<bool> Delirium()
        {
            if (!DarkKnightSettings.Instance.Delirium)
                return false;

            if (ActionResourceManager.DarkKnight.BlackBlood != 100)
                return false;

            return await Spells.Delirium.Cast(Core.Me);
        }
    }
}