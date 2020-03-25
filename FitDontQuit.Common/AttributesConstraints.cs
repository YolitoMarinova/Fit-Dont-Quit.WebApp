namespace FitDontQuit.Common
{
    public static class AttributesConstraints
    {
        public static class User
        {
            public const int UsernameMinLenght = 6;
            public const int UsernameMaxLenght = 20;

            public const int NameMinLenght = 2;
            public const int NameMaxLenght = 50;
        }

        public static class Article
        {
            public const int TitlemaxLenght = 100;
        }

        public static class GroupTraining
        {
            public const int NameMaxLenght = 50;
        }

        public static class Hall
        {
            public const int NameMaxLenght = 100;

            public const int SeatsMinCount = 5;
            public const int SeatsMaxCount = 300;
        }

        public static class Membership
        {
            public const int NameMaxLenght = 50;

            public const double MinPriceValue = 0;
            public const double MaxPriceValue = double.MaxValue;
        }

        public static class Period
        {
            public const int MinYearsValue = 0;
            public const int MaxYearsValue = 10;

            public const int MinMonthsValue = 0;
            public const int MaxMonthsValue = 12;

            public const int MinDaysValue = 0;
            public const int MaxDaysValue = 31;
        }

        public static class Profession
        {
            public const int NameMaxLenght = 50;
        }

        public static class Service
        {
            public const int NameMaxLenght = 50;

            public const double MinPriceValue = 0;
            public const double MaxPriceValue = double.MaxValue;
        }

        public static class Trainer
        {
            public const int NameMinLenght = 2;
            public const int NameMaxLenght = 50;

            public const int MinimumAge = 16;
            public const int MaximumAge = 120;

            public const int DescriptionMaxLenght = 1000;
        }
    }
}
