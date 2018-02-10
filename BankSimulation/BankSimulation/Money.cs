using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSimulation
{
    public class Money
    {
        public int Value { get; private set; }
        public int Count { get; private set; }

        public Money(int value, int count)
        {
            Value = value;
            Count = count;
        }

        public void LoadMoney(int count)
        {
            Count += count;
        }

        public void SpendMoney(int count)
        {
            Count -= count;
        }
    }
}
