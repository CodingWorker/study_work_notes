using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Compression;
using System.IO;

namespace class1
{
    /// <summary>
    /// 数据压缩类,数据长度大于50000，压缩才有意义
    /// </summary>
    public class Compress
    {
        #region 压缩
        /// <summary>
        /// 压缩流数据
        /// </summary>
        /// <param name="aSourceStream"></param>
        /// <returns></returns>
        public static byte[] EnCompress(Stream aSourceStream)
        {
            MemoryStream vMemory = new MemoryStream();

            aSourceStream.Seek(0, SeekOrigin.Begin);
            vMemory.Seek(0, SeekOrigin.Begin);
            try
            {
                using (GZipStream vZipStream = new GZipStream(vMemory, CompressionMode.Compress))
                {
                    byte[] vFileByte = new byte[1024];
                    int vRedLen = 0;
                    do
                    {
                        vRedLen = aSourceStream.Read(vFileByte, 0, vFileByte.Length);
                        vZipStream.Write(vFileByte, 0, vRedLen);
                    }
                    while (vRedLen > 0);
                }
            }
            finally
            {
                vMemory.Dispose();
            }
            return vMemory.ToArray();
        }
        /// <summary>
        /// 压缩数据
        /// </summary>
        /// <param name="aSourceStream"></param>
        /// <returns></returns>
        public static byte[] EnCompress(byte[] aSourceStream)
        {
            using (MemoryStream vMemory = new MemoryStream(aSourceStream))
            {
                return EnCompress(vMemory);
            }
        }
        #endregion

        #region 解压
        /// <summary>
        /// 解压数据
        /// </summary>
        /// <param name="aSourceStream"></param>
        /// <returns></returns>
        public static byte[] DeCompress(Stream aSourceStream)
        {
            byte[] vUnZipByte = null;
            GZipStream vUnZipStream;

            using (MemoryStream vMemory = new MemoryStream())
            {
                vUnZipStream = new GZipStream(aSourceStream, CompressionMode.Decompress);
                try
                {
                    byte[] vTempByte = new byte[1024];
                    int vRedLen = 0;
                    do
                    {
                        vRedLen = vUnZipStream.Read(vTempByte, 0, vTempByte.Length);
                        vMemory.Write(vTempByte, 0, vRedLen);
                    }
                    while (vRedLen > 0);
                    vUnZipStream.Close();
                }
                finally
                {
                    vUnZipStream.Dispose();
                }
                vUnZipByte = vMemory.ToArray();
            }
            return vUnZipByte;
        }
        /// <summary>
        /// 解压数据
        /// </summary>
        /// <param name="aSourceByte"></param>
        /// <returns></returns>
        public static byte[] DeCompress(byte[] aSourceByte)
        {
            using (MemoryStream vMemory = new MemoryStream(aSourceByte))
            {
                return DeCompress(vMemory);
            }
        }
        #endregion
    }
}
