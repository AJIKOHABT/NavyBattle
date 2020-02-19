﻿using AutoMapper;
using NavyBattleController.Resource;
using NavyBattleModels.Models;
using NavyBattleModels;

namespace NavyBattleController.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Resource
            CreateMap<User, UserResource>();
            CreateMap<BattleShip, BattleShipResource>();
            CreateMap<BaseBattleField, BattleFieldResource>();
            CreateMap<Game, GameResource>();
            CreateMap<GameBattleField, GameBattleFieldResource>();
            CreateMap<GameBattleShip, GameBattleShipResource>();
            CreateMap<Shot, ShotResource>();

            // Resource to Domain
            CreateMap<UserResource, User>();
            CreateMap<BattleShipResource, BattleShip>();
            CreateMap<BattleFieldResource, BaseBattleField>();
            CreateMap<GameResource, Game>();
            CreateMap<GameBattleFieldResource, GameBattleField>();
            CreateMap<GameBattleShipResource, GameBattleShip>();
            CreateMap<ShotResource, Shot>();
            CreateMap<SaveShotResource, Shot>();
            CreateMap<SaveUserResource, User>();
            CreateMap<SaveBattleShipResource, BattleShip>();
        }
    }
}
