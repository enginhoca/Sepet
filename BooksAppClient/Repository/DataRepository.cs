using BooksAppClient.Models;

namespace BooksAppClient.Repository
{
    public static class DataRepository
    {
        private static readonly List<CategoryViewModel> _categories = [
            new CategoryViewModel() { Id=1, Name="Hikaye", CountOfBooks=125, Description="Lorem, ipsum dolor sit amet consectetur adipisicing elit. Laboriosam quisquam illum ea doloremque eligendi similique inventore eveniet modi eaque qui non eius voluptate quaerat, id, molestiae provident, doloribus pariatur hic." },
            new CategoryViewModel() { Id=2, Name="Roman", CountOfBooks=752, Description="Lorem, ipsum dolor sit amet consectetur adipisicing elit. Laboriosam quisquam illum ea doloremque eligendi similique inventore eveniet modi eaque qui non eius voluptate quaerat, id, molestiae provident, doloribus pariatur hic." },
            new CategoryViewModel() { Id=3, Name="Yazılım Geliştirme", CountOfBooks=65, Description="Lorem, ipsum dolor sit amet consectetur adipisicing elit. Laboriosam quisquam illum ea doloremque eligendi similique inventore eveniet modi eaque qui non eius voluptate quaerat, id, molestiae provident, doloribus pariatur hic." },
            new CategoryViewModel() { Id=4, Name="Yapay Zeka", CountOfBooks=496, Description="Lorem, ipsum dolor sit amet consectetur adipisicing elit. Laboriosam quisquam illum ea doloremque eligendi similique inventore eveniet modi eaque qui non eius voluptate quaerat, id, molestiae provident, doloribus pariatur hic." },
            new CategoryViewModel() { Id=5, Name="Şiir", CountOfBooks=44, Description="Lorem, ipsum dolor sit amet consectetur adipisicing elit. Laboriosam quisquam illum ea doloremque eligendi similique inventore eveniet modi eaque qui non eius voluptate quaerat, id, molestiae provident, doloribus pariatur hic." }
        ];

        private static readonly List<BookViewModel> _books = [
            new BookViewModel()
            {
                Id=1, 
                Name="Kitap1", 
                Properties="Kitap1 özellikleri", 
                Summary="Kitap1 özeti", 
                Stock=30, 
                Price=175, 
                PageCount=410, 
                EditionYear=2020,
                EditionNumber=3,
                ImageUrl="kitap1.png", 
                Categories= new List<CategoryViewModel>
                {
                    new CategoryViewModel() { Id=1, Name="Hikaye" },
                    new CategoryViewModel() { Id=2, Name="Roman" }
                }
            },
            new BookViewModel()
            {
                Id=2,
                Name="Kitap2",
                Properties="Kitap2 özellikleri",
                Summary="Kitap2 özeti",
                Stock=30,
                Price=175,
                PageCount=410,
                EditionYear=2020,
                EditionNumber=3,
                ImageUrl="kitap2.png",
                Categories= new List<CategoryViewModel>
                {
                    new CategoryViewModel() { Id=3, Name="Yazılım Geliştirme" },
                    new CategoryViewModel() { Id=4, Name="Yapay Zeka" },
                    new CategoryViewModel() { Id=5, Name="Şiir" }
                }
            },
            new BookViewModel()
            {
                Id=3,
                Name="Kitap3",
                Properties="Kitap3 özellikleri",
                Summary="Kitap3 özeti",
                Stock=30,
                Price=175,
                PageCount=410,
                EditionYear=2020,
                EditionNumber=3,
                ImageUrl="kitap3.png",
                Categories= new List<CategoryViewModel>
                {
                    new CategoryViewModel() { Id=3, Name="Yazılım Geliştirme" },
                    new CategoryViewModel() { Id=4, Name="Yapay Zeka" },
                    new CategoryViewModel() { Id=5, Name="Şiir" },
                    new CategoryViewModel() { Id=6, Name="Deneme" }
                }
            },
            new BookViewModel()
            {
                Id=4,
                Name="Kitap4",
                Properties="Kitap4 özellikleri",
                Summary="Kitap4 özeti",
                Stock=30,
                Price=175,
                PageCount=410,
                EditionYear=2020,
                EditionNumber=3,
                ImageUrl="kitap4.png",
                Categories= new List<CategoryViewModel>
                {
                    new CategoryViewModel() { Id=2, Name="Roman" },
                    new CategoryViewModel() { Id=3, Name="Yazılım Geliştirme" },
                    new CategoryViewModel() { Id=4, Name="Yapay Zeka" },
                    new CategoryViewModel() { Id=5, Name="Şiir" }
                }
            }
        ];
        public static List<BookViewModel> GetBooks()
        {
            return _books;
        }
        public static List<CategoryViewModel> GetCategories()
        {
            return _categories;
        }
        public static BookViewModel GetBook(int id)
        {
            return _books.Where(x => x.Id==id).FirstOrDefault();
        }
        public static CategoryViewModel GetCategory(int id)
        {
            return _categories.Where(x => x.Id==id).FirstOrDefault();
        }
    }
}
