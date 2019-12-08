using NavyBattleModels.Interfaces;

namespace NavyBattleModels.Validators.Interfaces
{
    public interface IShotValidator
    {
        /// <summary>
        /// Validating shot
        /// </summary>
        /// <param name="shot"></param>
        /// <returns></returns>
        IShot Validate(IShot shot);
    }
}
