using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockMarket
{
    public class Investor
    {
        private HashSet<Stock> portfolio;
        public Investor(string fullName, string emailAddress, decimal moneyToInvest, string brokerName)
        {
            FullName = fullName;
            EmailAddress = emailAddress;
            MoneyToInvest = moneyToInvest;
            BrokerName = brokerName;
            Portfolio = new HashSet<Stock>();
        }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public decimal MoneyToInvest { get; set; }
        public string BrokerName { get; set; }
        public HashSet<Stock> Portfolio { get; set; }
        public int Count => this.Portfolio.Count;

        public void BuyStock(Stock stock)
        {
            if (stock.MarketCapitalization > 10000 && MoneyToInvest >= stock.PricePerShare)
            {
                MoneyToInvest -= stock.PricePerShare;
                Portfolio.Add(stock);
            }
        }
        public string SellStock(string companyName, decimal sellPrice)
        {
            var name = Portfolio.FirstOrDefault(x => x.CompanyName == companyName);
            if (name == null)
            {
                return $"{companyName} does not exist.";
            }
            if (sellPrice < name.PricePerShare)
            {
                return $"Cannot sell {companyName}.";
            }
            Portfolio.Remove(name);
            MoneyToInvest += sellPrice;
            return $"{companyName} was sold.";
        }
        public Stock FindStock(string companyName)
        {
            if (Portfolio.Any(x => x.CompanyName == companyName))
            {
                return Portfolio.FirstOrDefault(x => x.CompanyName == companyName);
            }

            return null;
        }
        public Stock FindBiggestCompany()
        {
            if (Portfolio.Count > 0)
            {
                var largest = Portfolio.Select(x => x.MarketCapitalization).Max();
                return Portfolio.FirstOrDefault(x => x.MarketCapitalization == largest);
            }

            return null;
        }
        public string InvestorInformation()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The investor {this.FullName} with a broker {this.BrokerName} has stocks:");

            foreach (var stock in this.Portfolio)
            {
                sb.AppendLine(stock.ToString());
            }
            return sb.ToString().TrimEnd();
        }

    }
}
