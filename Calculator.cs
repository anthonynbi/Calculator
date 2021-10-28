using System;
using System.Collections.Generic;

namespace code
{
    class Calculator
    {
        static void Main()
    {

        List<String> history = new List<String>();
        System.Console.WriteLine("enter name: ");
        String name = Console.ReadLine();

        while(true){
            System.Console.WriteLine("input first number: ");
            String x_str = Console.ReadLine();
            double x;
            try
            {
                x = Convert.ToDouble(x_str);
            }
            catch
            {
                System.Console.WriteLine("must be a valid number");
                continue;
            }
            
            System.Console.WriteLine("input second number: ");
            String y_str = Console.ReadLine();
            double y;
            try
            {
                y = Convert.ToDouble(y_str);
            }
            catch
            {
                System.Console.WriteLine("must be a valid number");
                continue;
            }
            
            System.Console.WriteLine("input operator: ");
            String op_str = Console.ReadLine();
            char op = op_str[0];

            double result;
            try
            {
                result = calc(op, x ,y);
            }
            catch(ArithmeticException e)
            {
                Console.WriteLine("do not divid by zero!");
                continue;
            }
            catch(ArgumentException e)
            {
                Console.WriteLine("must be a valid operator (+, -, *, /)");
                continue;
            }
            
            history.Add(x+" "+op+" "+y+" = "+result);
            System.Console.WriteLine("{0} {1} {2} = {3}", x, op, y, result);

            System.Console.WriteLine("write h to view history, anything else to continue");
            String h = Console.ReadLine();
            if( h.Equals("h") )
            {
                PrintHistory(history);
                Console.WriteLine("press any key to continue");
                String any_str = Console.ReadLine();
            }
        }

        
    }

    static double calc(char op, double cx, double cy)
    {
        switch(op)
        {
            case '+': return cx+cy;
            case '-': return cx-cy;
            case '*': return cx*cy;
            case '/': 
                        if(cy == 0){ throw new ArithmeticException("dividing by zero"); }
                        return cx/cy;
            default: throw new ArgumentException("not a valid operator");
        }
    }

    static void PrintHistory(List<String> hist)
    {
        for(int i = 0; i < hist.Count; i++)
        {
            Console.WriteLine(hist[i]);
        }
    }
    
    }
}