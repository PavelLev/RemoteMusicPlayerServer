using System;
using Microsoft.AspNetCore.Mvc;
using RemoteMusicPlayerServer.Services;

namespace RemoteMusicPlayerServer.Controllers
{

    public class FileSystemController : Controller
    {
        public IActionResult GetTokenForFile(string filePath)
        {
            if (!System.IO.File.Exists(filePath)) {
                return NotFound();
            }

            if(!FileExtensionVerifier.Instance.IsValid(filePath)) {
                return BadRequest("wrong extension");
            }

            var token = FileProvider.Instance.GetTokenForFile(filePath);

            return Ok(token);
        }

        public IActionResult GetJunk(string path) {
            if (path == "123") {
                return Ok(new Junk { result = path });
            }
            return NotFound(path);
        }

        public IActionResult GetTestJunk() {
            return Ok(FileProvider.Instance);
        }
    }

    public class Junk 
    {
        public string result { get; set; }
    }
}