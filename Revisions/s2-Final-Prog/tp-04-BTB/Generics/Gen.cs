namespace Generics;

public class Element<T>
{
    public T Content;

    public Element<T>? Next;
    /*
 * Écrire une classe Element utilisant un Generic <T> ayant deux attributs public:
 * - T Content
 * - Element<T>? Next
 * Son constructeur prend un content de type T et initialize Next à null.
 */

    public Element(T content)
    {
        Content = content;
        Next = null;
    }
}

public class List<T>
{
    /*
 * Écrire une classe List utilisant un Generic <T> ayant un attribut privé:
 * - Element<T>? _head
 * Son constructeur crée un nouvel _head avec l'élément donné en paramètre.
 */
    private Element<T>? _head;

    public List()
    {
        
    }

    public List(T element)
    {
        _head = new Element<T>(element);
    }
    
    /*
 * Écrire une fonction Add qui ajoute le T element donné à la fin de la liste chaîné de _head.
 * Si head n'existe pas, element devient la nouvelle head de la liste;
 */

    public void Add(T element)
    {
        if (_head is null)
        {
            _head = new Element<T>(element);
        }
        else
        {
            var n = _head;
            while (n.Next is not null)
            {
                n = n.Next;
            }
            n.Next = new Element<T>(element);
        }
    }

/*
 * Écrire un indexeur qui permet d'accéder ou set le content de l'élement d'index donné.
 * Une IndexOutOfRangeException est throw si l'index est invalide
 *
 * Hint: Une fonction auxiliaire renvoyant l'élément d'index donné peut être utile.
 */

    public T this[int index]
    {
        get
        {
            if (_head is null)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                var n = _head;
                int i = 0;
                while (n.Next is not null && i != index)
                {
                    n = n.Next;
                    i += 1;
                }

                if (i == index)
                {
                    return n.Content;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }
        set
        {
            if (value == null) throw new ArgumentNullException(nameof(value));
            if (_head is null)
            {
                _head = new Element<T>(value);
            }
            else
            {
                var n = _head;
                int i = 0;
                while (n.Next is not null && i != index-1)
                {
                    n = n.Next;
                }

                if (i == index)
                {
                    n.Next = new Element<T>(value);
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }
    }

/*
 * Écrire une fonction Pop qui supprime et renvoie l'élement à l'index donné.
 * Si l'index est invalide, une InvalidIndexException est renvoyée.
 */
    public T Pop(int index = 0)
    {
        if (index <= 0)
        {
            throw new InvalidIndexException();
        }
        else
        {
            if (_head is not null)
            {
                Element<T> n = _head;
                int i = 0;
                while (n.Next is not null && i != index-1)
                {
                    n = n.Next;
                    i += 1;
                }
                if (i == index)
                {
                    var actual = n.Next;
                    if (actual is null)
                    {
                        throw new InvalidIndexException();
                    }
                    else
                    {
                        if (actual.Next is null)
                        {
                            n.Next = null;
                            return actual.Content;
                        }
                        else
                        {
                            n.Next = actual.Next;
                            return actual.Content;
                        }
                    } 
                }
                throw new InvalidIndexException();
            }
            throw new InvalidIndexException();
        }
    }
    
}