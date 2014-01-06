using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using upcLookUp.UPCSearch;

namespace upcLookUp
{
    public class upcSearch
    {
        const string sAccessToken = "57BA9A76-DEA9-40A6-88E2-120A9A8035D0";

        private string _productName;
        private string _imageUrl;
        private string _productUrl;
        private string _storeName;


        public upcSearch(string upc)
        {
            
            string sEmpty = string.Empty;

            

            UPCSearchSoapClient _look = new UPCSearchSoapClient();
            // get back comma delimited string
            string sReturnVal = _look.GetProduct(upc, sAccessToken);
            string[] asRows = sReturnVal.Split('\n');
            string[] asValues = asRows[1].Split(',');
            _productName = asValues[0].Replace("\"", "");

            _imageUrl = asValues[1].Replace("\"", "");

            _productUrl = asValues[2].Replace("\"", "");

            _storeName = asValues[7].Replace("\"", "");
            
            
        }

        public string productName {
            get { return _productName; }
        }
        public string imageUrl {
            get { return _imageUrl; }   
        }
        public string productUrl {
            get { return _productUrl; }
            }
        public string storeName
        {
            get { return _storeName; }
        }
        


    }
}
