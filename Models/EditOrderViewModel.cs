using System;
namespace part3.Models
{
    public class EditOrderViewModel
    {
        public int OrderId { get; set; }
        public int ComputerId { get; set; }
        public IEnumerable<Computer> Computers { get; set; }
        public IEnumerable<Component> Components { get; set; }
        public Dictionary<string, int> SelectedComponents { get; set; } // Key: Component Type, Value: Component Id
    }


}

