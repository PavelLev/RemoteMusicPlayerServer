using System;
using System.Linq;

namespace RemoteMusicPlayerServer.Services
{
    public class RandomStringGenerator
    {
        private readonly char[] characterPool = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789".ToCharArray();
        private Random _random = new Random();
        public string Generate(int length){
            return new string(Enumerable.Repeat(characterPool, length)
                .Select(s => s[_random.Next(s.Length)]).ToArray());
        }

        public static RandomStringGenerator Instance { get; } = new RandomStringGenerator();
    }
}