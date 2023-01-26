using db_cp.DTO;
using db_cp.ModelsBL;
using db_cp.Services;

namespace db_cp.ModelsConverters
{
    public class AgentConverters
    {
        private readonly IAgentService agentService;

        public AgentConverters(IAgentService agentService)
        {
            this.agentService = agentService;
        }

        public AgentBL convertPatch(int id, AgentBaseDto agent)
        {
            var existedAgent = agentService.GetByID(id);

            return new AgentBL
            {
                Id = id,
                PlayerId = agent.PlayerId ?? existedAgent.PlayerId,
                Surname = agent.Surname ?? existedAgent.Surname,
                Country = agent.Country ?? existedAgent.Country
            };
        }
    }
}
