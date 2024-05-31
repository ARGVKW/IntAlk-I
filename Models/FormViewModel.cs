namespace IntAlk_I.Models
{
    public class FormViewModel
    {

        public required FormValues FormValues { get; set; }
        public FormValidation? FormValidation { get; set; }

        public required string Eredmeny { get; set; }
    }
}
