using NavyBattleModels.Enums;

namespace NavyBattleModels.Interfaces
{
    public interface IGameBattleShip
    {
        /// <summary>
        /// Game in which battleship stands
        /// </summary>
        IGame Game { get; }

        /// <summary>
        /// Battleship on the battleField
        /// </summary>
        IBattleShip BattleShip { get; }

        /// <summary>
        /// State of the battleship in the game
        /// </summary>
        BattleShipState State { get; set; }

    }
}
