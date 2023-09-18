using System;
using System.Collections.Generic;

namespace QueueAndStack
{
    public class EvaluateReversePolishNotation
    {
        public int EvalRPN(string[] tokens)
        {
            HashSet<string> operators = new HashSet<string>()
            { "+","-","*","/",};

            Stack<int> numbers = new Stack<int>();
            foreach(string i in tokens)
            {
                if(operators.Contains(i))
                {
                    int secondNumber = numbers.Pop();
                    int firstNumber = numbers.Pop();

                    int answerNumber = 0;
                    switch(i)
                    {
                        case "+":
                            answerNumber = firstNumber + secondNumber;
                            break;
                        case "-":
                            answerNumber = firstNumber - secondNumber;
                            break;
                        case "*":
                            answerNumber = firstNumber * secondNumber;
                            break;
                        case "/":
                            answerNumber = firstNumber / secondNumber;
                            break;
                    }
                    numbers.Push(answerNumber);
                }
                else
                {
                    numbers.Push(Convert.ToInt32(i));
                }
            }

            return numbers.Pop();
        }

        
    }
}
