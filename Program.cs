using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complex
{   
    //myDouble value type
    public struct myDouble
    {
        public double num;

        public myDouble(double value = 0.0)
        {
            num = value;
        }
        //Addition operation for myDouble(returns new myDouble wich num is equal to op1.num+op2.num)
        public static myDouble operator + (myDouble op1, myDouble op2)
        {
            return new myDouble(op1.num + op2.num);
        }
        
        //Subtraction operation for myDouble(returns new myDouble wich num is equal to op1.num-op2.num)
        public static myDouble operator - (myDouble op1, myDouble op2)
        {
            return new myDouble(op1.num - op2.num);
        }

        //Multiplication operation for myDouble(returns new myDouble wich num is equal to op1.num*op2.num)
        public static myDouble operator * (myDouble op1, myDouble op2)
        {
            return new myDouble(op1.num * op2.num);
        }

        //Division operation for myDouble(returns new myDouble wich num is equal to op1.num/op2.num if op2.num isn't equal to 0)
        public static myDouble operator / (myDouble op1, myDouble op2)
        {
            if (op2.num == 0) 
            {
                Console.WriteLine("You can't divide by zero.");
                throw new System.DivideByZeroException();
            }
            else
            return new myDouble(op1.num / op2.num);
            
        }

        //set method for myDouble(sets new value for this.num)
        public void set(double value)
        {
            this.num = value;
        }

        //get method for myDouble(gets the value of this.num)
        public double get()
        {
            return(this.num);
        }

        //print method for myDouble(prints the value of this.num)
        public void print()
        {
            Console.WriteLine(this.num);
        }        
        //sqrt method for myDouble(returns the square root of this.num)
        public double sqrt()
        {
            return Math.Sqrt(this.num);
        }

        //atan method for myDouble(returns the arctangens of this.num)
        public double atan()
        {
            return Math.Atan(this.num);
        }

        //Equal operation for myDouble(return true if op1.num and op2.num are equal , otherwise false)
        public static bool operator == (myDouble op1, myDouble op2)
        {
            return (op1.num == op2.num) ? true : false;
        }

        //Inequal operation for myDouble(return true if op1.num isn't equal to op2.num, otherwise false)
        public static bool operator != (myDouble op1, myDouble op2)
        {
            return (op1.num != op2.num) ?  true : false;
        }

        //Less operation for myDouble(returns true if op1.num is less than op.num, otherwise false)
        public static bool operator < (myDouble op1, myDouble op2)
        {
            return (op1.num < op2.num) ? true : false; 
        }

        //Greater operation for myDouble(returns true if op1.num is greater than op.num, otherwise false)
        public static bool operator > (myDouble op1, myDouble op2)
        {
           return (op1.num > op2.num) ? true : false;
        }
          
        //Less or equal operation for myDouble(return true if op1.num is greater or equal than op2.num, otherwise false)
        public static bool operator <= (myDouble op1, myDouble op2)
        {
            return (op1.num <= op2.num) ? true : false;
        }

        //Greater or equal operation for myDouble(return true if op1.num is greater or equal than op2.num, otherwise false)
        public static bool operator >= (myDouble op1, myDouble op2)
        {
            return (op1.num >= op2.num) ? true : false;
        }

    }

    sealed class Complex
    {
        private myDouble re;
        private myDouble im;

        public Complex(myDouble _re, myDouble _im)
        {
            re = _re;
            im = _im;
        }

        //Addition operation for Complex(sums the real and imaginary parts separately and returns the sum as new Complex)
        public static  Complex operator + (Complex op1, Complex op2)
        {
            return new Complex(op1.re + op2.re, op1.im + op2.im);
        }

        //Subtraction operation for Complex(removes op2's real and imaginary parts  from op1 separately and returns the difference as new Complex)
        public static Complex operator - (Complex op1, Complex op2)
        {
            return new Complex(op1.re - op2.re, op1.im - op2.im);
        }

        // Multiplication operator for Complex(multiplies op1 and op2 with the formula described below and returns as new Complex)
        //   (a+b*i)*(c+d*i)=a*c-b*d+(a*d+b*c)i) 
        public static Complex operator * (Complex op1, Complex op2)
        {
            return new Complex(op1.re * op2.re - op1.im * op2.im, op1.re * op2.im + op1.im * op2.re);
        }

        // Division operator for Complex(divides op1 to op2 with the formula described below and returns as new Complex)
        //   (a+b*i)/(c+d*i) = ((a+b*i)(c-d*i))/((c+d*i)(c-d*i)) = ((a*c + b*d)/(c*c +d*d)) + ((b*c-a*d)/(c*c+d*d)i) 
        public static Complex operator / (Complex op1, Complex op2)
        {
            myDouble a = new myDouble(0.0);
            if(op2.re == a && op2.im == a)
            {
                  Console.WriteLine("You can't divide by zero.");
                throw new System.DivideByZeroException();
                
            }
            else
               return new Complex((op1.re * op2.re + op1.im * op2.im) / (op2.re * op2.re + op2.im * op2.im),
               (op1.im * op2.re - op1.re * op2.im) / (op2.re * op2.re + op2.im * op2.im));
        }

        //Absolute value of a complex number
        public double Abs()
        {
            return (re * re + im * im).sqrt();
        }
        
        //Argument of a complex number
        public double Arg()
        {
            myDouble a = new myDouble(0.0);
            if(re > a)
            {
                return (im / re).atan();
            }
            else if(re < a && im >= a)
            {
                return (im / re).atan() + Math.PI;
            }
            else if(re < a && im < a)
            {
                return (im / re).atan() - Math.PI;
            }
            else if(re == a && im > a)
            {
                return Math.PI / 2;
            }
            else if (re == a && im < a)
            {
                return - Math.PI / 2;
            }
            else
            {
                Console.WriteLine("An indeterminate value.");
                throw new System.Exception();
            }
        }

        //Prints the complex number in the form of real part and imaginary part
        public void printParts()
        {
          Console.WriteLine("Real Part: {0:R}", re.num,"\n");
          Console.WriteLine("Imaginary Part: {0:R}", im.num,"\n");
        }

        //Prints the complex number in the form of a+bi
        public void printFull()
        {
            myDouble a = new myDouble(0.0);
            if (im < a)
            {
                Console.WriteLine("{0:R}+{1:R}i", re.num, -im.num,"\n");
            }
            else if (im == a)
            {
                Console.WriteLine("{0:R}", re.num);
            }
            else
            {
                Console.WriteLine("{0:R}-{1:R}i", re.num, im.num,"\n");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
          myDouble a = new myDouble(2.5);
          myDouble b = new myDouble(-5.5);
          myDouble c = new myDouble(-6.0);
          myDouble d = new myDouble(3.0);

          Complex example1 = new Complex(a, b);
          Complex example2 = new Complex(c, d);
          (example1 + example2).printFull();
          (example1 + example2).printParts();
          (example1 - example2).printFull();
          (example1 - example2).printParts();
          (example1 * example2).printFull();
          (example1 * example2).printParts();
          (example1 / example2).printFull();
          (example1 / example2).printParts();
          Console.WriteLine("{0:R}",example1.Abs(),"\n");
          Console.WriteLine("{0:R}",example1.Arg(),"\n");
          Console.WriteLine("{0:R}",example2.Abs(),"\n");
          Console.WriteLine("{0:R}",example2.Arg(),"\n");
        }
    }

}
