namespace ExposureEvents.API.Models
{
    public enum ReportOutput
    {
        HTML,
        PDF
    }
    public enum Gender
    {
        MaleOrFemale = 0,
        Male = 1,
        Female = 2
    }

    public enum RegistrationStatus
    {
        All = 1,
        Active = 2,
        ActiveAndPaid = 3,
        ActivePaidAndTravel = 4
    }

    public enum Status
    {
        None = 0,
        Active = 1,
        Inactive = 2,
        WaitingList = 3
    }

    public enum PriceType
    {
        EventFee = 1,
        Other = 2,
        CollegeCoachesPacket = 2,
        SanctionFee = 4
    }

    public enum CoachType
    {
        Other = 0,
        HeadCoach = 1,
        AssistantCoach = 2,
        Administrator = 3,
        AdministratorOrHeadCoach = 4,
        AdministratorOrCoach = 5,
        BenchCoach = 6,
        Coach = 7,
        Manager = 8
    }

    public enum EventType
    {
        Tournament = 0,
        League = 1,
        CampOrClinic = 2,
        Tryout = 3
    }

    public enum ParticipationType
    {
        Team = 0,
        Individual = 1
    }

    public enum AgeGroupType
    {
        Youth = 0,
        Adult = 1,
        AdultOrYouth = 2
    }

    public enum ParticipantWonByTypes
    {
        Forfeit = 7
    }

    public enum EventInviteType
    {
        All = 0,
        Travel = 3,
        School = 4,
        InviteOnly = 9,
        JuniorVarsity = 10,
        Freshman = 11,
        HighSchool = 12,
        MiddleSchool = 13,
        ElementarySchool = 14,
        Varsity = 15
    }

    public enum EventsIncludes
    {
        Assets,
        Divisions,
        Venues,
        Organization,
        Prices,
        Reports,
        Settings,
        Season
    }

    public enum DivisionIncludes
    {
        Assets,
        Brackets,
        Prices,
        Reports,
        Results,
        Settings,
        Teams
    }

    public enum TeamIncludes
    {
        Players,
        Coaches,
        Pools
    }

    public enum PlayerIncludes
    {
        Profile,
        Teams,
        Statistics
    }

    public enum GameIncludes
    {
        Season
    }
}