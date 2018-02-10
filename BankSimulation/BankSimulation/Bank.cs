using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSimulation
{
    public class Bank
    {
        #region Properties
        public List<Money> MoneyList { get; private set; }

        #endregion

        #region Constructors
        public Bank()
            :this(0, 0, 0, 0, 0, 0)
        {

        }
        public Bank(int money200Count, int money100Count, int money50Count, 
                int money20Count, int money10Count, int money5Count)
        {
            MoneyList = new List<Money>();
            MoneyList.Add(new Money(200, money200Count));
            MoneyList.Add(new Money(100, money100Count));
            MoneyList.Add(new Money(50, money50Count));
            MoneyList.Add(new Money(20, money20Count));
            MoneyList.Add(new Money(10, money10Count));
            MoneyList.Add(new Money(5, money5Count));
        }
        #endregion

        #region Methods
        public void LoadMoney(int money200Count = 0, int money100Count = 0, int money50Count = 0,
                int money20Count = 0, int money10Count = 0, int money5Count = 0)
        {
            MoneyList[0].LoadMoney(money200Count);
            MoneyList[1].LoadMoney(money100Count);
            MoneyList[2].LoadMoney(money50Count);
            MoneyList[3].LoadMoney(money20Count);
            MoneyList[4].LoadMoney(money10Count);
            MoneyList[5].LoadMoney(money5Count);
        }

        public List<Money> TakeMoney(int money)
        {
            double thirtyPercent = money * 0.7;
            double seventyPercent = money * 0.3;

            List<Money> moneyList = new List<Money>();
            moneyList.Add(new Money(200, 0));
            moneyList.Add(new Money(100, 0));
            moneyList.Add(new Money(50, 0));
            moneyList.Add(new Money(20, 0));
            moneyList.Add(new Money(10, 0));
            moneyList.Add(new Money(5, 0));

            for (int i=5; i>=0; i--)
            {
                while (MoneyList[i].Count > moneyList[i].Count && seventyPercent >= MoneyList[i].Value)
                {
                    seventyPercent -= MoneyList[i].Value;
                    moneyList[i].LoadMoney(1);
                }
            }

            for (int i=0; i<=5; i++)
            {
                while (MoneyList[i].Count > moneyList[i].Count && thirtyPercent >= MoneyList[i].Value)
                {
                    thirtyPercent -= MoneyList[i].Value;
                    moneyList[i].LoadMoney(1);
                }
            }
            if (seventyPercent > 0 || thirtyPercent > 0)
            {
                throw new Exception();
            }
            else
            {
                DeleteMoney(moneyList);
            }
            return moneyList;
        }

        private void DeleteMoney(List<Money> moneyList)
        {
            for (int i=0; i<MoneyList.Count; i++)
            {
                MoneyList[i].SpendMoney(moneyList[i].Count);
            }
        }

        public int TotalMoney
        {
            get
            {
                int sum = 0;
                foreach(var money in MoneyList)
                {
                    sum += money.Count * money.Value;
                }
                return sum;
            }
        }


        #endregion
    }
}
