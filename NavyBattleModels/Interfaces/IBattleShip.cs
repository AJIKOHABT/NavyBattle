using System;
using System.Collections.Generic;
using System.Text;

namespace NavyBattleModels.Interfaces
{
    /// <summary>
    /// Interface describing battleship
    /// </summary>
    public interface IBattleShip
    {
        /// <summary>
        /// Id of the battleship
        /// </summary>
        int Id { get; set; }
        
        /// <summary>
        /// Length of the battleship
        /// </summary>
        int Length { get; set; }

        /// <summary>
        /// Is battleship vertically or horizontally orinted (true - vertically)
        /// </summary>
        bool IsVertical { get; set; }

        /// <summary>
        /// Starting point of the battleship
        /// </summary>
        Point StartPoint { get; set; }

        /// <summary>
        /// X coordinate of the start point
        /// </summary>
        int StartX { get; set; }

        /// <summary>
        /// Y coordinate of the start point
        /// </summary>
        int StartY { get; set; }

        /// <summary>
        /// ID of the battlefield
        /// </summary>
        int? BattleFieldId { get; set; }

        /// <summary>
        /// Battlefield
        /// </summary>
        BaseBattleField BattleField { get; set; }

        /// <summary>
        /// Recalculation of battleship parameters
        /// </summary>
        void RecalculateBattleShip();

        /// <summary>
        /// Creating set of points of battleship
        /// </summary>
        /// <param name="battleShip">Battleship object</param>
        /// <returns>HashSet of points of battleship</returns>
        HashSet<Point> CreateBattleshipSetOfPoints();

        /// <summary>
        /// Creating set of points around battleship
        /// </summary>
        /// <param name="battleShip">Battleship object</param>
        /// <returns>HashSet of points around battleship</returns>
        HashSet<Point> CreateSetOfPointsAroundBattleShip();
        
        /// <summary>
        /// Getting end point of the battleship
        /// </summary>
        /// <returns></returns>
        Point GetEndPoint();
    }
}
