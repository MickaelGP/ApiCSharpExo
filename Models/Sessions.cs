using System.Reflection.Metadata.Ecma335;

namespace ExoTodo.Models
{
    public class Sessions
    {
        public int SessionId { get; set; }

        public DateTime SessionExpire { get; set; }

        public int SessionUtil { get; set; }

        public int SessionToken { get; set; }
    }
}
