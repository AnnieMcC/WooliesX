
namespace WooliesX.Core.Models
{
    public class User : BaseId<int>
    {
        public string Name { get; set; }

        public string Token { get; set; }
    }
}
