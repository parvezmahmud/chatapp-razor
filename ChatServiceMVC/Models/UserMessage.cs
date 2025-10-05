using System.ComponentModel.DataAnnotations.Schema;

namespace ChatServiceMVC.Models
{
    public class UserMessage
    {
        private readonly Guid _id;
        private int _indexId;
        public Guid Id
        {
            get => _id;
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IndexId
        {
            get => _indexId;
            set => _indexId = value;
        }

        [ForeignKey(nameof(User.UserId))]
        public required string SenderId { get; set; }

        [ForeignKey(nameof(Message.Id))]
        public required Guid MessageId {  get; set; }

        [ForeignKey(nameof(User.UserId))]
        public required string ReceiverId {  get; set; }
    }
}
