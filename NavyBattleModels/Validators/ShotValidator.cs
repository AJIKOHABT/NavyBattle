using System;
using System.Collections.Generic;
using System.Text;
using NavyBattleModels.Interfaces;

namespace NavyBattleModels.Validators
{
    public class ShotValidator : IShotValidator
    {

        public  Validate(IShot shot)
        {
            var game = Game.GetById(shot.GameId);
                        
        }
    }
}
