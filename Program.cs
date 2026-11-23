using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAD1
{
    // Добавил комментарий для проверки push
    //Объявление интерфейсов
    interface Ix

    {
        void IxF0(double x);
        void IxF1();
    }

    interface Iy
    {
        void F0(double x);
        void F1();
    }

    interface Iz
    {
        void F0(double x);
        void F1();
    }

    class TestClass : Ix, Iy, Iz
    {
        public double w;

        public TestClass(double w)
        {
            this.w = w;
        }

        //Реализация интерфейса Ix (неявная)
        public void IxF0(double x)
        {
            double res = Math.Cos(x);
            Console.WriteLine($"Ix.IxF0({x}) = cos({x}) = {res:F4}");
        }

        public void IxF1()
        {
            double res = Math.Cos(w);
            Console.WriteLine($"Ix.IxF1() для w={w} = cos({w}) = {res:F4}");
        }

        //Реализация интерфейса Iy (неявная)
        public void F0(double x)
        {
            double res = Math.Exp(x);
            Console.WriteLine($"Iy.F0({x}) [Неявная] = exp({x}) = {res:F4}");
        }

        public void F1()
        {
            double res = Math.Exp(w);
            Console.WriteLine($"Iy.F1() [Неявная] для w={w} = exp({w}) = {res:F4}");
        }

        //Реализация интерфейса Iz (явная)
        void Iz.F0(double x)
        {
            double res = x - 6;
            Console.WriteLine($"Iz.F0({x}) [Явная] = {x} - 6 = {res:F4}");
        }

        void Iz.F1()
        {
            double res = w - 6;
            Console.WriteLine($"Iz.F1() [Явная] для w={w} = {w} - 6 = {res:F4}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Ввод данных
            Console.Write("Введите значение w: ");
            double testValue = double.Parse(Console.ReadLine());

            TestClass obj = new TestClass(testValue);

            Console.WriteLine("1.Вызов неявной реализации из объекта:");
            //Метод IxF0/F1 из Ix
            obj.IxF0(testValue);
            obj.IxF1();

            //Методы для Iy
            obj.F0(testValue);
            obj.F1();

            Console.WriteLine("\n2. Вызов методов с явным приведением:");
            //Явное приведение к Iy
            ((Iy)obj).F0(testValue);
            ((Iy)obj).F1();

            //Явное приведение к Iz
            ((Iz)obj).F0(testValue);
            ((Iz)obj).F1();

            Console.WriteLine("\n3. Вызов методов посредством интерфейсной ссылки:");
            // Интерфейсные ссылки
            Ix refX = obj;
            Iy refY = obj;
            Iz refZ = obj;

            Console.WriteLine("\nЧерез ссылку refX (Ix)");
            refX.IxF0(testValue);
            refX.IxF1();

            Console.WriteLine("Через ссылку refY (Iy)");
            refY.F0(testValue);
            refY.F1();

            Console.WriteLine("Через ссылку refZ (Iz)");
            refZ.F0(testValue);
            refZ.F1();

            Console.ReadKey();
        }
    }
}