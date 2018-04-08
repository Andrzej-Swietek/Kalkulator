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

        public Calcualtion(string str)//konstruktor
        {
            this.str = str;
        }

        public static double Factorial(double i) // funkcja silni
        {
            if (i < 1)  { return 1; }
                
            else { return (i * Factorial(i - 1)); }
                
        }

        public double NoWezIOblicz()
        {
            Expression rootExpr = new Expression();
            Stack<Expression> exprStack = new Stack<Expression>(); //stos w którym nawiasie lub expreszynie jestesmy
            exprStack.Push(rootExpr);
            ExpressionType lastExprType = ExpressionType.None;
            string textExpr = "";
            char c;

            for (int i = 0; i < str.Length;)
            {
                c = str[i];
                
                if(char.IsLetter(c))
                {
                    i++;
                    textExpr += char.ToLower(c);              
                }
                else if(!string.IsNullOrEmpty(textExpr))
                {
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
                            return (Math.Sin(right.value.Value*Math.PI/180));
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
                            return (Math.Cos(right.value.Value*Math.PI/180));
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
                            return (Math.Tan(right.value.Value*Math.PI/180));
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
                            return 1/(Math.Tan(right.value.Value * Math.PI / 180));
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
                            return (1/right.value.Value);
                        }));
                        lastExprType = ExpressionType.Operation;//ostatnia wyraz to opercja
                    }
                    else throw new CalculationException("Operation " + textExpr + " not known");
                   
                    textExpr = "";
                }
                else if (char.IsDigit(c) || c == ',' || c == '.')
                {
                    double n = ProduceNumber(str, ref i);
                    Expression e = new Expression(n);
                    exprStack.Peek().children.AddLast(e);
                    lastExprType = ExpressionType.Number;
                }
                else
                {
                    i++;

                    if (c == ' ')
                    {

                    }
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
                    else if (c == '/')
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
                    else if (c == '(')
                    {
                        if (lastExprType != ExpressionType.None && lastExprType != ExpressionType.Number && lastExprType != ExpressionType.BracketsExpr
                            && lastExprType != ExpressionType.Operation && lastExprType != ExpressionType.TextOperation) throw new CalculationException("Format error!");
                        Expression e = new Expression(10, true, true, (this_, left, right) => {
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
                    else if (c == '!')
                    {
                        
                        if (lastExprType != ExpressionType.Number && lastExprType != ExpressionType.BracketsExpr) throw new CalculationException("Format error!");//sprawdza czy byla liczba ostatnia anie nic lub znak
                        exprStack.Peek().children.AddLast(new Expression(3, true, false, (this_, left, right) => {
                            left.toRemove = true;//obu ustawiamy true bo ich uzywa
                            return Factorial(left.value.Value);
                        }));
                        lastExprType = ExpressionType.Operation;//ostatnia wyraz to opercja
                    }
                    else
                    {
                        throw new CalculationException("Invalid charracter: " + c);
                    }
                }
            }

            double resoult = rootExpr.EvaluateChildren();
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
                    n += (double)char.GetNumericValue(c);
                }
                else
                {
                    n += (double)char.GetNumericValue(c) * (double)Math.Pow(digitSystem, --fractionDigit);
                }
            }
            return n;
        }

        enum ExpressionType
        {
            None,
            Number,
            Operation,
            TextOperation,
            BracketsExpr
        }
        class Expression
        {
            Func<Expression, Expression, Expression, double> f; // w c++ function<Number(Expression*, Expression*, Expression*)> f;
            public int evaluationOrder; //kolejność dzilan np dodawnie 1 mnozenie 2
            public bool usesLeft = false, usesRight = false;
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
            public Expression(int evaluationOrder, bool usesLeft, bool usesRight, Func<Expression, Expression, Expression, double> function)
            {
                this.evaluationOrder = evaluationOrder;
                this.usesLeft = usesLeft;
                this.usesRight = usesRight;
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
                        expr.Evaluate(expr, (expr.usesLeft && left != null) ? left.Value : null, (expr.usesRight && right != null) ? right.Value : null);
                        if (left != null && left.Value.toRemove) children.Remove(left);
                        if (right != null && right.Value.toRemove) children.Remove(right);
                    }
                }
                Expression only = children.First.Value;
                if (!only.value.HasValue) only.Evaluate(only, null, null);
                return only.value.Value;

                //list<Expression>::iterator i, j;
                //while ((i = j = children.begin(), ++j) != children.end())
                //{
                //    auto most = i;
                //    for (; j != children.end(); ++j)
                //    {
                //        if (most->value != nullptr || (j->value == nullptr && j->evaluationOrder > most->evaluationOrder)) most = j;
                //    }
                //    Expression & expr = *most;
                //    if (expr.value != nullptr) //all expressions have value
                //    {
                //        auto it = i;
                //        for (++it; it != children.end(); ++it)
                //        {
                //            *i->value *= *it->value;
                //        }
                //        break;
                //    }
                //    else
                //    {
                //        ++i;
                //        auto left = most, right = most;
                //        expr.evaluate(&expr, (expr.usesLeft && left != children.begin()) ? &*--left : nullptr, (expr.usesRight && ++right != children.end()) ? &*right : nullptr);
                //        if (left->toRemove) children.erase(left);
                //        if (right->toRemove) children.erase(right);
                //    }
                //}
                //if (i->value == nullptr) i->evaluate(&*i, nullptr, nullptr);
                //return *i->value;
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
