using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmer_projektuge_NET10
{
    //IEnumerable bruges til at iterere gennem elementer med foreach
    public class GenericList<T> : IEnumerable<T> //<T> er en placeholder til hvilken som helst type, som først er definieret fra variabler
        where T : IComparable<T> //Så man kan bruge CompareTo med T
    {
        public T[] items; //Intern array, med brug af resize
        public int count; //Hvor mange elementer der er tilføjet

        public GenericList() //Constructor
        {
            items = new T[4]; //Start capacitet med 4
            count = 0; //En tælling med hvor mange tilføjede elementer der er
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
        private void Resize() //Funktion til at bygge videre på array, hvor der skabes nye tomme slots
        {
            T[] temp = new T[items.Length * 2]; //Længde fordobles
            Array.Copy(items, temp, items.Length); //Kopiering af elementer (source, destination, length)
            items = temp; //Laver den til en ny array
        }
        public void Add(T element) //Tilføj element til liste
        {
            if (count == items.Length) Resize(); //Hvis antal elementer er lige med størrelse af array, resize

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
        public int CountAll() { return count; } //Kan også bruges list.count


        //Bubble Sort

        //Bruges CompareTo metode med IComparable<T>

        //CompareTo:
        //hvis element1.CompareTo(element2) < 0 (element1 er mindre end element2)
        //hvis element1.CompareTo(element2) == 0 (element1 er identisk med element2)
        //hvis element1.CompareTo(element2) > 0 (element1 er større end element2)

        public void BubbleSort()
        {
            bool swapped; //Null
            do
            {
                swapped = false;

                for (int i = 1; i < this.count; i++)
                {
                    if (this[i - 1].CompareTo(this[i]) > 0) //hvis element1 er større end element2
                    {
                        (this[i - 1], this[i]) = (this[i], this[i - 1]); //(a,b) = (b,a)
                        swapped = true; //Hvis der sker en swap, ville den sættes til true
                    }
                }

            } while (swapped); //Loopen vil kun stoppe, hvis swapped ikke var sat til true (ingen swap)
        }

        //Insertion Sort

        public void InsertionSort()
        {
            T val; //element vi vil indsætte
            int pointer; //Hvor val skal placeres

            for (int i = 1; i < this.count; i++) //vælg den næste element som starter ande element (første er allerede sorteret)
            {
                val = this[i]; //element vi vil indsætte
                pointer = i; //nummer af element

                //Imens val er mindre end det element før
                while (pointer > 0 && val.CompareTo(this[pointer - 1]) < 0) //samme som val < array[pointer-1]
                {
                    this[pointer] = this[pointer - 1]; //flytter den til venstre
                    pointer--;
                }
                this[pointer] = val; //rigtig position
            }
        }

    }
}
