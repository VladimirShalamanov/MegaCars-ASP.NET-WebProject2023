namespace MegaCarsSystem.Common
{
    public static class GeneralApplicationConstants
    {
        public const int ReleaseYear = 2023;

        // For the sorting part of the Аpp.
        public const int DefaultPage = 1;
        public const int EntitiesPerPage = 3;

        // For implementation of Guest User
        public const string GuestFirstName = "Guest";
        public const string GuestLastName = "User_Test";
        public const string GuestEmail = "guest@guest.com";
        public const string GuestPassword = "guest1122";

        // For implementation of Agent User
        public const string AgentFirstName = "Agent";
        public const string AgentLastName = "User_Test";
        public const string AgentEmail = "agent@agent.com";
        public const string AgentPassword = "agent1122";

        // For implementation of Admin
        public const string AdminRoleName = "Administrator";
        public const string DevelopmentAdminEmail = "admin@admin.com";
    }
}