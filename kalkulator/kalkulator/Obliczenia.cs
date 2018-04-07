using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace kalkulator
{
    //Przykładowa zmiana
    
    
    class Obliczenie
    {
        string str;

        public Obliczenie(string str)
        {
            this.str = str;
        }

        //zmiana 2


        public float NoWezIOblicz()
        {
            Expression rootExpr = new Expression();
            Stack<Expression> exprStack = new Stack<Expression>();
            exprStack.Push(rootExpr);
            ExpressionType lastExprType = ExpressionType.None;
            char c;

            for (int i = 0; i < str.Length;)
            {
                c = str[i];
                if(char.IsDigit(c) || c == ',' || c == '.')
                {
                    float n = ProduceNumber(str, ref i);
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
                        if (lastExprType == ExpressionType.None || lastExprType == ExpressionType.Operation) throw new CalculationException("Format error!");
                        exprStack.Peek().children.AddLast(new Expression(1, true, true, (this_, left, right) => {
                            left.toRemove = right.toRemove = true;
                            return left.value.Value + right.value.Value;
                        }));
                        lastExprType = ExpressionType.Operation;
                    }
                    else if (c == '-')
                    {             
                        if(lastExprType == ExpressionType.None)
                        {
                            exprStack.Peek().children.AddLast(new Expression(4, false, true, (this_, left, right) => {
                                right.toRemove = true;
                                return -right.value.Value;
                            }));
                        }
                        else if(lastExprType == ExpressionType.Number || lastExprType == ExpressionType.Operation)
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
                        if (lastExprType == ExpressionType.None || lastExprType == ExpressionType.Operation) throw new CalculationException("Format error!");
                        exprStack.Peek().children.AddLast(new Expression(2, true, true, (this_, left, right) => {
                            left.toRemove = right.toRemove = true;
                            return left.value.Value * right.value.Value;
                        }));
                        lastExprType = ExpressionType.Operation;
                    }
                    else if (c == '/')
                    {
                        if (lastExprType == ExpressionType.None || lastExprType == ExpressionType.Operation) throw new CalculationException("Format error!");
                        exprStack.Peek().children.AddLast(new Expression(2, true, true, (this_, left, right) => {
                            if (right.value.Value == 0) throw new CalculationException("Attemption to divide by 0!");
                            left.toRemove = right.toRemove = true;
                            return left.value.Value / right.value.Value;
                        }));
                        lastExprType = ExpressionType.Operation;
                    }
                    else if (c == '%')
                    {
                        if (lastExprType == ExpressionType.None || lastExprType == ExpressionType.Operation) throw new CalculationException("Format error!");
                        exprStack.Peek().children.AddLast(new Expression(2, true, true, (this_, left, right) => {
                            if (right.value.Value == 0) throw new CalculationException("Attemption to modulo by 0!");
                            left.toRemove = right.toRemove = true;
                            return left.value.Value % right.value.Value;
                        }));
                        lastExprType = ExpressionType.Operation;
                    }
                    else if (c == '^')
                    {
                        if (lastExprType == ExpressionType.None || lastExprType == ExpressionType.Operation) throw new CalculationException("Format error!");
                        exprStack.Peek().children.AddLast(new Expression(3, true, true, (this_, left, right) => {
                            if (left.value.Value == 0 && right.value.Value == 0) throw new CalculationException("Operation 0^0 is undefinited!");
                            left.toRemove = right.toRemove = true;
                            return (float)Math.Pow(left.value.Value, right.value.Value);
                        }));
                        lastExprType = ExpressionType.Operation;
                    }
                    else if (c == '(')
                    {
                        Expression e = new Expression(10, true, true, (this_, left, right) => {
                            return this_.EvaluateChildren();
                        });
                        exprStack.Peek().children.AddLast(e);
                        exprStack.Push(exprStack.Peek().children.Last.Value);
                        lastExprType = ExpressionType.None;
                    }
                    else if(c == ')')
                    {
                        if (lastExprType == ExpressionType.None || exprStack.Count == 1) throw new CalculationException("Brackets error!");
                        exprStack.Pop();
                        lastExprType = ExpressionType.Number;
                    }
                    else
                    {
                        throw new CalculationException("Invalid charracter: " + c);
                    }
                }
            }

            float resoult = rootExpr.EvaluateChildren();
            return resoult;
        }

        float ProduceNumber(string str, ref int i, float digitSystem = 10)
        {
            float n = 0;
            bool fractionPart = false;
            float fractionDigit = 0;
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
                    n += (float)char.GetNumericValue(c);
                }
                else
                {
                    n += (float)char.GetNumericValue(c) * (float)Math.Pow(digitSystem, --fractionDigit);
                }
            }
            return n;
        }

        enum ExpressionType
        {
            None,
            Number,
            Operation
        }
        class Expression
        {   
	        Func<Expression, Expression, Expression, float> f; // function<Number(Expression*, Expression*, Expression*)> f;
            public int evaluationOrder;
            public bool usesLeft = false, usesRight = false;
            public bool toRemove = false;
            public LinkedList<Expression> children = new LinkedList<Expression>();
            public float? value;

            public Expression()
            {

            }
            public Expression(float value)
            {
                this.value = value;
                evaluationOrder = 0;
            }
            public Expression(int evaluationOrder, bool usesLeft, bool usesRight, Func<Expression, Expression, Expression, float> function)
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
            public float EvaluateChildren()
            {
                while(children.Count > 1)
                {
                    var most = children.First;
                    for (var i = children.First; i != null; i = i.Next)
                    {
                        if (most.Value.value.HasValue || (!i.Value.value.HasValue && i.Value.evaluationOrder > most.Value.evaluationOrder)) most = i;
                    }
                    Expression expr = most.Value;
                    if(expr.value.HasValue)
                    {
                        var i = children.First.Next;
                        for(;i != null; i = i.Next)
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
