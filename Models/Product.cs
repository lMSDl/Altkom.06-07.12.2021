using System;

namespace Models
{
    public class Product
    {
        //private readonly DateTime created;
        //Read-only property - wartość może być ustawiona tylko w konstruktorze
        public DateTime Created { get; }

        public Product()
        {
            Created = DateTime.Now;
        }




        //Auto-property
        public string Name { private get; set; }
        //Ekwiwalent
        /*
        private string name;
        public string GetName()
        {
            return name;
        }
        public void SetName(string value)
        {
            name = value;
        }
        */

        //Full-property
        private float price;
        public float Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
            }
        }

        //Read-only property
        public string Info 
        {
            get
            {
                return Name + " (" + Price + "zł)"; 
            } 
        }

    }
}
