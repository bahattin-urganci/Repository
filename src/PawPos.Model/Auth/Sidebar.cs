using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PawPos.Model.Auth
{
    public class Sidebar
    {

        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("icon")]
        public string Icon { get; set; }
        [JsonProperty("path")]
        public string Target { get; set; }
        [JsonProperty("params")]
        public object Params { get; set; }
        [JsonProperty("submenu")]
        public List<Sidebar> SubMenu { get; set; }
        public bool Checked { get; set; }
        public Sidebar()
        {
            SubMenu = new List<Sidebar>();
        }
    }
}
