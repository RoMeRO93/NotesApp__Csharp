using System;
using System.Collections.Generic;

class NotesApp
{
    static void Main()
    {
        Console.WriteLine("Welcome to Notes App!");

        List<string> notes = new List<string>();

        bool continueEditing = true;

        while (continueEditing)
        {
            Console.WriteLine("\nWhat would you like to do?");
            Console.WriteLine("1. Add a new note");
            Console.WriteLine("2. View all notes");
            Console.WriteLine("3. Edit a note");
            Console.WriteLine("4. Delete a note");
            Console.WriteLine("5. Search notes");
            Console.WriteLine("6. Sort notes");
            Console.WriteLine("7. Exit");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter your note: ");
                    string newNote = Console.ReadLine();
                    notes.Add(newNote);
                    Console.WriteLine("Note added successfully.");
                    break;
                case "2":
                    Console.WriteLine("All Notes:");
                    if (notes.Count > 0)
                    {
                        for (int i = 0; i < notes.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {notes[i]}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No notes found.");
                    }
                    break;
                case "3":
                    Console.Write("Enter the note number to edit: ");
                    int noteIndex = Convert.ToInt32(Console.ReadLine()) - 1;
                    if (noteIndex >= 0 && noteIndex < notes.Count)
                    {
                        Console.Write("Enter the updated note: ");
                        string updatedNote = Console.ReadLine();
                        notes[noteIndex] = updatedNote;
                        Console.WriteLine("Note edited successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid note number.");
                    }
                    break;
                case "4":
                    Console.Write("Enter the note number to delete: ");
                    int noteToDeleteIndex = Convert.ToInt32(Console.ReadLine()) - 1;
                    if (noteToDeleteIndex >= 0 && noteToDeleteIndex < notes.Count)
                    {
                        string deletedNote = notes[noteToDeleteIndex];
                        notes.RemoveAt(noteToDeleteIndex);
                        Console.WriteLine($"Note '{deletedNote}' deleted successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid note number.");
                    }
                    break;
                case "5":
                    Console.Write("Enter the search term: ");
                    string searchTerm = Console.ReadLine();
                    List<string> searchResults = SearchNotes(notes, searchTerm);
                    if (searchResults.Count > 0)
                    {
                        Console.WriteLine($"Search Results for '{searchTerm}':");
                        for (int i = 0; i < searchResults.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {searchResults[i]}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"No results found for '{searchTerm}'.");
                    }
                    break;
                case "6":
                    Console.WriteLine("Choose a sorting option:");
                    Console.WriteLine("a. Sort by date (oldest to newest)");
                    Console.WriteLine("b. Sort by date (newest to oldest)");
                    Console.WriteLine("c. Sort alphabetically (A to Z)");
                    Console.WriteLine("d. Sort alphabetically (Z to A)");
                    Console.Write("Enter your choice: ");
                    string sortOption = Console.ReadLine();
                    SortNotes(notes, sortOption);
                    Console.WriteLine("Notes sorted successfully.");
                    break;
                case "7":
                    continueEditing = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }

        Console.WriteLine("\nThank you for using the Notes App!");
    }

    static List<string> SearchNotes(List<string> notes, string searchTerm)
    {
        List<string> searchResults = new List<string>();

        foreach (string note in notes)
        {
            if (note.Contains(searchTerm))
            {
                searchResults.Add(note);
            }
        }

        return searchResults;
    }

    static void SortNotes(List<string> notes, string sortOption)
    {
        switch (sortOption)
        {
            case "a":
                notes.Sort();
                break;
            case "b":
                notes.Sort((x, y) => y.CompareTo(x));
                break;
            case "c":
                notes.Sort((x, y) => string.Compare(x, y, StringComparison.OrdinalIgnoreCase));
                break;
            case "d":
                notes.Sort((x, y) => string.Compare(y, x, StringComparison.OrdinalIgnoreCase));
                break;
            default:
                Console.WriteLine("Invalid sort option. Notes not sorted.");
                break;
        }
    }
}
