using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MPT.Parsers.Model;

namespace BoolInterpreter.Model
{
    public class Parser
    {
        // Parsing instructions
        private const char OPEN_TAG = '(';
        private const char CLOSE_TAG = ')';
        private const char DELIMITER = ' ';

        // Assignment instructions
        private const string ASSIGNMENT_TRIGGER = "where";
        private const char ASSIGNMENT_OPERATOR = '=';

        // Special operands
        private const string TRUE = "true";
        private const string FALSE = "false";
        
        // Operators
        private const string AND = "and";
        private const string OR = "or";
        private const string NOT = "not";

        private List<string> _operators = new List<string>();
        private List<string> _operatorsWithSingularOperand = new List<string>();
        public Parser()
        {

            // Add all operators to classification lists
            _operators.Add(AND);
            _operators.Add(OR);
            _operators.Add(NOT);

            _operatorsWithSingularOperand.Add(NOT);
        }

        public bool ParseBlocks(string input)
        {
            //  [expression] opt ended by ";"
            //  (block)
            //      [(block) operator (block)]
            //      [(var op var) operator (var op (block))]
            //      [(var op var) operator (var op (op var))]
            // var & op delimited by ' ' :
            //      [(str str str) str (str str (str str))]
            // op is determined by:
            //      1. Outside of any block
            //      2. Item 1 if two items
            //      3. Even # items if odd # items total
            //      4. Error if even # items > 2
            // var is determined by:
            //      Remainders in the lists

            // Parse text into useable form
            IBlockParser parser = new BlockCharParser(OPEN_TAG, CLOSE_TAG, DELIMITER);
            Block expression;
            if (parser.ValidateBalancedTags(input))
            {
                expression = new Block(input, parser);
                Console.WriteLine(expression);
            }
            else
            {
                Console.WriteLine(parser.Log);
                return false;
            }

            // Create operations
            BooleanExp operation = ParseOperators(expression);


            // Create assignment context.
            Dictionary<string, string> allAssignments = GetVariablesText(input, ASSIGNMENT_TRIGGER, ASSIGNMENT_OPERATOR);
            Dictionary<VariableExp, bool> validAssignments = ConvertVariableAssignment(allAssignments);

            Context context = new Context();
            context = AssignVariables(validAssignments, context);

            // Perform calculation
            return operation.Evaluate(context);
        }


        private BooleanExp ParseOperators(Block expression)
        {
            // Get list of blocks as strings
            List<string> blocks = new List<string>();
            foreach (Block block in expression.ChildBlocks)
            {
                blocks.Add(OPEN_TAG + block.ToString() + CLOSE_TAG);
            }

            BooleanExp operand1 = null;
            BooleanExp operand2 = null;
            string operatorItem = null;
            int j = 0;
            for (int i = 0; i < expression.ChildText.Count; i++)
            {
                string item = expression.ChildText[i];
                if (item == ASSIGNMENT_TRIGGER) { break; }

                if (blocks.Count > j && item == blocks[j])
                {
                    if (IsFirstOperand(operand1))
                    {
                        operand1 = ParseOperators(expression.ChildBlocks[j]);
                    }
                    else
                    {
                        operand2 = ParseOperators(expression.ChildBlocks[j]);
                    }
                    j++;
                }
                else if (IsOperator(item))
                {
                    if (!string.IsNullOrEmpty(operatorItem))
                    {
                        throw new InvalidOperationException("Two operators cannot follow each other. Each operator must be separated by an operand. \n" + 
                                                            "Operator '" + operatorItem + "' at item index " + i);
                    }
                    operatorItem = item;
                }
                else
                {
                    if (IsFirstOperand(operand1))
                    {
                        operand1 = ConvertOperand(item);
                    }
                    else
                    {
                        operand2 = ConvertOperand(item);
                    }         
                }

                // Assign and reset values if sub-operation is complete
                if (IsSubOperationComplete(operatorItem, operand1, operand2))
                {
                    operand1 = GetOperator(operatorItem, operand1, operand2);
                    operatorItem = null;
                    operand2 = null;
                }
            }
            return operand1;
        }

