
using NavyBattleModels;

namespace NavyBattleController.Resource
{
    public class SaveBattleShipResource
    {
        /// <summary>
        /// Length of the battleship
        /// </summary>
        public int Length { get; set; }

        /// <summary>
        /// Is battleship vertically or horizontally orinted (true - vertically)
        /// </summary>
        public bool IsVertical { get; set; }

        /// <summary>
        /// Starting point of the battleship
        /// </summary>
        public Point StartPoint { get; set; }
    }
}
