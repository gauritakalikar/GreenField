using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDesignPatternApp
{

    public class Complex :IClonable


    {

        public int real;
        public int imaginary;
        public Complex()
        {
            real=imaginary=0;
        }
        public Complex(int real, int imaginary)
        {
            this.real = real;
            this.imaginary = imaginary;
        }
        public object clone()
        {
            Complex temp = new Complex();
            temp.real = real;
            temp.imaginary = imaginary; 
            return temp;
        }
    
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //OfficeBoy waiter = OfficeBoy.Create();
            //OfficeBoy admin = OfficeBoy.Create();
            //OfficeBoy supervisor = OfficeBoy.Create();
            Complex c1=new Complex(1, 2);
            Complex c2 = (Complex)c1.clone();
            Console.WriteLine(c1.real +" "+ c1.imaginary);
            Console.WriteLine(c2.real+" "+c2.imaginary);
        }
    }
}
