using System;
namespace easyMedicine.Models
{
    public class ErrorItem
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public string DrugId
        {
            get;
            set;
        }
        public string DrugName
        {
            get;
            set;
        }
        public string Sender
        {
            get;
            set;
        }
    }
}
