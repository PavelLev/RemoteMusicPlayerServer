using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace RemoteMusicPlayerServer.Services
{
    public class FileProvider
    {
        private readonly Dictionary<string, string> _filePaths = new Dictionary<string, string>();
        private readonly TcpListener _tcpListener = TcpListener.Create(54364);
        private readonly int _tokenLength = 32;

        public string GetTokenForFile(string filePath) {
            var token = RandomStringGenerator.Instance.Generate(_tokenLength);
            _filePaths.Add(token, filePath);
            return token;
        }

        private FileProvider() {
            _tcpListener.Start();
            StartAccepting();
        }

        private async void StartAccepting() {
            while (true) {
                var networkStream = (await _tcpListener.AcceptTcpClientAsync()).GetStream();

                var token = await networkStream.ReadAsync();

                if(!_filePaths.ContainsKey(token)) {
                    networkStream.Close();
                }

                var filePath = _filePaths[token];
                
                try 
                {
                    await File.OpenWrite(filePath).CopyToAsync(networkStream);
                }
                catch 
                {
                    // Ignore
                }
                
                _filePaths.Remove(token);

                networkStream.Close();
            }
        }

        public static FileProvider Instance { get; } = new FileProvider();
    }
}