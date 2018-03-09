using CompanyLocator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using static CompanyLocator.APIHandler;
using static CompanyLocator.Models.Company;

namespace CompanyLocator
{
    public class ResponseHandler
    {
        #region variables
        string _mlocationName;
        String _mKey = "AIzaSyBgJwGwRk31NRr42jZDEPW770g6RdglGqo";
        static string _mUrl;
        #endregion



        public string SplitToWords(string city)
        {
            _mlocationName = "";
            string[] words = city.Split(' ');
            foreach (var iterator in words)
            {
                _mlocationName = _mlocationName + iterator + "+";
            }
            return city;

        }

        public List<Company> Parser(string apiResponse)
        {
            XmlDocument document = new XmlDocument();
            document.LoadXml(apiResponse);
            XmlNodeList name = document.GetElementsByTagName("name");
            List<string> nameList = new List<string>();
            XmlNodeList address = document.GetElementsByTagName("formatted_address");
            List<string> addressList = new List<string>();

            int counter = 0;

            foreach (XmlNode i in name)
            {
                nameList.Add(i.InnerText);
                counter++;
            }
            counter = 0;

            foreach (XmlNode j in address)
            {
                addressList.Add(j.InnerText);
                counter++;
            }
            var companies = new List<Company>();
            for (int i = 0; i < counter; i++)
            {
                var company = new Company
                {
                    Name = nameList[i],
                    Address = addressList[i]
                };
                companies.Add(company);
            }



            return companies;
        }
        public List<Company> getCompanies(string city)
        {

            string splitCity = SplitToWords(city);
            APIHandler handler = new APIHandler();
            _mUrl = "https://maps.googleapis.com/maps/api/place/textsearch/xml?query=IT+company+" + splitCity + "&hasNextPage=true&nextPage()=true" + "&key=" + _mKey + "&pagetoken=";
           
            List<Company> companies = Parser(handler.GetResponse(_mUrl));
            
            return companies;

        }

    }
}