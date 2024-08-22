using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BooksApp.Data.Abstract;
using BooksApp.Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace BooksApp.Data.Concrete.EfCore.Repositories
{
    public class EfCoreBookRepository : EfCoreGenericRepository<Book>, IBookRepository
    {
        public EfCoreBookRepository(BooksAppDbContext booksAppDbContext)
            : base(booksAppDbContext) { }

        private BooksAppDbContext Context
        {
            get { return _dbContext as BooksAppDbContext; }
        }

        public async Task ClearBookCategoriesAsync(int bookId)
        {
            List<BookCategory> bookCategories = await Context
                .BookCategories
                .Where(bc => bc.BookId==bookId)
                .ToListAsync();
            Context.BookCategories.RemoveRange(bookCategories);
            await Context.SaveChangesAsync();
        }

        public async Task<Book> CreateBookWithCategoriesAsync(Book book, List<int> categoryIds)
        {
            var createdBook = await Context.Books.AddAsync(book);
            if (createdBook != null)
            {
                await Context.SaveChangesAsync();
                var bookCategories = categoryIds
                    .Select(x => new BookCategory { BookId = book.Id, CategoryId = x })
                    .ToList();
                await Context.BookCategories.AddRangeAsync(bookCategories);
                await Context.SaveChangesAsync();
            }
            var result = await GetBookWithCategoriesAsync(book.Id);
            return result;
        }

        public async Task<List<Book>> GetActiveBooksAsync(bool isActive)
        {
            List<Book> books = await Context
                .Books
                .Where(b => b.IsActive==isActive)
                .Include(b => b.BookCategories)
                .ThenInclude(bc => bc.Category)
                .ToListAsync();
            return books;
                
        }

        public async Task<List<Book>> GetBooksByCategoryIdAsync(int categoryId)
        {
            List<Book> books = await Context
                .Books.Include(x => x.BookCategories)
                .ThenInclude(y => y.Category)
                .Where(x => x.BookCategories.Any(y => y.CategoryId == categoryId))
                .ToListAsync();
            return books;
        }

        public async Task<List<Book>> GetBooksWithCategoriesAsync()
        {
            List<Book> books = await Context
                .Books
                .Include(x => x.BookCategories)
                .ThenInclude(y => y.Category)
                .Include(x=>x.Author)
                .ToListAsync();
            return books;
        }

        public async Task<Book> GetBookWithCategoriesAsync(int id)
        {
            Book book = await Context
                .Books.Where(x => x.Id == id)
                .Include(x => x.BookCategories)
                .ThenInclude(y => y.Category)
                .FirstOrDefaultAsync();
            return book;
        }

        public async Task<int> GetCount(int? categoryId = null)
        {
            int count=0;
            if(categoryId==null){
                count = await Context.Books.CountAsync();
            }else{
                var bookCategoryList = await Context.BookCategories.ToListAsync();
                foreach (var bc in bookCategoryList)
                {
                    if (bc.CategoryId==categoryId)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        public async Task<List<Book>> GetHomeBooksAsync()
        {
            List<Book> books = await Context
                .Books
                .Where(b => b.IsActive && b.IsHome)
                .Include(b => b.BookCategories)
                .ThenInclude(bc => bc.Category)
                .Include(b=>b.Author)
                .ToListAsync();
            return books;            
        }
    }
}
