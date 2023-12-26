using System.Diagnostics.Metrics;

namespace mvcDriverWithAuth.Models
{
    public class DriverMakeViewModel
    {
        public IEnumerable<Driver> Drivers { get; set; }
        public IEnumerable<Make> Makes { get; set; }

        public bool ShowModifyLinks { get; set; }
    }
}
