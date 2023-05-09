namespace Basics;

public class Training
{
        /*
     * Ecrire une fonction **FiBuzz(int n)** qui affiche tous les entiers de 1 à n, un par ligne.
     * Si l'entier est multiple de 3, afficher "Fizz" au lieu de l'entier.
     * Si l'entier est multiple de 5, afficher "Buzz" au lieu de l'entier.
     * Si l'entier est à la fois multiple de 3 et de 5, afficher "FizzBuzz" au lieu de l'entier.
     */
    public static void FiBuzz(int n)
    {
        for (int i = 0; i <= n; i++)
        {
            if (i % 3 == 0)
            {
                Console.WriteLine(i % 5 == 0 ? "FizzBuzz" : "Fizz");
            }
            else if (i % 5 == 0)
                Console.WriteLine("Buzz");
            else
                Console.WriteLine($"{i}");
        }
    }

    /*
     * Ecrire une fonction récursive Factorielle(int n),
     * qui prend en entrée un entier positif n et retourne sa factorielle.
     */
    public static int Factorielle(int n)
    {
        if (n != 1)
            return n * Factorielle(n-1);
        else
            return n;
    }

    /*
     * Ecrire une fonction Fibonacci : F(n) = F(n-1) + F(n-2)
     * La suite de Fibonacci est une suite d'entiers dans laquelle chaque terme est la somme des deux termes qui le précèdent.
     * Elle commence par les termes 0 et 1.
     */
    public static int Fibonacci(int n)
    {
        if (n == 1)
            return 0;
        else if (n == 2)
            return 1;
        else
            return Fibonacci(n - 1) + Fibonacci(n - 2);
    }

    /*
     * Ecrire une fonction EstPalindrome(string s) qui prend en entrée une chaîne de caractères
     * et qui retourne vrai si la chaîne est un palindrome
     * (c'est-à-dire si elle peut être lue de la même façon de gauche à droite et de droite à gauche), et faux sinon.
     * Attention a prendre en compte les majuscule et les espaces
     * Exemple : "kayak" est un palindrome, "Eric notre valet alla te laver ton cire» en est un aussi
     */
    public static bool EstPalindrome(string s)
    {
        int lon = s.Length-1;
        s=s.ToLower();
        for (int j = 0; j <= lon; j++)
        {
            if (s[lon] == ' ')
            {
                lon -= 1;
                if (j != ' ')
                    j -= 1;
                continue;
            }
            if (s[j] == ' ')
                continue;
            if (s[j] != s[lon])
                return false;
            lon -= 1;

        }
        return true;
    }

    /*
     * Ecrire une fonction FilterList(List<int> liste, Func<int, bool> predicate),
     * qui prend en entrée une liste d'entiers et une fonction prédicat,
     * et qui retourne une nouvelle liste ne contenant que les éléments de la liste d'origine
     * pour lesquels la fonction prédicat retourne vrai.
     * La fonction doit utiliser une lambda expression pour le prédicat.
     */
    public static List<int> FilterList(List<int> list, Func<int, bool> predicate) => list.FindAll(elem => predicate(elem));

    public static bool FilterListAux(int n)
    {
        if (n >= 5)
            return true;
        else
            return false;
    }
    /*
     * Ecrire une fonction InverserPile(Stack<int> pile), qui prend en entrée une pile d'entiers
     * et qui retourne une nouvelle pile contenant les éléments de la pile d'origine dans l'ordre inverse.
     * La fonction doit utiliser une file pour inverser la pile.Queue<char> ou List<int>
     */
    public static Stack<int> InverserPile(Stack<int> pile)
    {
        var file = new Queue<int>();
        while (pile.Count > 0)
            file.Enqueue(pile.Pop());
        return new Stack<int>(file.ToArray());
    }

    /*
     * Ecrire une fonction SelectionnerPairs(List<int> liste), qui prend en entrée une liste d'entiers
     * et qui retourne une nouvelle liste contenant tous les nombres pairs de la liste d'origine,
     * triés par ordre croissant. La fonction doit utiliser la syntaxe de requête Linq.
     */
    public static List<int> SelectionnerPairs(List<int> liste) => new List<int>(liste.Where(elem => elem % 2 == 0).OrderDescending());
}