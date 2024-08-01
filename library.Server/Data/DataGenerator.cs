using Bogus;

namespace library.Server.Data
{
    public class DataGenerator
    {   
        public List<Book> GenerateBooks(int numberOfBooks)
        {
            var faker = new Faker<Book>()
                .RuleFor(b => b.ISBN, f => f.Random.Number())
                .RuleFor(b => b.Category, f => f.Random.Word())
                .RuleFor(b => b.Publisher, f => f.Random.Word())
                .RuleFor(b => b.Author, f => f.Name.FullName())
                .RuleFor(b => b.Description, f => f.Random.Word())
                .RuleFor(b => b.PageCount, f => f.Random.Number())
                .RuleFor(b => b.Title, f => f.Random.Word())
                .RuleFor(b => b.CoverImageUrl, f => f.Internet.Avatar())
                .RuleFor(b => b.PublicationDate, f => DateTime.Now)
                ;

            return faker.Generate(numberOfBooks);
        }
    }
}
