namespace MVC_omroep_flevoland_chat_frontend.Models
{
    public class FileUpsert
    {
        object files;
        int basepath;
        int topK;

        public FileUpsert(object files, int topK)
        {
            this.files = files;
            this.topK = topK;
        }
    }
}
