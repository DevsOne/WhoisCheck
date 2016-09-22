using System.ComponentModel.DataAnnotations;

namespace WhoisCheck.Models
{
    public class TLDViewModel
    {
        public string TldName { get; set; }
        public string ASCIIcode { get; set; }
        public string WhoisServer { get; set; }
    }
    public class DomainViewModels
    {
        [Display(Name = "Domain Name")]
        public string DomainName { get; set; }
        public string DomainDetails { get; set; }
    }
}