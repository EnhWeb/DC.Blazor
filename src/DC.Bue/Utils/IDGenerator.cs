using System;
using System.Threading;

namespace DC.Bue.Utils
{
    /// <summary>
    /// 参考https://github.com/aspnet/KestrelHttpServer/blob/6fde01a825cffc09998d3f8a49464f7fbe40f9c4/src/Kestrel.Core/Internal/Infrastructure/CorrelationIdGenerator.cs
    /// 生成一个有效的Long ID。使用0-9的数字和A-V的字母
    /// </summary>
    public sealed class IDGenerator
    {
        private const string encode_32_Chars = "0123456789ABCDEFGHIJKLMNOPQRSTUV";
        private static long _lastId = DateTime.UtcNow.Ticks;

        private static readonly ThreadLocal<char[]> _charBufferThreadLocal = new ThreadLocal<char[]>(() => new char[13]);  // ThreadLocal用于让各个线程维持自己的变量，其他线程操作不会影响另外的线程里已有的值。

        /// <summary>
        /// 返回<see cref="IDGenerator"/>的新实例
        /// </summary>
        public static IDGenerator Instance { get; set; } = new IDGenerator();

        /// <summary>
        /// 获取生成的Id
        /// </summary>
        public string Generate
        {
            get
            {
                return GenerateImpl(Interlocked.Increment(ref _lastId));
            }
        }

        /// <summary>
        /// 生成Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private static string GenerateImpl(long id)
        {
            var buffer = _charBufferThreadLocal.Value;

            buffer[0] = encode_32_Chars[(int)(id >> 60) & 31];
            buffer[1] = encode_32_Chars[(int)(id >> 55) & 31];
            buffer[2] = encode_32_Chars[(int)(id >> 50) & 31];
            buffer[3] = encode_32_Chars[(int)(id >> 45) & 31];
            buffer[4] = encode_32_Chars[(int)(id >> 40) & 31];
            buffer[5] = encode_32_Chars[(int)(id >> 35) & 31];
            buffer[6] = encode_32_Chars[(int)(id >> 30) & 31];
            buffer[7] = encode_32_Chars[(int)(id >> 25) & 31];
            buffer[8] = encode_32_Chars[(int)(id >> 20) & 31];
            buffer[9] = encode_32_Chars[(int)(id >> 15) & 31];
            buffer[10] = encode_32_Chars[(int)(id >> 10) & 31];
            buffer[11] = encode_32_Chars[(int)(id >> 5) & 31];
            buffer[12] = encode_32_Chars[(int)id & 31];

            return new string(buffer, 0, buffer.Length);
        }
    }
}
