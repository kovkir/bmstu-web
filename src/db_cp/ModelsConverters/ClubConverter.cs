using db_cp.DTO;
using db_cp.ModelsBL;
using db_cp.Services;

namespace db_cp.ModelsConverters
{
    public class ClubConverters
    {
        private readonly IClubService clubService;

        public ClubConverters(IClubService clubService)
        {
            this.clubService = clubService;
        }

        public ClubBL convertPatch(int id, ClubBaseDto club)
        {
            var existedClub = clubService.GetByID(id);

            return new ClubBL
            {
                Id = id,
                Name = club.Name ?? existedClub.Name,
                Country = club.Country ?? existedClub.Country,
                FoundationDate = club.FoundationDate ?? existedClub.FoundationDate
            };
        }
    }
}
