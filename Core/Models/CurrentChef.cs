namespace Core.Models
{
    public class CurrentChef
    {
        static public Chef ThisChef { get; set; }
        static public bool TheChefislogin { get; set; }  = false;
    }
}
