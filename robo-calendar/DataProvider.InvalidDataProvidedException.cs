namespace robo_calendar
{
    [Serializable]
    internal class InvalidDataProvidedException : Exception
    {
        public InvalidDataProvidedException() : base("Provided data contains delimeter. ") { }
    }
}
