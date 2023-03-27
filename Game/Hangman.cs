
namespace HangmanGame.Game
{
    public class Hangman
    {
        int wrongGuesses = 0;
        int correctPositionsOfLetters = 0;
        int indexForCorrectGuesses = 0;
        char[] correctGuesses = new char[26];
        char[] secretWord;
        char[] secretWordWithMask;
        public Hangman(string word)
        {
            secretWord = word.ToCharArray();
            secretWordWithMask = new Char[secretWord.Length]; 
        }
        public void Start()
        {

            for (int i = 0; i < secretWord.Length; i++)
            {
                secretWordWithMask[i] = '_'; // inicializando a palavra secreta com a mascara
            }

            while (!win() && !lose())
            {

                drawGallows();

                Console.Write("Digite uma letra: ");
                char.TryParse(Console.ReadLine(), out char guess);

                Console.Clear();

                // Se o palpite estiver nos palpites corretos, contiua para a proxima interação
                if (correctGuesses.Contains(guess)) continue;  

                tryGuess(guess);

            }

            if (win())
            {
                drawGallows();
                Console.WriteLine("Parabéns você acertou a palavra!!");
                Console.WriteLine($"Palavra secreta: {string.Concat(secretWord)}");
            }
            else
            {
                drawGallows();
                Console.WriteLine("Voce perdeu!!");
                Console.WriteLine($"Palavra secreta: {string.Concat(secretWord)}");
            }

        }
        void drawGallows()
        {

            Console.WriteLine(" _______  ");
            Console.WriteLine(" |/     | ");
            Console.WriteLine(" |     {0}{1}{2}", wrongGuesses >= 1 ? "(" : "", wrongGuesses >= 1 ? "_" : "", wrongGuesses >= 1 ? ")" : "");
            Console.WriteLine(" |     {0}{1}{2}", wrongGuesses >= 3 ? "\\" : " ", wrongGuesses >= 2 ? "|" : " ", wrongGuesses >= 4 ? "/" : " ");
            Console.WriteLine(" |      {0}", wrongGuesses >= 2 ? "|" : "");
            Console.WriteLine(" |     {0} {1}", wrongGuesses >= 5 ? "/" : " ", wrongGuesses >= 6 ? "\\" : " ");
            Console.WriteLine(" |");
            Console.WriteLine("----\n");

            
            foreach (var letter in secretWordWithMask)
            {
                Console.Write($"{letter} ");
            }
            Console.WriteLine("\n");

        }

        void tryGuess(char guess)
        {
            //se a palavra secreta não contém o palpite, a variavel wrongGuesses é incrementada
            if (!secretWord.Contains(guess))
            {
                wrongGuesses++;
                return;
            };

            correctGuesses[indexForCorrectGuesses] = guess;
            indexForCorrectGuesses++;

            // Encontra a posição correta da letra contida na palavra secreta;
            // Substitui a mascara pela letra correta
            for (int i = 0; i < secretWord.Length; i++)
            {

                if (secretWord[i] == guess)
                {
                    secretWordWithMask[i] = guess;
                    correctPositionsOfLetters++;

                }
            }

        }
        bool win()
        {
            return correctPositionsOfLetters >= secretWord.Length;
        }
        bool lose()
        {
            return wrongGuesses >= 6;
        }
    }
}
