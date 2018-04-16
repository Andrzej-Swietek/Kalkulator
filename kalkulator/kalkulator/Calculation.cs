using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace kalkulator
{
    class Calcualtion
    {
        string str;
        public int numberSystem = 10;
        Expression rootExpression;
        IDictionary<char, double> additionalSymbols; 

        public Calcualtion(string str)//konstruktor 
        {
            this.str = str;
            this.additionalSymbols = null;
        }
        public Calcualtion(string str, IDictionary<char, double> additionalSymbols)//konstruktor
        {
            this.str = str;
            this.additionalSymbols = additionalSymbols;
        }


        public double CalculateNew()
        {
            PrepareCalculation();
            double resoult = rootExpression.EvaluateChildren();
            return resoult;
        }
        public void PrepareCalculation()
        {
            rootExpression = new Expression();
            Stack<Expression> exprStack = new Stack<Expression>(); //stos w którym nawiasie lub expreszynie jestesmy
            exprStack.Push(rootExpression);
            ExpressionType lastExprType = ExpressionType.None;
            string textExpr = "";
            char c;

            for (int i = 0; i < str.Length;)
            {
                if (!(char.IsDigit(str[i]) || str[i] == ',' || str[i] == '.' || str[i] == ' '))
                {
                    c = str[i];
                    i++;
                    if (i == str.Length || !char.IsLetter(c) || (i < str.Length && !char.IsLetter(str[i]) /* (char.IsDigit(str[i]) || str[i] == ',' || str[i] == '.' || str[i] == ' ')*/))
                    {
                        if (string.IsNullOrEmpty(textExpr))
                        {
                            if (false) ;
                            else if (c == '+')
                            {
                                if (lastExprType != ExpressionType.Number && lastExprType != ExpressionType.BracketsExpr) throw new CalculationException("Format error!");//sprawdza czy byla liczba ostatnia anie nic lub znak
                                exprStack.Peek().children.AddLast(new Expression(1, true, true, (this_, left, right) => {
                                    left.toRemove = right.toRemove = true;//obu ustawiamy true bo ich uzywa
                                    return left.value.Value + right.value.Value;//linijka z dziaalaniem
                                }));
                                lastExprType = ExpressionType.Operation;//ostatnia wyraz to opercja
                            }
                            else if (c == '-')
                            {
                                if (lastExprType == ExpressionType.None)
                                {
                                    exprStack.Peek().children.AddLast(new Expression(5, false, true, (this_, left, right) => {
                                        right.toRemove = true;
                                        return -right.value.Value;
                                    }));
                                }
                                else if (lastExprType == ExpressionType.Number)
                                {
                                    exprStack.Peek().children.AddLast(new Expression(1, true, true, (this_, left, right) => {
                                        left.toRemove = right.toRemove = true;
                                        return left.value.Value - right.value.Value;
                                    }));
                                }
                                else throw new CalculationException("Format error!");
                                lastExprType = ExpressionType.Operation;
                            }
                            else if (c == '*')
                            {
                                if (lastExprType != ExpressionType.Number && lastExprType != ExpressionType.BracketsExpr) throw new CalculationException("Format error!");
                                exprStack.Peek().children.AddLast(new Expression(2, true, true, (this_, left, right) => {
                                    left.toRemove = right.toRemove = true;
                                    return left.value.Value * right.value.Value;
                                }));
                                lastExprType = ExpressionType.Operation;
                            }
                            else if (c == '/' || c == ':')
                            {
                                if (lastExprType != ExpressionType.Number && lastExprType != ExpressionType.BracketsExpr) throw new CalculationException("Format error!");
                                exprStack.Peek().children.AddLast(new Expression(2, true, true, (this_, left, right) => {
                                    if (right.value.Value == 0) throw new CalculationException("Pamietiętaj Cholero Nie Dziel Przez 0!");
                                    left.toRemove = right.toRemove = true;
                                    return left.value.Value / right.value.Value;
                                }));
                                lastExprType = ExpressionType.Operation;
                            }
                            else if (c == '^')
                            {
                                if (lastExprType != ExpressionType.Number && lastExprType != ExpressionType.BracketsExpr) throw new CalculationException("Format error!");
                                exprStack.Peek().children.AddLast(new Expression(3, true, true, (this_, left, right) => {
                                    if (left.value.Value == 0 && right.value.Value == 0) throw new CalculationException("Operation 0^0 is undefinited!");
                                    left.toRemove = right.toRemove = true;
                                    return Math.Pow(left.value.Value, right.value.Value);
                                }));
                                lastExprType = ExpressionType.Operation;
                            }
                            else if (c == '√')
                            {
                                if (lastExprType == ExpressionType.None) //jesli jedna liczba
                                {
                                    exprStack.Peek().children.AddLast(new Expression(3, false, true, (this_, left, right) =>
                                    {
                                        right.toRemove = true;//obu ustawiamy true bo ich uzywa
                                        if (right.value.Value < 0) throw new CalculationException("Pierwiastek kwadratowy z liczby ujemnej!");
                                        return Math.Sqrt(right.value.Value);//linijka z dziaalaniem  podajemy najpierw wykladnik a potem liczbe
                                    }));

                                }
                                else if (lastExprType == ExpressionType.Number)//jesli 2 liczby
                                {

                                    if (lastExprType == ExpressionType.Operation) throw new CalculationException("Format error!");//sprawdza czy byla liczba ostatnia anie nic lub znak
                                    exprStack.Peek().children.AddLast(new Expression(3, true, true, (this_, left, right) =>
                                    {
                                        left.toRemove = right.toRemove = true;//obu ustawiamy true bo ich uzywa
                                        return Math.Pow(right.value.Value, (1 / left.value.Value));//linijka z dziaalaniem  podajemy najpierw wykladnik a potem liczbe
                                    }));
                                }
                                else
                                {
                                    throw new CalculationException("FATAL ERROR 404");
                                }
                                lastExprType = ExpressionType.Operation;//ostatnia wyraz to opercja
                            }
                            else if (c == '!')
                            {

                                if (lastExprType != ExpressionType.Number && lastExprType != ExpressionType.BracketsExpr) throw new CalculationException("Format error!");//sprawdza czy byla liczba ostatnia anie nic lub znak
                                exprStack.Peek().children.AddLast(new Expression(3, true, false, (this_, left, right) => {
                                    left.toRemove = true;//obu ustawiamy true bo ich uzywa
                                    return Factorial(left.value.Value);
                                }));
                                lastExprType = ExpressionType.Operation;//ostatnia wyraz to opercja
                            }
                            else if (c == '(')
                            {
                                if (lastExprType != ExpressionType.None && lastExprType != ExpressionType.Number && lastExprType != ExpressionType.BracketsExpr
                                    && lastExprType != ExpressionType.Operation && lastExprType != ExpressionType.TextOperation) throw new CalculationException("Format error!");
                                Expression e = new Expression(10, false, false, (this_, left, right) => {
                                    return this_.EvaluateChildren();
                                });
                                exprStack.Peek().children.AddLast(e);
                                exprStack.Push(exprStack.Peek().children.Last.Value);
                                lastExprType = ExpressionType.None;
                            }
                            else if (c == ')')
                            {
                                if (lastExprType == ExpressionType.None || exprStack.Count == 1) throw new CalculationException("Brackets error!");
                                exprStack.Pop();
                                lastExprType = ExpressionType.BracketsExpr;
                            }
                            else if (c == 'π')
                            {
                                Expression e = new Expression(11, false, false, (this_, left, right) => Math.PI);
                                exprStack.Peek().children.AddLast(e);
                                lastExprType = ExpressionType.Number;
                            }
                            else if (c == 'e')
                            {
                                Expression e = new Expression(11, false, false, (left, right, this_) => Math.E);
                                exprStack.Peek().children.AddLast(e);
                                lastExprType = ExpressionType.Number;
                            }
                            else if (c == '%')
                            {
                                if (lastExprType != ExpressionType.Number && lastExprType != ExpressionType.BracketsExpr) throw new CalculationException("Format error!");//sprawdza czy byla liczba ostatnia anie nic lub znak
                                exprStack.Peek().children.AddLast(new Expression(1, true, false, (this_, left, right) => {
                                    left.toRemove = true;//obu ustawiamy true bo ich uzywa
                                    return left.value.Value/100;//linijka z dziaalaniem
                                }));
                                lastExprType = ExpressionType.Operation;//ostatnia wyraz to opercja
                            }
                            else
                            {
                                char cc = c;
                                Expression e = new Expression(11, false, false, (this_, left, right) =>
                                {                                    
                                    if (additionalSymbols != null && additionalSymbols.ContainsKey(cc))
                                    {
                                        return additionalSymbols[cc];
                                    }
                                    else throw new CalculationException("Symbol " + cc + " not known");
                                });
                                exprStack.Peek().children.AddLast(e);
                                lastExprType = ExpressionType.Number;
                            }
                        }
                        else
                        {
                            textExpr += c;
                            if (false) ;
                            else if (textExpr == "log")
                            {
                                if (lastExprType == ExpressionType.Number)
                                {
                                    exprStack.Peek().children.AddLast(new Expression(4, true, true, (this_, left, right) =>
                                    {
                                        double a = left.value.Value;
                                        double b = right.value.Value;
                                        if (!(a > 0 && a != 1.0 && b > 0)) //warunek profesor Ciborowskiej
                                        {
                                            throw new CalculationException("A założeń się nie uczymy???");
                                        }

                                        left.toRemove = right.toRemove = true;//obu ustawiamy true bo ich uzywa
                                        return Math.Log(b, a); //linijka z dzialaniem
                                    }));
                                }
                                else if (lastExprType == ExpressionType.None)
                                {
                                    exprStack.Peek().children.AddLast(new Expression(4, false, true, (this_, left, right) =>
                                    {
                                        double b = right.value.Value;
                                        if (!(b > 0)) //warunek profesor Ciborowskiej
                                        {
                                            throw new CalculationException("A założeń się nie uczymy???");
                                        }

                                        right.toRemove = true;//obu ustawiamy true bo ich uzywa
                                        return Math.Log10(b); //linijka z dzialaniem
                                    }));
                                }
                                else throw new CalculationException("Format error!");
                                lastExprType = ExpressionType.TextOperation;//ostatnia wyraz to opercja 
                            }
                            else if (textExpr == "mod")
                            {
                                if (lastExprType != ExpressionType.Number && lastExprType != ExpressionType.BracketsExpr) throw new CalculationException("Format error!");
                                exprStack.Peek().children.AddLast(new Expression(2, true, true, (this_, left, right) =>
                                {
                                    if (right.value.Value == 0) throw new CalculationException("Attemption to modulo by 0!");
                                    left.toRemove = right.toRemove = true;
                                    return left.value.Value % right.value.Value;
                                }));
                                lastExprType = ExpressionType.TextOperation;
                            }
                            else if (textExpr == "sin")
                            {
                                if (lastExprType != ExpressionType.None && lastExprType != ExpressionType.Number && lastExprType != ExpressionType.BracketsExpr
                                    && lastExprType != ExpressionType.Operation) throw new CalculationException("Format error!");
                                exprStack.Peek().children.AddLast(new Expression(4, false, true, (this_, left, right) =>
                                {
                                    right.toRemove = true;
                                    return (Math.Sin(right.value.Value * Math.PI / 180));
                                }));
                                lastExprType = ExpressionType.TextOperation;
                            }
                            else if (textExpr == "cos")
                            {
                                if (lastExprType != ExpressionType.None && lastExprType != ExpressionType.Number && lastExprType != ExpressionType.BracketsExpr
                                && lastExprType != ExpressionType.Operation) throw new CalculationException("Format error!");
                                exprStack.Peek().children.AddLast(new Expression(4, false, true, (this_, left, right) =>
                                {
                                    right.toRemove = true;
                                    return (Math.Cos(right.value.Value * Math.PI / 180));
                                }));
                                lastExprType = ExpressionType.TextOperation;
                            }
                            else if (textExpr == "tg")
                            {
                                if (lastExprType != ExpressionType.None && lastExprType != ExpressionType.Number && lastExprType != ExpressionType.BracketsExpr
                                && lastExprType != ExpressionType.Operation) throw new CalculationException("Format error!");
                                exprStack.Peek().children.AddLast(new Expression(4, false, true, (this_, left, right) =>
                                {
                                    right.toRemove = true;
                                    return (Math.Tan(right.value.Value * Math.PI / 180));
                                }));
                                lastExprType = ExpressionType.TextOperation;
                            }
                            else if (textExpr == "ctg")
                            {
                                if (lastExprType != ExpressionType.None && lastExprType != ExpressionType.Number && lastExprType != ExpressionType.BracketsExpr
                                && lastExprType != ExpressionType.Operation) throw new CalculationException("Format error!");
                                exprStack.Peek().children.AddLast(new Expression(4, false, true, (this_, left, right) =>
                                {
                                    right.toRemove = true;
                                    return 1 / (Math.Tan(right.value.Value * Math.PI / 180));
                                }));
                                lastExprType = ExpressionType.TextOperation;
                            }
                            else if (textExpr == "asin")
                            {
                                if (lastExprType != ExpressionType.None && lastExprType != ExpressionType.Number && lastExprType != ExpressionType.BracketsExpr
                            && lastExprType != ExpressionType.Operation) throw new CalculationException("Format error!");
                                exprStack.Peek().children.AddLast(new Expression(4, false, true, (this_, left, right) =>
                                {
                                    right.toRemove = true;
                                    return (Math.Asin(right.value.Value * Math.PI / 180));
                                }));
                                lastExprType = ExpressionType.TextOperation;
                            }
                            else if (textExpr == "acos")
                            {

                                if (lastExprType != ExpressionType.None && lastExprType != ExpressionType.Number && lastExprType != ExpressionType.BracketsExpr
                                && lastExprType != ExpressionType.Operation) throw new CalculationException("Format error!");
                                exprStack.Peek().children.AddLast(new Expression(4, false, true, (this_, left, right) =>
                                {
                                    right.toRemove = true;
                                    return (Math.Acos(right.value.Value * Math.PI / 180));
                                }));
                                lastExprType = ExpressionType.TextOperation;

                            }
                            else if (textExpr == "atg")
                            {
                                if (lastExprType != ExpressionType.None && lastExprType != ExpressionType.Number && lastExprType != ExpressionType.BracketsExpr
                                && lastExprType != ExpressionType.Operation) throw new CalculationException("Format error!");
                                exprStack.Peek().children.AddLast(new Expression(4, false, true, (this_, left, right) =>
                                {
                                    right.toRemove = true;
                                    return (Math.Atan(right.value.Value * Math.PI / 180));
                                }));
                                lastExprType = ExpressionType.TextOperation;
                            }
                            else if (textExpr == "inv")
                            {
                                if (lastExprType != ExpressionType.None && lastExprType != ExpressionType.Number && lastExprType != ExpressionType.BracketsExpr
                                    && lastExprType != ExpressionType.Operation) throw new CalculationException("Format error!");
                                exprStack.Peek().children.AddLast(new Expression(4, false, true, (this_, left, right) =>
                                {
                                    right.toRemove = true;
                                    return (1 / right.value.Value);
                                }));
                                lastExprType = ExpressionType.Operation;//ostatnia wyraz to opercja
                            }
                            else if (textExpr == "exp")
                            {
                                if (lastExprType != ExpressionType.None && lastExprType != ExpressionType.Number && lastExprType != ExpressionType.BracketsExpr
                              && lastExprType != ExpressionType.Operation) throw new CalculationException("Format error!");
                                exprStack.Peek().children.AddLast(new Expression(4, false, true, (this_, left, right) =>
                                {
                                    right.toRemove = true;
                                    return (Math.Exp(right.value.Value));
                                }));
                                lastExprType = ExpressionType.TextOperation;
                            }
                            else if (textExpr == "abs")
                            {
                                if (lastExprType != ExpressionType.None && lastExprType != ExpressionType.Number && lastExprType != ExpressionType.BracketsExpr
                              && lastExprType != ExpressionType.Operation) throw new CalculationException("Format error!");
                                exprStack.Peek().children.AddLast(new Expression(4, false, true, (this_, left, right) =>
                                {
                                    right.toRemove = true;
                                    return Math.Abs(right.value.Value);
                                }));
                                lastExprType = ExpressionType.TextOperation;
                            }
                            else if (textExpr == "and")
                            {
                                if (lastExprType != ExpressionType.None && lastExprType != ExpressionType.Number && lastExprType != ExpressionType.BracketsExpr
                             && lastExprType != ExpressionType.Operation) throw new CalculationException("Format error!");
                                exprStack.Peek().children.AddLast(new Expression(4, true, true, (this_, left, right) =>
                                {
                                   left.toRemove = right.toRemove = true;
                                    return  Convert.ToInt32(left.value.Value) & Convert.ToInt32(right.value.Value);
                                }));
                                lastExprType = ExpressionType.TextOperation;
                            }
                            else if (textExpr == "or")
                            {
                                if (lastExprType != ExpressionType.None && lastExprType != ExpressionType.Number && lastExprType != ExpressionType.BracketsExpr
                            && lastExprType != ExpressionType.Operation) throw new CalculationException("Format error!");
                                exprStack.Peek().children.AddLast(new Expression(4, true, true, (this_, left, right) =>
                                {
                                    left.toRemove = right.toRemove = true;
                                    return Convert.ToInt32(left.value.Value) | Convert.ToInt32(right.value.Value);
                                }));
                                lastExprType = ExpressionType.TextOperation;
                            }
                            else if (textExpr == "xor")
                            {
                                if (lastExprType != ExpressionType.None && lastExprType != ExpressionType.Number && lastExprType != ExpressionType.BracketsExpr
                              && lastExprType != ExpressionType.Operation) throw new CalculationException("Format error!");
                                exprStack.Peek().children.AddLast(new Expression(4, true, true, (this_, left, right) =>
                                {
                                    left.toRemove = right.toRemove = true;
                                    return Convert.ToInt32(left.value.Value) ^ Convert.ToInt32(right.value.Value);
                                }));
                                lastExprType = ExpressionType.TextOperation;
                            }
                            else if (textExpr == "not")
                            {
                                if (lastExprType != ExpressionType.None && lastExprType != ExpressionType.Number && lastExprType != ExpressionType.BracketsExpr
                            && lastExprType != ExpressionType.Operation) throw new CalculationException("Format error!");
                                exprStack.Peek().children.AddLast(new Expression(4, false, true, (this_, left, right) =>
                                {
                                   right.toRemove = true;
                                    return ~( Convert.ToInt32(right.value.Value));
                                }));
                                lastExprType = ExpressionType.TextOperation;
                            }
                            else throw new CalculationException("Operation " + textExpr + " not known");

                            textExpr = "";
                        }
                    }
                    else
                    {
                        textExpr += char.ToLower(c);
                    }
                }
                else if (str[i] == ' ')
                {
                    i++;
                }
                else if (char.IsDigit(str[i]) || str[i] == ',' || str[i] == '.')
                {
                    double n = ProduceNumber(str, ref i, numberSystem);
                    Expression e = new Expression(n);
                    exprStack.Peek().children.AddLast(e);
                    lastExprType = ExpressionType.Number;
                }
            }
        }
        public double Calculate(IDictionary<char, double> additionalSymbols = null)
        {
            this.additionalSymbols = additionalSymbols;
            double resoult = ((Expression)rootExpression.Clone()).EvaluateChildren();
            return resoult;
        }

        double ProduceNumber(string str, ref int i, double digitSystem = 10)
        {
            double n = 0;
            bool fractionPart = false;
            double fractionDigit = 0;
            for (; i < str.Length; i++)
            {
                char c = str[i];
                if (!char.IsDigit(c))
                {
                    if ((c == ',' || c == '.') && !fractionPart)
                    {
                        fractionPart = true;
                        continue;
                    }
                    else break;
                }
                if (!fractionPart)
                {
                    n *= digitSystem;
                    double digit;
                    if(numberSystem <= 10)
                        digit = char.GetNumericValue(c);
                    else
                    {
                        throw new CalculationException("System " + digitSystem + " not supported");
                    }

                    if (digit >= digitSystem) throw new CalculationException("Invalid digit " + digit + " in " + digitSystem + " number system");
                    n += digit;
                }
                else
                {
                    n += char.GetNumericValue(c) * Math.Pow(digitSystem, --fractionDigit);
                }
            }
            return n;
        }
        static double Factorial(double i) // funkcja silni
        {
            if (i < 1) return 1;
            else
            {
                return (i * Factorial(i - 1));
            }
        }

        enum ExpressionType
        {
            None,
            Number,
            Operation,
            TextOperation,
            BracketsExpr
        }
        class Expression : ICloneable
        {
            Func<Expression, Expression, Expression, double> f; // w c++ function<Number(Expression*, Expression*, Expression*)> f;
            public int evaluationOrder; //kolejność dzilan np dodawnie 1 mnozenie 2
            public bool requiredLeft = false, requiredRight = false;
            public bool toRemove = false;
            public LinkedList<Expression> children = new LinkedList<Expression>();
            public double? value;

            public Expression()
            {

            }
            public Expression(double value)
            {
                this.value = value;
                evaluationOrder = 0;
            }
            public Expression(int evaluationOrder, bool requiredLeft, bool requiredRight, Func<Expression, Expression, Expression, double> function)
            {
                this.evaluationOrder = evaluationOrder;
                this.requiredLeft = requiredLeft;
                this.requiredRight = requiredRight;
                this.f = function;
            }

            public void Evaluate(Expression this_, Expression left, Expression right)
            {
                value = f(this_, left, right);
                //value = new Number(f(this_, left, right));
            }
            public double EvaluateChildren()
            {
                while (children.Count > 1)
                {
                    var most = children.First;
                    for (var i = children.First; i != null; i = i.Next)
                    {
                        if (most.Value.value.HasValue || (!i.Value.value.HasValue && i.Value.evaluationOrder > most.Value.evaluationOrder)) most = i;
                    }
                    Expression expr = most.Value;
                    if (expr.value.HasValue)
                    {
                        var i = children.First.Next;
                        for (; i != null; i = i.Next)
                        {
                            children.First.Value.value *= i.Value.value;
                        }
                        break;
                    }
                    else
                    {
                        var left = most.Previous;
                        var right = most.Next;
                        if (expr.requiredLeft && left == null) throw new CalculationException("Format error!");
                        if (expr.requiredRight && right == null) throw new CalculationException("Format error!");
                        expr.Evaluate(expr, left?.Value, right?.Value);
                        if (left != null && left.Value.toRemove) children.Remove(left);
                        if (right != null && right.Value.toRemove) children.Remove(right);
                    }
                }
                Expression only = children.First.Value;               
                if (!only.value.HasValue)
                {
                    if (only.requiredLeft || only.requiredRight) throw new CalculationException("Format error!");
                    only.Evaluate(only, null, null);
                }
                return only.value.Value;
            }

            public object Clone()
            {
                return new Expression(evaluationOrder, requiredLeft, requiredRight, f)
                {
                    children = new LinkedList<Expression>(children.Select(c => (Expression)c.Clone())),
                    value = this.value,
                    toRemove = this.toRemove
                };

            }
        };
        public class CalculationException : Exception
        {
            public CalculationException()
            {
            }
            public CalculationException(string message) : base(message)
            {
            }
            public CalculationException(string message, Exception innerException) : base(message, innerException)
            {
            }
            protected CalculationException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }
        }

    }


}
