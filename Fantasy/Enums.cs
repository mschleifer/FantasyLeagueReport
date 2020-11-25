namespace Fantasy
{
    public class PositionType
    {
        private PositionType(string value) { Value = value; }

        public string Value { get; set; }

        public static PositionType QB => new PositionType("QB");
        public static PositionType TQB => new PositionType("TQB");
        public static PositionType RB => new PositionType("RB");
        public static PositionType WR => new PositionType("WR");
        public static PositionType TE => new PositionType("TE");
        public static PositionType DST => new PositionType("D/ST");
        public static PositionType K => new PositionType("K");
        public static PositionType RBWR => new PositionType("RB/WR");
        public static PositionType WRTE => new PositionType("WR/TE");
        public static PositionType RBWRTE => new PositionType("RB/WR/TE");
        public static PositionType OP => new PositionType("OP");
        public static PositionType Bench => new PositionType("Bench");
        public static PositionType IR => new PositionType("IR");

    }
}
