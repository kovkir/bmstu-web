using db_cp.DTO;
using db_cp.ModelsBL;
using db_cp.Services;

namespace db_cp.ModelsConverters
{
    public class CoachConverters
    {
        private readonly ICoachService coachService;

        public CoachConverters(ICoachService coachService)
        {
            this.coachService = coachService;
        }

        public CoachBL convertPatch(int id, CoachBaseDto coach)
        {
            var existedCoach = coachService.GetByID(id);

            return new CoachBL
            {
                Id = id,
                Surname = coach.Surname ?? existedCoach.Surname,
                Country = coach.Country ?? existedCoach.Country,
                WorkExperience = coach.WorkExperience ?? existedCoach.WorkExperience
            };
        }
    }
}
