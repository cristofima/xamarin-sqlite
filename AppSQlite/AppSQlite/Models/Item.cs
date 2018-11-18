using SQLite;

namespace AppSQlite.Models
{
    [Table("Items")]
    public class Item
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Notes { get; set; }
        public bool Done { get; set; }

         public Item(Item it)
        {
            this.Name = it.Name;
            this.Id = it.Id;
            this.Notes = it.Notes;
            this.Done = it.Done;
        }

        public Item() { }
    }
}