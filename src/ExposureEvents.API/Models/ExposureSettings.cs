using System;

namespace ExposureEvents.API.Models
{
    public class ExposureSettings
    {
        public bool EnableRegistration { get; set; }
        public int RosterLimit { get; set; }
        public RegistrationStatus RegistrationStatus { get; set; }
        public DateTime? RegistrationStartDate { get; set; }
        public DateTime? RegistrationEndDate { get; set; }
        public DateTime? RegistrationStartTime { get; set; }
        public DateTime? RegistrationEndTime { get; set; }
        public DateTime? ScheduleAvailabilityDate { get; set; }
        public DateTime? ScheduleAvailabilityTime { get; set; }
        public bool? ShowSchedule { get; set; }
        public bool? ShowPools { get; set; }
        public bool? ShowBrackets { get; set; }
        public bool? ShowTeams { get; set; }
    }
}