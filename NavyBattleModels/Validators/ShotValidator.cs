using NavyBattleModels.Interfaces;
using NavyBattleModels.Models;
using NavyBattleModels.Enums;
using NavyBattleModels.Validators.Interfaces;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace NavyBattleModels.Validators
{
    public class ShotValidator : IShotValidator
    {
        #region public methods

        /// <summary>
        /// Validating shot
        /// </summary>
        /// <param name="shot">fired shot</param>
        /// <returns>Result of the shot as IResultShot object</returns>
        public IShotResult Validate(IGame game, IShot shot)
        {
            var gameShots = gameBattleField.Shots;
            var shotPoint = shot.ShotPoint;
            var battleField = gameBattleField.BattleField;
            
            var gameBattleField = 

            var shotResult = new ShotResult();
            shotResult.Shot = shot;

            if (!CheckShotIsValid(battleField, shotPoint))
            {
                shot.State = ShotState.Nonvalid;
            }
            else if (CheckShotSamePoint(gameShots, shotPoint))
            {
                shot.State = ShotState.SamePoint;
            }
            else
            {
                var isBattleShipDestroyed = CheckBattleShipDestroyed(gameBattleField.GameBattleShips, shotResult);
                if (!isBattleShipDestroyed.HasValue)
                {
                    shot.State = ShotState.Miss;
                }
                else if (isBattleShipDestroyed.Value)
                {
                    var destroyedShips = gameBattleField.GameBattleShips.Count(gameBattleShip => gameBattleShip.State == BattleShipState.Destroyed);
                    if (destroyedShips == gameBattleField.BattleField.BattleShips.Count)
                    {
                        game.State = GameState.Finished;
                        ////сюда добавить победителя
                    }
                    shot.State = ShotState.Destroyed;                    

                }
                else if (!isBattleShipDestroyed.Value)
                {
                    shot.State = ShotState.Damaged;
                }
                shotResult.IsSuccess = true;
            }

            return shotResult;
        }

        #endregion

        #region private methods

        /// <summary>
        /// Check shot to stay in the field
        /// </summary>
        /// <param name="battleField">battlefield</param>
        /// <param name="shotPoint">point of the shot</param>
        /// <returns></returns>
        private bool CheckShotIsValid(IBattleField battleField, Point shotPoint)
        {
            return shotPoint.X > 0 && shotPoint.Y > 0 && shotPoint.X <= battleField.Width && shotPoint.Y <= battleField.Height;            
        }

        /// <summary>
        /// Check shot to get at the same point
        /// </summary>
        /// <param name="gameShots"></param>
        /// <param name="shotPoint"></param>
        /// <returns></returns>
        private bool CheckShotSamePoint(IEnumerable<IShot> gameShots, Point shotPoint)
        {
            return gameShots.Any(gp => gp.ShotPoint.Equals(shotPoint));            
        }

        /// <summary>
        /// Check battleships to be damaged or destroyed
        /// </summary>
        /// <param name="gameBattleShips"></param>
        /// <param name="shotResult"></param>
        /// <returns>true - if destroyed, false - if damaged, null - if missed</returns>
        private bool? CheckBattleShipDestroyed(IEnumerable<IGameBattleShip> gameBattleShips, IShotResult shotResult)
        {
            var shot = shotResult.Shot;
            var shotPoint = shot.ShotPoint;
            foreach (var gameBattleShip in gameBattleShips)
            {
                var battleShip = gameBattleShip.BattleShip;
                var battleShipPoints = battleShip.CreateBattleshipSetOfPoints();
                if (battleShipPoints.Contains(shotPoint))
                {
                    gameBattleShip.DamagedPointsCnt = gameBattleShip.DamagedPointsCnt + 1;
                    if (gameBattleShip.DamagedPointsCnt == battleShip.Length)
                    {
                        gameBattleShip.State = BattleShipState.Destroyed;
                        shotResult.GameBattleShip = gameBattleShip;                                          
                        return true;
                    }
                    if (gameBattleShip.DamagedPointsCnt < battleShip.Length)
                    {
                        gameBattleShip.State = BattleShipState.Damaged;
                        shotResult.GameBattleShip = gameBattleShip;
                        return false;
                    }
                }
            }
            return null;
        }

        #endregion
    }
}
