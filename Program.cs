using System;
using System.Reflection.Metadata.Ecma335;
using Microsoft.Extensions.DependencyInjection;

// using System.Net.NetworkInformation;
using MyFirstApp;
namespace MyFirstApp
{
    interface IClassC
    {
        public void ActionC();
    }

    interface IClassB
    {
        public void ActionB();
    }

    class ClassC : IClassC
    {
        public ClassC() { Console.WriteLine("ClassC created"); }
        public void ActionC() => Console.WriteLine("ActionC in ClassC");
    }

    class ClassC1 : IClassC
    {
        public ClassC1() { Console.WriteLine("ClassC1 created"); }
        public void ActionC() => Console.WriteLine("ActionC in ClassC1");
    }

    class ClassB : IClassB
    {
        IClassC c_dependency;
        public ClassB(IClassC classc)
        {
            c_dependency = classc;
            Console.WriteLine("ClassB created");
        }

        public void ActionB()
        {
            Console.WriteLine("ActionB in ClassB");
            c_dependency.ActionC();
        }
    }

    class ClassB1 : IClassB
    {
        IClassC c_dependency;
        public ClassB1(IClassC classc)
        {
            c_dependency = classc;
            Console.WriteLine("ClassB1 created");
        }

        public void ActionB()
        {
            Console.WriteLine("ActionB in ClassB1");
            c_dependency.ActionC();
        }
    }

    class ClassB2 : IClassB
    {
        IClassC c_dependency;
        string message;
        public ClassB2(IClassC classc, string mgs)
        {
            c_dependency = classc;
            message = mgs;
            Console.WriteLine("ClassB2 is created");
        }
        public void ActionB()
        {
            Console.WriteLine(message);
            c_dependency.ActionC();
        }
    }

    class ClassA
    {
        IClassB b_dependency;

        public ClassA(IClassB classb) => b_dependency = classb;

        public void ActionA()
        {
            Console.WriteLine("ActionA in ClassA");
            b_dependency.ActionB();
        }
    }
    class Program
    {
        public static IClassB CreatClassB2(IServiceProvider serviceProvider)
        {
            var b2 = new ClassB2(
                    serviceProvider.GetRequiredService<IClassC>(),
                    "Hello Nguyen An"  // Constructor with parameter
                );
            return b2;
        }
        static void Main(string[] args)
        {
            // IClassC classC = new ClassC1();
            // IClassB classB = new ClassB1(classC);
            // ClassA classA = new(classB);

            // classA.ActionA();

            // Thu vien Dependency Injection
            // DI container : ServiceCollection
            //  - Dang ky dich vu (lop). (co 3 kieu dang ky : singleton, transient, scoped)
            //  - ServiceProvider : Cung cap dich vu , (GetService) de lay ra cac dich vi da dang ky 
            var services = new ServiceCollection();

            // Dang ky dich vu ... 
            // IclassC , ClassC, ClassC1

            services.AddSingleton<ClassA, ClassA>(); // Singleton: 1 instance for the entire application
            services.AddSingleton<IClassB>(CreatClassB2); // Singleton: 1 instance for the entire application
            services.AddSingleton<IClassC, ClassC>();


            var provider = services.BuildServiceProvider();

            ClassA classA = provider.GetRequiredService<ClassA>();
            classA.ActionA();

        }
    }
}
