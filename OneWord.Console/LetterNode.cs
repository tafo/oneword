namespace OneWord.Console;

public class LetterNode
{
    public bool IsLastLetter { get; set; }
    public char Letter { get; set; }
    public List<LetterNode> ChildNodes { get; set; }
    
    public LetterNode(char letter = '#')
    {
        Letter = letter;
        ChildNodes = new List<LetterNode>();
    }
    
    public LetterNode this[char letter] => ChildNodes.Find(x => x.Letter == letter);
    
    public void Set(string word)
    {
        var lastTrie = word.Aggregate(this, (currentTrie, letter) => currentTrie.Set(letter));
        lastTrie.IsLastLetter = true;
    }
    
    private LetterNode Set(char letter)
    {
        return this[letter] ?? Create(letter);
    }
    
    private LetterNode Create(char letter)
    {
        var trie = new LetterNode(letter);
        ChildNodes.Add(trie);
        return trie;
    }
}