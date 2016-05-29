using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BoolInterpreter.Model;

namespace BoolInterpreter.Tests
{
    public class RegExtInterpreterTests
    {
        public static void Run()
        {
            bool result;
            Context context;

            // (true and x)
            Console.WriteLine("Evaluating: (true and x) ...");
            VariableExp x = new VariableExp('X');

            BooleanExp expTrueAndX = new AndExp(new Constant(true), x);

            Console.WriteLine("Where x = true");
            context = new Context();
            context.Assign(x, true);

            result = expTrueAndX.Evaluate(context);
            Console.WriteLine("The answer should be 'True', and it evaluates as '{0}'\n", result);


            Console.WriteLine("Evaluating: (true and x) ...");
            Console.WriteLine("Where x = false");
            context = new Context();
            context.Assign(x, false);

            result = expTrueAndX.Evaluate(context);
            Console.WriteLine("The answer should be 'False', and it evaluates as '{0}'\n", result);
            
            
            // (not x)
            Console.WriteLine("Evaluating: (not x) ...");
            BooleanExp expNotX = new NotExp(x);

            Console.WriteLine("Where x = false");
            context = new Context();
            context.Assign(x, false);

            result = expNotX.Evaluate(context);
            Console.WriteLine("The answer should be 'True', and it evaluates as '{0}'\n", result);


            Console.WriteLine("Evaluating: (not x) ...");
            Console.WriteLine("Where x = true");
            context = new Context();
            context.Assign(x, true);

            result = expNotX.Evaluate(context);
            Console.WriteLine("The answer should be 'False', and it evaluates as '{0}'\n", result);


            // (y and (not x)
            Console.WriteLine("Evaluating: (y and (not x)) ...");
            VariableExp y = new VariableExp('Y');

            BooleanExp expYandNotX = new AndExp(y, new NotExp(x));

            Console.WriteLine("Where x = false, y = true.");
            context = new Context();
            context.Assign(x, false);
            context.Assign(y, true);

            result = expYandNotX.Evaluate(context);
            Console.WriteLine("The answer should be 'True', and it evaluates as '{0}'\n", result);


            // (true and x) or (y and (not x))
            Console.WriteLine("Evaluating: (true and x) or (y and (not x)) ...");
            BooleanExp expression = new OrExp(
                new AndExp(new Constant(true), x),
                new AndExp(y, new NotExp(x))
                );

            Console.WriteLine("Where x = false, y = true.");
            context = new Context();
            context.Assign(x, false);
            context.Assign(y, true);

            result = expression.Evaluate(context);
            Console.WriteLine("The answer should be 'True', and it evaluates as '{0}'\n", result);

            Console.WriteLine("Evaluating: (true and x) or (y and (not x)) ...");
            
            VariableExp z = new VariableExp('Z');
            NotExp notZ = new NotExp(z);

            Console.WriteLine("Where y is replaced with Not(z)");
            BooleanExp replacement = expression.Replace('Y', notZ);

            Console.WriteLine("Where x = false and z = true (making y = false)");
            context.Assign(z, true);
            result = replacement.Evaluate(context);
            Console.WriteLine("The answer should be 'False', and it evaluates as '{0}'\n", result);

            Console.WriteLine("Testing parser ...");
            Parser parser = new Parser();
            string input = "";

            input = "(true and x) or (y and (not x)) where x = false, y = true";
            Console.WriteLine("Calculating: " + input);
            result = parser.ParseBlocks(input);
            Console.WriteLine("The answer should be 'True', and it evaluates as '{0}'\n", result);

            input = "(true and x) or (y and (not x)) where x = false, y = false";
            Console.WriteLine("Calculating: " + input);
            result = parser.ParseBlocks(input);
            Console.WriteLine("The answer should be 'False', and it evaluates as '{0}'\n", result);

            Console.WriteLine("User input test ...");
            string QUIT_CODE = "exit";
            Console.WriteLine("Enter '{0}' to stop.", QUIT_CODE);
            bool inSession = true;
            do
            {
                Console.Write("Define Operation: ");
                input = Console.ReadLine();
                if (input != QUIT_CODE)
                {
                    result = parser.ParseBlocks(input);
                    Console.WriteLine("Result is: '{0}'\n", result);
                }
                else
                {
                    inSession = false;
                }
            }
            while (inSession);
        }
    }
}
