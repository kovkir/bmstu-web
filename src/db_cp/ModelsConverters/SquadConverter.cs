using db_cp.DTO;
using db_cp.ModelsBL;
using db_cp.Services;

namespace db_cp.ModelsConverters
{
    public class SquadConverters
    {
        private readonly ISquadService squadService;

        public SquadConverters(ISquadService squadService)
        {
            this.squadService = squadService;
        }

        public SquadBL convertPatch(int id, SquadBaseDto squad)
        {
            var existedSquad = squadService.GetByID(id);

            return new SquadBL
            {
                Id = id,
                CoachId = squad.CoachId ?? existedSquad.CoachId,
                Name = squad.Name ?? existedSquad.Name,
                Rating = squad.Rating ?? existedSquad.Rating
            };
        }
    }
}
