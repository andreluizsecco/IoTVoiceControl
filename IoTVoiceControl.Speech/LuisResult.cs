using System.Collections.Generic;
using System.Runtime.Serialization;

namespace IoTVoiceControl.Speech
{
    public class TopScoringIntent
    {
        public string intent { get; set; }
        public double score { get; set; }
    }

    public class Intent
    {
        public string intent { get; set; }
        public double score { get; set; }
    }

    public class Entity
    {
        public string entity { get; set; }
        public string type { get; set; }
        public int startIndex { get; set; }
        public int endIndex { get; set; }
        public double score { get; set; }
    }

    [DataContract]
    public class LuisResult
    {
        [DataMember]
        public string query { get; set; }
        [DataMember]
        public TopScoringIntent topScoringIntent { get; set; }
        [DataMember]
        public List<Intent> intents { get; set; }
        [DataMember]
        public List<Entity> entities { get; set; }
    }
}
