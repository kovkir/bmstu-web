using System;
using db_cp.DTO;
using db_cp.ModelsBL;
using db_cp.Services;

namespace db_cp.ModelsConverters
{
    public class PlayerConverters
    {
        private readonly IPlayerService playerService;

        public PlayerConverters(IPlayerService playerService)
        {
            this.playerService = playerService;
        }

        public PlayerBL convertPatch(int id, PlayerBaseDto player)
        {
            var existedPlayer = playerService.GetByID(id);

            //if (existedPlayer == null)
            //    throw new Exception("Такого футболиста не существует");

            return new PlayerBL
            {
                Id = id,
                ClubId = player.ClubId ?? existedPlayer.ClubId,
                Surname = player.Surname ?? existedPlayer.Surname,
                Rating = player.Rating ?? existedPlayer.Rating,
                Country = player.Country ?? existedPlayer.Country,
                Price = player.Price ?? existedPlayer.Price
            };
        }
    }
}
