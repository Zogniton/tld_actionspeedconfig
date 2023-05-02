using ModSettings;

namespace ActionSpeedConfig {
    internal class ActionSpeedConfigSettings : JsonModSettings {
        internal static ActionSpeedConfigSettings Instance;
        [Name("Container search")]
        [Description("Determines how long the circle animation takes. (seconds)")]
        [Slider(0f, 10f, 21)]
        public float containerSearchTime = 3f;
        
        [Name("Eating/Drinking")]
        [Description("Determines how long the circle animation takes. (seconds)")]
        [Slider(0f, 10f, 21)]
        public float eatTime = 3f;

        [Name("Carcas harvest/quarter action time multiplier")]
        [Description("Determines how long the circle animation takes. (seconds)")]
        [Slider(0f, 10f, 21)]
        public float carcasHarvestTime = 5f;

        [Name("Fishing/Clearing ice")]
        [Description("Determines how long the circle animation takes. (seconds)")]
        [Slider(0f, 10f, 21)]
        public float fishingTime = 5f;

        [Name("Harvest plants")]
        [Description("Determines how long the circle animation takes. (seconds)")]
        [Slider(0f, 10f, 21)]
        public float plantHarvestTime = 3f;

        //[Name("Instantly search empty containers")]
        //[Description("Empty containers are searched instantly regardless of multiplier.")]
        //public bool instantlySearchEmpty = true;
    }
}
