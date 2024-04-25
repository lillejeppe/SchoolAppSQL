using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAppSQL.Models
{
    internal class Book
    {
        int Id { get; set; }
        string Title { get; set; }
        string Description { get; set; }
        double ProductionPrice { get; set; }
        double ProfitMargin {  get; set; }
        double MarketPrice { get; set; }

        public Book()
        {
            Id = 0;
            Title = string.Empty;
            Description = string.Empty;
            ProductionPrice = 0;
            ProfitMargin = 0;
        }

        public Book(int Id, string Titel, string Description, double ProductionPrice, double ProfitMargin)
        {
            this.Id = Id;
            this.Title = Titel;
            this.Description = Description;
            this.ProductionPrice = ProductionPrice;
            this.ProfitMargin = ProfitMargin;
            MarketPrice = ProfitMargin * ProductionPrice;
        }

        public override string ToString()
        {
            return $"Book ID: {Id} \nTitel: {Title} \n{Description} \n{MarketPrice} KR. \nProductionPrice {ProductionPrice} & ProfitMargin {ProfitMargin}%";
        }
    }
}
