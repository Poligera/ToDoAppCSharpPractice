namespace ToDoTest
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Worker
    {
        private readonly UserKeeper _userKeeper;

        public Worker(UserKeeper userKeeper)
        {
            _userKeeper = userKeeper;
        }

        public void Test()
        {
            Console.WriteLine("i'm worker");
        }
    }
}
