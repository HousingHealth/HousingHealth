namespace HH.DB.Models
{
    public class OwnershipFreq : BaseFields
    {
        public virtual string mailname1 { get; set; }
        public virtual float count { get; set; }
        public virtual decimal percent { get; set; }
    }
}
