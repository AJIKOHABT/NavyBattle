using NavyBattleModels.Interfaces;
using NavyBattleModels.Models;
using NavyBattleModels.Enums;
using NavyBattleModels.Validators.Interfaces;
using System.Linq;
using System.Collections;

namespace NavyBattleModels.Validators
{
    public class ShotValidator : IShotValidator
    {
        /// <summary>
        /// Validating shot
        /// </summary>
        /// <param name="shot"></param>
        /// <returns></returns>
        public IShot Validate(IShot shot)
        {
            var game = Game.GetById(shot.GameId);
            var gameShots = game.Shots;
            var shotPoint = shot.ShotPoint;
            var battleField = game.BattleField;
            
            
            shot.State = ShotState.Miss;
            shot.Save();
            return shot;
        }

        public CheckShotIsValid()
        {
            if (shotPoint.X < 0 || shotPoint.Y < 0 || shotPoint.X > battleField.Width || shotPoint.Y > battleField.Height)
            {
                shot.State = ShotState.Nonvalid;
                return shot;
            }
        }

        public CheckShotSamePoint()
        {
            if (gameShots.Any(gp => gp.ShotPoint.Equals(shotPoint)))
            {
                shot.State = ShotState.SamePoint;
                return shot;
            }
        }

        public IGameBattleShip CheckBattleShipDamagedOrDestroyed(IEnumerable<IGameBattleShip> gameBattleShips)
        {
            game.GameBattleShips;
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
                        gameBattleShip.Save();
                        shot.State = ShotState.Destroyed;
                        shot.Save();
                        return shot;
                    }
                    if (gameBattleShip.DamagedPointsCnt < battleShip.Length)
                    {
                        gameBattleShip.State = BattleShipState.Damaged;
                        gameBattleShip.Save();
                        shot.State = ShotState.Damaged;
                        shot.Save();
                        return shot;
                    }
                }
            }
        }
    }
}
