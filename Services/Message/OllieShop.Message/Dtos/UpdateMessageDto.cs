namespace OllieShop.Message.Dtos
{
    public class UpdateMessageDto
    {
        public int MessageId { get; set; }
        public string SenderId { get; set; }
        public string ReceiverId { get; set; }
        public string SenderName { get; set; }
        public string ReceiverName { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public bool IsRead { get; set; }
        public DateTime SentAt { get; set; }
    }
}
