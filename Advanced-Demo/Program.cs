using System.Diagnostics.CodeAnalysis;

namespace Advanced_Demo
{
    internal class Program
    {

        class StringEqulityComparer : IEqualityComparer<string>
        {
            public bool Equals(string? x, string? y)
            {
               
                return x?.ToLower().Equals(y?.ToLower()) ??y is null ? true:false;
            }
             
            public int GetHashCode([DisallowNull] string obj)
            {
                //Have to apply To lower 
                return obj?.ToLower().GetHashCode() ?? 0;
            }
        }
        static void Main(string[] args)
        {
            #region (Dictionary)
            // its a Generic Hash table  
            // its made of (key / value / pairs)
            // keys must be unique => GetHashCode

            //Dictionary<string, int> Note = new Dictionary<string, int>(new StringEqulityComparer())
            //{
            //    {"Yousef",34 },
            //    {"Ahmed",51 },
            //    {"Yacine" ,22 }
            //};
            //Note.Remove("Ahmed");
            //OR
            //Note.Remove("Ahmed", out int value);
            //Note.Add("Ashraf", 33);

            //here will be an error because the string equality comparer is implemented
            //Note.Add("yousef", 34);
            //if (!Note.ContainsKey("Ashraf"))
            //Note.Add("Ashraf", 33);
            //else
            //    Console.WriteLine("Ashraf is Already Found");

            //bool res = Note.TryAdd("Yousef",34);
            //Console.WriteLine(res);

            //Console.WriteLine(Note["Yousef"]);
            //if there is no key there will be an error 
            //Console.WriteLine(Note["YousefAhmed"]);

            //bool res = Note.TryGetValue("Yousef", out int value);
            //Console.WriteLine($"{res} , {value}");

            //foreach (var person in Note)
            //{
            //    Console.WriteLine($"Person Key: {person.Key} , Person value: {person.Value}");
            //}
            //foreach(var key in Note.Keys)
            //{
            //    Console.WriteLine(key);
            //}
            //foreach(var value in Note.Values)
            //{
            //    Console.WriteLine(value);
            //}

            //construcors for the dicionary 
            //KeyValuePair<string, int>[] keyValuePairs = new KeyValuePair<string, int>[]
            //{
            //    new KeyValuePair<string, int>("Yousef",34),
            //    new KeyValuePair<string, int>("Ahmed",24),
            //    new KeyValuePair<string, int>("Mohamed",14),


            //    }; 

            //Dictionary<string,int> Dic=new Dictionary<string,int>(keyValuePairs);
            //foreach (var item in Dic)
            //{
            //    Console.WriteLine(item.Value);
            //}


            #endregion

            #region HashSet
            //it uses the hash methods
            //use it when i want it to carry set of date but guarented the uniqueness of the data
            //it handels the repeated values of the data and doesnt add it 

            //HashSet<int> Numbers= new HashSet<int>();
            //Numbers.Add(1);
            //Numbers.Add(2);
            //Numbers.Add(3);
            ////Ignore it
            //Numbers.Add(3);
            //foreach (int i in Numbers)
            //{
            //    Console.WriteLine(i);
            //}

            HashSet<Movie> Movies = new HashSet<Movie>(new MovieEqualityComparer())
            {
                new Movie(1,"MovieX",100),
                new Movie(2,"MovieY",200),
                new Movie(3,"MovieZ",300)

            };
            //After added the Equal in the class this new movie will not be added and ignored
            //After used the MovieEqualityComparer it compare based on the id so when the other values changed didnt add it also 
            Movies.Add(new Movie(3, "MovieZz", 300));
            foreach (var movie in Movies) 
                Console.WriteLine(movie);

            
            #endregion

        }
    }
}
