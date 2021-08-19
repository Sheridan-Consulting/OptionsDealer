namespace Data.MongoDB
{
    public class OptionTransaction : OptionTransactionBase
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int Id { get; set; }
    }
}