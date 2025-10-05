using System.ComponentModel.DataAnnotations.Schema;

namespace ChatServiceMVC.Models
{
    public class Message
    {
        private readonly Guid _id;
        private string _content = null!;
        private readonly DateTime _created;
        private int _indexId;

        public Message()
        {
            _id = Guid.NewGuid();
            _created = DateTime.UtcNow;
        }
        public Guid Id
        {
            get => _id;
        }

        public string Content
        {
            get => _content;
            set => _content = value;
        }

        public DateTime Created
        {
            get => _created;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IndexId
        {
            get => _indexId;
            set => _indexId = value;
        }

    }
}
