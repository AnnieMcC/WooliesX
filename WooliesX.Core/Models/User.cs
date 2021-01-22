
namespace WooliesX.Core.Models
{
    public class User : BaseId<int>
    {
        public string Token { get; set; }
        public string Name { get; set; }
    }
}
