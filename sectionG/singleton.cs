using System;
namespace SingletonExample{
    sealed class Singleton{
        private static int count = 0;
        private static Singleton instance = null;
        private Singleton(){
            count++;
            Console.WriteLine(count);
        }
        public static Singleton GetInstance{
            get{
                if (instance == null) instance = new Singleton();
                return instance;
            }
        }
        public void Print(string message){
            Console.WriteLine(message);
        }
    }
    class program{
        public static void Main(string[] args){ 
            Singleton first = Singleton.GetInstance;
            first.Print("first singleton");
            Singleton second = Singleton.GetInstance;
            second.Print("second singleton");
        }
    }
}
