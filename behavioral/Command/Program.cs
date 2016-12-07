using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    interface Command
    {
        void Do();
        void Undo();
    }

    class CalcComppand : Command {
        private int operand;
        private char com;

        private Calculator calc;
        
        public CalcComppand( Calculator calc, int oper, char c )
        {
            this.calc = calc;
            this.operand = oper;
            this.com = c;
        }

        public void Do()
        {
            this.calc.Execute( this.operand, this.com );
        }

        public void Undo()
        {
            this.calc.Execute( this.operand, this.inverseOCom( this.com ) );
        }

        private char inverseOCom( char c )
        {
            switch(c)
            {
                case '+':
                  return '-';
                case '-':
                  return '+';
                case '*':
                  return '/';
                case '/':
                  return '*';
            }
            return c;
        }

    }

    // Receiver
    class Calculator 
    {
        private int sum = 0;
        
        public void Execute(int operand, char operat)
        {
            switch(operat)
            {
                case '+':
                  this.sum += operand;
                  break;
                case '-':
                  this.sum -= operand;
                  break;
                case '*':
                  this.sum *= operand;
                  break;
                case '/':
                  this.sum /= operand;
                  break;
            }
        }

        public int getResult()
        {
            return this.sum;
        }
    }

    // Invoker
    class Invoker{
        private List<Command> commands = new List<Command>();
        private int currentCommand = 0;
        private Calculator calc = new Calculator();

        public void createCommand( int operand, char oper )
        {
            Command command = new CalcComppand( this.calc, operand, oper );
            command.Do();
            if (this.currentCommand < this.commands.Count ) {
                this.commands.RemoveRange( this.currentCommand, this.commands.Count - this.currentCommand );
            }
            this.commands.Add( command );
            this.currentCommand++;
            
        }

        public void unDo(int countComs) 
        {
            for (int i=0; i < countComs; i++)
            {
                this.commands[--this.currentCommand].Undo();
            }
        }

        public float getResult()
        {
            return this.calc.getResult();
        }

    }

    

    public class Program
    {
        public static void Main(string[] args)
        {
            Invoker inv = new Invoker();
            inv.createCommand( 5, '+' );
            inv.createCommand( 2, '*' );
            inv.createCommand(1, '-');
            Console.WriteLine( inv.getResult() ); //9
            inv.unDo( 2 );
            Console.WriteLine( inv.getResult() ); // 5
        }
    }
}
