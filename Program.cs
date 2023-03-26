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
        string[] animal = { "abelha", "aguia", "aranha","arara",
                            "avestruz","barata","baleia","bode",
                            "burro","camelo","cachorro","cavalo",
                            "coelho","elefante","escorpiao","foca",
                            "formiga", "falcao","galinha","gorila",
                            "jacare","javali","lagosta","leao","macaco",
                            "mariposa","morcego","mosca","ovelha","peru",
                            "porco","polvo","rato","raposa","tartaruga",
                            "tatu","tigre","touro","urubu" };
        
        string[][] wordType= { fruits, animal };

        var random = new Random();
        int wordTypeIndex = random.Next(wordType.Length);
        int wordIndex;
        string randomWord = "";

        switch (wordTypeIndex)
        {
            case 0:
                wordIndex = random.Next(wordType[wordTypeIndex].Length);
                randomWord = wordType[wordTypeIndex][wordIndex];
                Console.WriteLine($"A palavra secreta é uma fruta com {randomWord.Length} letras!");
                break;
            case 1:
                wordIndex = random.Next(wordType[wordTypeIndex].Length);
                randomWord = wordType[wordTypeIndex][wordIndex];
                Console.WriteLine($"A palavra secreta é um animal com {randomWord.Length} letras!");
                break;
            default: break;
        }
        
        //randomWord = fruits[random.Next(fruits.Length)];
        //Console.WriteLine($"A palavra secreta é uma fruta com {randomWord.Length} letras!");

        var hangman = new Hangman(randomWord);
        hangman.Start();
    }


}
