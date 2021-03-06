﻿namespace FitDontQuit.Common
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
            public const int TitleMinLenght = 3;
            public const int TitleMaxLenght = 100;
        }

        public static class GroupTraining
        {
            public const int NameMaxLenght = 50;
        }

        public static class Class
        {
            public const int CapacityMinCount = 5;
            public const int CapacityMaxCount = 300;
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

            public const int MinPhoneLenght = 5;
            public const int MaxPhoneLenght = 15;

            public const int DescriptionMaxLenght = 100;
        }
    }
}
