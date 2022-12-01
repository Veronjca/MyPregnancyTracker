
using MyPregnancyTracker.Data.Enums;

namespace MyPregnancyTracker.Services.Models.ReactionsModels
{
    public class ReactionDto
    {
        public int Id { get; set; }

        public ReactionTypeEnum Type { get; set; }
    }
}
