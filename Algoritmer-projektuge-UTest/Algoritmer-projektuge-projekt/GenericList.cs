using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmer_projektuge_projekt
{
    //IEnumerable bruges til at iterere gennem elementer med foreach
    public class GenericList<T> : IEnumerable<T> //<T> er en placeholder til hvilken som helst type, som først er definieret fra variabler
    {
        public T[] items; //Intern array, med brug af resize
        public int count;

        public GenericList() //Constructor
        {
            items = new T[4]; //Start capacitet med 4
            count = 0;
        }

        public IEnumerator<T> GetEnumerator() //Denne førger for at foreach virker
        {
            for (int i = 0; i < count; i++)
            {
                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() //Kontrakten for iterering
        {
            return GetEnumerator();
        }

        //Tiløj et element (generic)
        private void Resize() //Funktion til at bygge videre på array, hvor der skabes tomme slots
        {
            T[] temp = new T[items.Length * 2]; //Længde fordobles
            Array.Copy(items, temp, items.Length); //Kopiering af elementer (source, destination, length)
            items = temp; //Laver den til en ny array
        }
        public void Add(T element) //Tilføj element til liste
        {
            if (count == items.Length) Resize(); //Hvis slots er lige mange med længden, resize

            items[count] = element; //Tilføj element til den første ledige slot
            count++;
        }

        //Referer et element via indeks (generic)
        public T this[int index]
        {
            get //Finder information
            {
                if (index < 0 || index >= count) throw new IndexOutOfRangeException(); //Hvis indeks er højere eller minus, viser konsollen fejl
                return items[index];
            }
            set //Erstatter nuværender indeks med en ny
            {
                if (index < 0 || index >= count) throw new IndexOutOfRangeException(); //Hvis indeks er højere eller minus, viser konsollen fejl
                items[index] = value;
            }
        }
        
        //Få antal elementer i listen
        public int CountAll() { return count; }
    }
}
