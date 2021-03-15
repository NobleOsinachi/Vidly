using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Genre
    {
        public byte Id { get; set; }
        public string Name { get; set; }
    }
}

/**
Sql("INSERT INTO Genre (Id ,Name) VALUES(1, 'Comedy')");
Sql("INSERT INTO Genre (Id ,Name) VALUES(2, 'Sci-Fi')");
Sql("INSERT INTO Genre (Id ,Name) VALUES(3, 'Comedy')");
Sql("INSERT INTO Genre (Id ,Name) VALUES(4, 'Action')");
Sql("INSERT INTO Genre (Id ,Name) VALUES(5, 'Family')");
Sql("INSERT INTO Genre (Id ,Name) VALUES(6, 'Romance')");
*/
