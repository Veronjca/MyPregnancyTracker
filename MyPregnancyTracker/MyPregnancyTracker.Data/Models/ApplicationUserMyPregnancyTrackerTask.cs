namespace MyPregnancyTracker.Data.Models
{
    public class ApplicationUserMyPregnancyTrackerTask
    {
        public int ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public int MyPregnancyTrackerTaskId { get; set; }

        public MyPregnancyTrackerTask MyPregnancyTrackerTask { get; set; }
    }
}
