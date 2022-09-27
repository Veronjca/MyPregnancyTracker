﻿namespace MyPregnancyTracker.Data.Models
{
    internal interface IAuditInfo
    {
        bool IsDeleted { get; set; }

        DateTime CreatedOn { get; set; }

        DateTime? ModifiedOn { get; set; }

        DateTime? DeletedOn { get; set; }
    }
}
