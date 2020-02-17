

using NavyBattleModels.Interfaces;
using NavyBattleModels.Models;

namespace NavyBattleModels.Validators.Interfaces
{
    public interface IShotValidator
    {
        /// <summary>
        /// Validating shot
        /// </summary>
        /// <param name="shot"></param>
        /// <returns></returns>
        ShotResult Validate(Game game, Shot shot);
    }
}
