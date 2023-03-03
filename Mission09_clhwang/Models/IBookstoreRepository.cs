using System.Linq;

namespace Mission09_clhwang.Models
{
    public interface IBookstoreRepository
    {
        IQueryable<Book> Books { get; }
    }
}
