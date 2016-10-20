using System;

namespace ConsoleApplication
{

    abstract class Aggregate
    {
        public abstract int count();
        public abstract string this[int index] { get;  }
        public abstract AIterator getIterator();

    }

    class Student : Aggregate
    {
        private string[] students = new string[] {
            "Student 1", "Student 2", "Student 3", "Student 4", "Student 5"
        };

        
        public override int count()
        {
            return this.students.Length;
        }

        public override string this[int index] 
        {
            get
            {
                return this.students[index];
            }
        }

        public override AIterator getIterator() 
        {
            return new MyIterator(this);
        }
    }

    abstract class AIterator
    {
        protected Aggregate agg;
        protected int currentIndex = 0;
        public abstract bool isFinish();
        public abstract string nextStudent();

        public abstract string currentStudent();
    }

    class MyIterator : AIterator {
        public MyIterator(Aggregate agg) {
            this.agg = agg;
        }

        public override bool isFinish()
        {
            return currentIndex >= this.agg.count();
        }

        public override string nextStudent()
        {
            currentIndex++;
            if (currentIndex < this.agg.count()) {
                return this.agg[currentIndex];
            } else {
                return null;
            }
            
        }

        public override String currentStudent()
        {
            if (currentIndex <= this.agg.count()) {
                return this.agg[currentIndex];
            } else {
                return null;
            }
            
        }

    }
    

    public class Program
    {
        public static void Main(string[] args)
        {
            
            Student st = new Student();
            AIterator iter = st.getIterator();
            while(!iter.isFinish()) {
                Console.WriteLine( iter.currentStudent() );
                iter.nextStudent();
            }
        }
    }
}
