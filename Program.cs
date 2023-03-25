using HangmanGame.Game;
public class Program
{
    public static void Main(string[] args)
    {
        string[] fruits = { "abacate", "amora", "ameixa",
                            "acerola", "abacaxi", "açai",
                            "banana", "carambola", "cereja",
                            "cacau", "caqui", "cupuaçu", "damasco",
                            "figo", "framboesa", "graviola", "goiaba",
                            "groselia", "guarana", "jaca", "kiwi",
                            "laranja", "limao", "lima",
                            "melancia", "mamao", "melao"
                          };

        var random = new Random();
        var index = random.Next(fruits.Length);
        string randomWord = fruits[index];
        Console.WriteLine("A palavra secreta é uma fruta!");

        var hangman = new Hangman(randomWord);
        hangman.Start();
    }


}
