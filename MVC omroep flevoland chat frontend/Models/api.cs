namespace MVC_omroep_flevoland_chat_frontend.Models
{
    public class API
    {
        private string baseUrl;
        private string flowID;
        public API(string baseUrl, string flowID)
        {
            this.baseUrl = baseUrl;
            this.flowID = flowID;
        }
        public string BaseUrl { get { return this.baseUrl; } }
        public string FlowID { get { return flowID; } }
    }
}
