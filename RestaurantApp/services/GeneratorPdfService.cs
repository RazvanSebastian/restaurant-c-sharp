using RestaurantApp.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IronPdf;

namespace RestaurantApp.services
{
    class GeneratorPdfService
    {
        private String readTextFile(String path)
        {          
            string line;
            String textFile = "";

            // Read the file and display it line by line.
            System.IO.StreamReader file = new System.IO.StreamReader(path);
            while ((line = file.ReadLine()) != null)   
                textFile+=line;            
            file.Close();
            return textFile;
        }
        public void generatePdfByOrder(Order order)
        {
            string header = this.readTextFile("D:/Faculty/an3/sem2/II/RestaurantApp/Header.txt");
            string finall = this.readTextFile("D:/Faculty/an3/sem2/II/RestaurantApp/Finall.txt");
            Console.WriteLine(header.IndexOf("NumeOspatar"));
            header=header.Replace("NumeOspatar",order.User.LastName);
            header= header.Replace("DataFinalizare", order.OrderDate.ToString("yyyy-MM-dd h:mm tt"));

            String menuList = "";
            double amount = 0;
            foreach (FoodStuff food in order.OrderFood)
            {
                menuList += "<li>" + food.Name + " x1  Pret " + food.Price + " lei";
                amount += food.Price;
                Console.WriteLine(amount);
            }
           finall= finall.Replace("TotalDePlata", amount+"");

            HtmlToPdf HtmlToPdf = new IronPdf.HtmlToPdf();
            PdfResource PDF = HtmlToPdf.RenderHtmlAsPdf(header+menuList+finall);
            PDF.SaveAs("D:/BonFiscal"+order.IdOrder+".Pdf");
        }
    }
}
