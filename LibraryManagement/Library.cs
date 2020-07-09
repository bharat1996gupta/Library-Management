using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    class Library
    {
       public  List<Media> medias = new List<Media>()
        {
            new Book("Don Quixote", "Book", 1, 0, true, "", 452),
            new Book("A Tale of Two Cities", "Book", 2, 0, true, "", 841),
            new Book("The Lord of the Rings", "Book", 3, 0, true, "", 866),
            new Book("The Little Prince", "Book", 4, 0, true, "", 924),
            new Book("And Then There Were None ", "Book", 5, 0, true, "", 124),

            new Magazine("Better Homes & Gardens", "Magazine", 6, 0, true, "", 452, 64),
            new Magazine("Real Simple", "Magazine", 7, 0, true, "", 841, 32),
            new Magazine("EatingWell", "Magazine", 8, 0, true, "", 866, 82),
            new Magazine("Reader's Digest", "Magazine", 9, 0, true, "", 924, 69),
            new Magazine("Southern Living", "Magazine", 10, 0, true, "", 124, 49),

            new Movie("The Godfather", "Movie", 11, 0, true, "", 120.52),
            new Movie("The Shawshank Redemption", "Movie", 12, 0, true, "", 164.99),
            new Movie("Schindler's List ", "Movie", 13, 0, true, "", 155.50),
            new Movie("Iron Man", "Movie", 14, 0, true, "", 199.52),
            new Movie("Dark Knight", "Movie", 15, 0, true, "", 115.51),
        };
       public  List<LibraryMember> libraryMembers = new List<LibraryMember>()
        {
            new LibraryMember("HaRdEeP"),
            new LibraryMember("ChRiStY"),
            new LibraryMember("MaNpReEt"),
            new LibraryMember("NiTiN"),
            new LibraryMember("BhArAt")
        };
    }
}
