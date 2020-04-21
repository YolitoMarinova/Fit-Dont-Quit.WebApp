namespace FitDontQuit.Common
{
    public static class ErrorMessages
    {
        public const string InvalidImageType = "Image should be in jpeg/png/svg format!";

        public static class Class
        {
            public const string InvalidHours = "Start time of the event could not be bigger than the end time!";

            public const string DayAndTimeIsTakenError = "There is alredy class in this time and day.";
        }

        public static class GroupTraining
        {
            public const string ImageIsRequired = "Image is required!";
        }

        public static class PurchasedMembership
        {
            public const string InvalidStartDate = "Start date should be today or after!";
        }
    }
}
