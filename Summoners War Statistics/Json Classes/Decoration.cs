﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Summoners_War_Statistics
{
    public partial class Decoration
    {
        [JsonProperty("wizard_id")]
        public long? WizardId { get; set; }

        [JsonProperty("deco_id")]
        public long? DecoId { get; set; }

        [JsonProperty("master_id")]
        public long? MasterId { get; set; }

        [JsonProperty("island_id")]
        public long? IslandId { get; set; }

        [JsonProperty("pos_x")]
        public long? PosX { get; set; }

        [JsonProperty("pos_y")]
        public long? PosY { get; set; }

        [JsonProperty("level")]
        public long? Level { get; set; }
    }
}
