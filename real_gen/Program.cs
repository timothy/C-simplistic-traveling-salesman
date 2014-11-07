using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace real_gen
{

    public class City
    {
        public string Name { get; set; }//this is the name of the Washington cities
        // I changed both of these to an int because it does not make sense to be a string
        public int x { get; set; }//this is the x coordinate of the city's location on the map
        public int y { get; set; }//this is the y coordinate of the city's location on the map


        public override string ToString()
        {
            return String.Format("Name: {0} \n\nX: {1}\n\nY: {2}", Name, x, y);// this is how you format something that prints to the screen
        }
    }

    class Program
    {
        public static List<City> map = new List<City>()// Note this list starts at 0 but I labeled the cities 1 through 20
        {
            new City {Name="Seattle", x=10, y= 20}, //1               //0
            new City {Name="Spokane", x=30, y=20}, //2               //1
            new City {Name="Tacoma", x=40, y=30}, //3                //2
            new City {Name="Bellevue", x=70, y=40}, //4              //3
            new City {Name="Olympia", x=90, y=40}, //5               //4
            new City {Name="Everett", x=50, y=50}, //6               //5
            new City {Name="Redmaond", x=10, y=60}, //7              //6
            new City {Name="Yakima", x=30, y=60}, //8                //7
            new City {Name="Bellingham", x=50, y=60}, //9            //8
            new City {Name="Vancouver", x=80, y=60}, //10            //9
            new City {Name="Leavenworth", x=90, y=60}, //11          //10
            new City {Name="Issaquah", x=80, y=70}, //12             //11
            new City {Name="Puyallup", x=80, y=60}, //13             //12
            new City {Name="Forks", x=80, y=90}, //14                //13
            new City {Name="Bremerton", x=50, y=90}, //15            //14
            new City {Name="Renton", x=90, y=90}, //16               //15
            new City {Name="Kirkland", x=30, y=100},//17             //16
            new City {Name="Naches", x=10, y=100}, //18              //17
            new City {Name="Bothell", x=60, y=100}, //19             //18
            new City {Name="Wenatchee", x= 80, y=100}, //20           //19
        };

        // public static 

        static void Main(string[] args)
        {
            // I found that I had to use IList when I am referring to an object
            List<int> uniquRan = new List<int>();//this is where I store all of my unique random numbers
            List<int> best = new List<int>();
            int rand = 0;//this is for my unique random number generator
            bool first = true;
            int temp = 0;//this is for my unique random number generator
            int totaldistance = 0, newtotaldistance = 0;
            Random rnd = new Random();// this is random

            for (int o = 0; o < map.Count(); o++)
            {
                uniquRan.Add(o);// this gives me 20 #. numbers 0 through 19
            }


            for (int i = 0; i < 1000; i++)
            {
                totaldistance = 0;

                for (int q = 0; q < map.Count(); q++)// unique random is the parent and will be mutated every time
                {
                    rand = rnd.Next(map.Count());// this randomly generates 20 numbers. 0 though 19. it is possible for the same number to be generated twice

                    // this will scramble all of the numbers in uniquRan up in leaving then in a random order with no duplicate numbers
                    // this replaces the number in uniquRan[i] with a number in a random location
                    temp = uniquRan[rand];
                    uniquRan[rand] = uniquRan[q];
                    uniquRan[q] = temp;
                }

                for (int z = 0; z < map.Count() - 1; z++)
                {
                    totaldistance += Math.Abs(((map[uniquRan[z]].x + map[uniquRan[z]].y) - (map[uniquRan[z + 1]].x + map[uniquRan[z + 1]].y)));
                }

                if (newtotaldistance > totaldistance || newtotaldistance == 0)
                {
                    newtotaldistance = totaldistance;

                    Console.WriteLine("Distance = {0}", newtotaldistance);

                    if (first == true)
                    {
                        for (int c = 0; c < map.Count(); c++)
                        {
                            best.Add(uniquRan[c]);
                        }
                        first = false;
                    }
                    else
                    {
                        for (int d = 0; d < map.Count(); d++)
                        {
                            best[d] = uniquRan[d];
                        }
                    }
                }
            }

            Console.WriteLine("\nFinal Distance = {0}\n", newtotaldistance);
            Console.WriteLine("Bast Path Found:\n");
            for (int e = 0; e < map.Count; e++)
            {
                Console.WriteLine(map[best[e]].ToString());
            }

        }//Main
    }// class program
}// name space