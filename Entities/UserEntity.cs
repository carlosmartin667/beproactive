using SQLite;

namespace ApiDevBP.Entities
{
    [Table("Users")]
    public class UserEntity
    {
        [PrimaryKey, AutoIncrement]
        //[JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; } 
        public string Lastname { get; set; }
    }
}
