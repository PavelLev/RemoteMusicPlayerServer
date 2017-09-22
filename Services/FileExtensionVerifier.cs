using System.Linq;

namespace RemoteMusicPlayerServer.Services
{
    public class FileExtensionVerifier
    {
        private readonly string[] _allowedExtensions = new[] {
            ".mp3",
            ".flac"
        };

        public bool IsValid(string filePath) {
            return _allowedExtensions.Any(filePath.EndsWith);
        }

        public static FileExtensionVerifier Instance { get; } = new FileExtensionVerifier();
    }
}