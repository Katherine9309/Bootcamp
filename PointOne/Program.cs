// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

//string phrase;
Console.WriteLine("Task_2 Point 1");
Console.WriteLine("Write the phrase to analyze: ");
string phrase = Console.ReadLine();
//string phrase = "Hgggh, jsj lkks, a lil-lil – lop";
phrase = phrase.Replace(',', ' ').Replace('–', ' ');
var words = phrase.Split( ' ');
string finalPhrase = default;
// Split the string

for (int i=0; i < words.Length; i++)
{
    words[i] = words[i].Trim();

    if (!(string.Equals(words[i], ""))) {
        var result = IsPalindrome(words[i]) ? " - palindrome, " : " - not palindrome, ";
        finalPhrase = finalPhrase + words[i] + result;
    }  
}
Console.Write(finalPhrase);
Console.ReadKey();


//methods

bool IsPalindrome(string str)
{
    char[] array = str.ToCharArray();
    int length = array.Length - 1;
    Boolean palindrome = true;
    for (int i = 0; i <= length; i++)
    {
        // para leter case StringComparison.OrdinalIgnoreCase
        if (string.Compare(array[i].ToString(), array[length].ToString(),true) != 0)
        {
            palindrome = false;
            break;
        }
        else
        {
            length--;
        }

    }
    return palindrome;
}
