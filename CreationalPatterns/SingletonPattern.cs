using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalPatterns
{
    public class Singleton
    {
        private static Singleton instance = new Singleton();    
        private Singleton() { }
        public static Singleton Instance
        {
            get 
            {
              if(instance==null)
                {
                    instance = new Singleton(); 
                }
              return instance;  
            }    
        }
        public void DoSomthing()
        {
            Console.WriteLine("Singleton Pattern");
            Console.ReadLine(); 
        }
    }
}
