namespace DBTest1
{
    public class Message
    {
        public int MessageId {  get; set; }
        public string? MessageText { get; set; }
        public DateTime? DateSend { get; set; }
        public bool IsSend { get; set; }
        public int UserToId { get; set; }
        public int UserFromId { get; set; }
        public virtual User UserTo { get; set; }
        public virtual User UserFrom { get; set; }

    }
}
