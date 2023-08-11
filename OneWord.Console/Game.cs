namespace OneWord.Console;

using System;

public class Game
{
    public string[] Words;
    public int Point = 0;
    public char[] AvailableLetters ={ 'S', 'E', 'Ğ', 'V', 'D', 'L', 'A', 'K' };
    public LetterNode Root;
    public Game()
    {
        Words = File.ReadAllLines("words.txt");
        Root = ConstructLetterTrie();
    }

    public void Start()
    {
        string? word = null;
        while (word == null)
        {
            Console.Write("Bir sözcük giriniz:");
            word = Console.ReadLine();
            if (word == null) continue;
            // var letters = word.ToCharArray();

            foreach (char letter in word)
            {
                var result = Root[letter];
            }
            
            if (Words.Contains(word))
            {
                Point += word.Length;
                Console.WriteLine("Toplam puan = " + Point);
                word = null;
            }
            
            
        }
    }
    
    public LetterNode ConstructLetterTrie()
    {
        var root = new LetterNode();
        Array.ForEach(Words, word => root.Set(word));
        return root;
    }
}