        private bool IsSubOperationComplete(string operatorItem, BooleanExp operand1, BooleanExp operand2)
        {
            if (IsOperatorWithSingularOperand(operatorItem) && operand1 != null)
            {
                return true;
            }
            else if (!string.IsNullOrEmpty(operatorItem) && 
                    operand1 != null && 
                    operand2 != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        private bool IsOperatorWithSingularOperand(string operatorItem)
        {
            foreach (string item in _operatorsWithSingularOperand)
            {
                if (item == operatorItem) { return true; }
            }
            return false;
        }

        private BooleanExp ConvertOperand(string operand)
        {
            if ((operand.ToLower() == TRUE) || (operand.ToLower() == FALSE))
            {
               return new Constant(operand.ToLower() == TRUE);
            }
            else if (operand.Length == 1)
            {
                return new VariableExp(operand[0]);
            }
            else
            {
                return null;
            }
        }

        private bool IsFirstOperand(BooleanExp operand1)
        {
            return (operand1 == null);
        }

        private bool IsOperator(string text)
        {
            foreach (string operatorItem in _operators)
            {
                if (text == operatorItem) { return true; }
            }
            return false;
        }

        

        /// <summary>
        /// Converts the string variable to a boolean expression variable.
        /// Only accepts boolean strings or single-character variables.
        /// </summary>
        /// <param name="variable"></param>
        /// <returns></returns>
        private BooleanExp ConvertVariable(string variable)
        {
            if ((variable.ToLower() == TRUE) || (variable.ToLower() == FALSE))
            {
                return new Constant((variable.ToLower() == TRUE));
            }
            else if (variable.Length == 1)
            {
                return new VariableExp(variable[0]);
            }
            return null;
        }

        /// <summary>
        /// Returns the boolean operator with the appropriate variable assignments.
        /// </summary>
        /// <param name="boolOperator"></param>
        /// <param name="operand1"></param>
        /// <param name="operand2"></param>
        /// <returns></returns>
        private BooleanExp GetOperator(string boolOperator, BooleanExp operand1, BooleanExp operand2 = null)
        {
            switch (boolOperator)
            {
                case AND:
                    return new AndExp(operand1, operand2);
                case NOT:
                    return new NotExp(operand1);
                case OR:
                    return new OrExp(operand1, operand2);
                default:
                    throw new InvalidOperationException("Boolean comparison operator is invalid: " + boolOperator);
            }
        }

        /// <summary>
        /// Assigns the variable-value pairs to the context object.
        /// </summary>
        /// <param name="variablesAssignments"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        private Context AssignVariables(Dictionary<VariableExp, bool> variablesAssignments, Context context)
        {
            foreach (VariableExp variable in variablesAssignments.Keys)
            {
                context.Assign(variable, variablesAssignments[variable]);
            }
            return context;
        }

        /// <summary>
        /// Converts the valid variable assignments to boolean expressions and boolean values.
        /// </summary>
        /// <param name="assignments">Variable-value pairs.</param>
        /// <returns></returns>
        private Dictionary<VariableExp, bool> ConvertVariableAssignment(Dictionary<string, string> assignments)
        {
            Dictionary<VariableExp, bool> convertedAssignments = new Dictionary<VariableExp, bool>();
            foreach (string variable in assignments.Keys)
            {
                // Only single character variables are being used.
                if (variable.Length == 1)
                {
                    // Only values that correspond to booleans are being used
                    string value = assignments[variable];
                    if ((value.ToLower() == TRUE) || (value.ToLower() == FALSE))
                    {
                        convertedAssignments = ConvertVariableAssignment(variable[0], value, convertedAssignments);
                    }
                }
            }
            return convertedAssignments;
        }

        /// <summary>
        /// Adds the converted variable and value to the assignments dictionary.
        /// </summary>
        /// <param name="variable">Single-character variable.</param>
        /// <param name="boolValue">Value that matches the string form of a boolean.</param>
        /// <param name="convertedAssignments">List to add the converted variable-value pair to.</param>
        /// <returns></returns>
        private Dictionary<VariableExp, bool> ConvertVariableAssignment(char variable, string boolValue, Dictionary<VariableExp, bool> convertedAssignments)
        {
            bool convertedValue = (boolValue.ToLower() == TRUE);
            VariableExp x = new VariableExp(variable);
            convertedAssignments.Add(x, convertedValue);

            return convertedAssignments;
        }


        /// <summary>
        /// Returns a dictionary of variable-assignment pairs from the provided input.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="assignmentTrigger">String that denotes the beginning of a set of variable assignments.</param>
        /// <param name="assignmentOperator">Assignment operator character triggering an assignment.</param>
        /// <returns></returns>
        private Dictionary<string, string> GetVariablesText(string input, 
                                                            string assignmentTrigger, 
                                                            char assignmentOperator)
        {
            IList<string> variables = input.Split(new[] { assignmentTrigger }, StringSplitOptions.None);
            if (variables.Count > 1)
            {
                return ParseVariables(variables[1], assignmentOperator);
            }
            return new Dictionary<string, string>();
        }

        /// <summary>
        /// Returns a dictionary of variable-assignment pairs from the provided assignment input.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="assignmentOperator">Assignment operator character triggering an assignment.</param>
        /// <returns></returns>
        private Dictionary<string, string> ParseVariables(string input, char assignmentOperator)
        {
            input = input.Trim();
            Dictionary<string, string> variableAssignments = new Dictionary<string, string>();

            // Note: Stops one character short to avoid being triggered by '=' as the last character, since no assignment can follow.
            for (int i = 0; i < input.Length - 1; i++)
            {
                char c = input[i];
                if (c == assignmentOperator)
                {
                    string variable = GetVariable(input, i);
                    string value = GetValue(input, i);
                    
                    if (!string.IsNullOrEmpty(variable) && 
                        !string.IsNullOrEmpty(value))
                    {
                        variableAssignments.Add(variable, value);
                    }
                }
            }
            return variableAssignments;
        }

        /// <summary>
        ///  Searches left from the assignment operator and records the first contiguous string found.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="i">Index of the assignment operator within the provided input.</param>
        /// <returns></returns>
        private string GetVariable(string input, int i)
        {
            string variable = "";
            bool varFound = false;
            for (int j = i - 1; j >= 0; j--)
            {
                char cLeft = input[j];
                if (cLeft != ' ')
                {
                    varFound = true;
                    variable += cLeft;
                }
                else if (varFound)
                {
                    break;
                }
            }
            return variable;
        }

        /// <summary>
        /// Searches right from the assignment operator and records the first contiguous string found.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="i">Index of the assignment operator within the provided input.</param>
        /// <returns></returns>
        private string GetValue(string input, int i)
        {
            string value = "";
            bool valueFound = false;
            for (int j = i + 1; j < input.Length; j++)
            {
                char cRight = input[j];
                if (cRight != ' ' &&
                    cRight != ',' &&
                    cRight != ';')
                {
                    valueFound = true;
                    value += cRight;
                }
                else if (valueFound)
                {
                    break;
                }
            }
            return value;
        }


    }

}

