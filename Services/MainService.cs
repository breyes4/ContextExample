using ContextExample.Data;
using System;
using System.ComponentModel;

namespace ContextExample.Services;

public class MainService : IMainService
{
    private readonly IContext _context;

    public MainService(IContext context)
    {
        _context = context;
    }

    public void Invoke()
    {
        // provide an option to the user to 
        // 1. select by id
        // 2. select by title 
        // 3. find movie by title
        
        Console.WriteLine("1. Choose by ID\n2. Choose by Title\n3. Search Movies by Title");
        Console.Write("Selection option please\n>");
        
        var input = Console.ReadLine();
        
        switch (input) {
            case "1":
                Console.Write("Enter movies ID.\n>");
                var isValid = Int32.TryParse(Console.ReadLine(), out int userID);
                if (isValid)
                {
                    var movie = _context.GetById(userID);

                    Console.WriteLine($"Your movie is {movie.Title}");
                }
                else
                {
                    Console.WriteLine("Incorrect Movie ID. Try again please. ⟲ ");
                }
                break;
            
            case "2":
                Console.Write("Enter movies name.\n>");
                var movieTitle = _context.GetByTitle(Console.ReadLine());
                if (movieTitle == null)
                {
                    Console.Write("Incorrect Movie Title. Try again please."); 
                    break;
                }
                Console.WriteLine($"{movieTitle.Title} has been found.");
                break;
           
            case "3":
                Console.Write("Select movie via search option.\n>");
                var search = Console.ReadLine();
                var movies = _context.FindMovie(search);
                foreach(var mov in movies)
                {
                    Console.WriteLine(mov.Title);
                }
                break;
            
            default:
                break;
        }
    }
}
