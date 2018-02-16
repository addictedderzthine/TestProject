using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Dto
{

    //Classes inside the DTO assembly will be the classes that will be sent over to the client
    public class ProductDto
    {
        //This can be split into two diffent classes
        //You can have a createProductDto without the ID property
        //and you can also have the Edit/Update DTO with the ID property
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
    }
}
