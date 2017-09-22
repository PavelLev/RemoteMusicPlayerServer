using Microsoft.AspNetCore.Mvc;

namespace RemoteMusicPlayerServer.Controllers
{
    public class ValuesController : Controller
    {
        public string Get(int id)
        {
            return "value";
        }

        public string Junk(int id)
        {
            return "junk";
        }

        public string Echo(string value) {
            return value;
        }
    }
}
