using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoriaiLib
{
    public enum MessageFormat
    {
        Format8bit = 1,
        Format16bit = 1 << 1,
        Format32bit = 1 << 2,
    }

    public enum Commands
    {
        SendOne = 0x01,
        SendMany = 0x02,
        ReadOne = 0x03,
        ReadMany = 0x04
    }

    public class MoriaiClass
    {
        private MessageFormat mFormat;
        public MoriaiClass(MessageFormat mf = MessageFormat.Format8bit)
        {
            mFormat = mf;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public byte[] SendOne(int data)
        {
            byte[] stream = null;
            try
            {
                switch (mFormat)
                {
                    case MessageFormat.Format8bit:
                        {
                            stream = new byte[3];
                            stream[2] = (byte)data;
                        }
                        break;
                    case MessageFormat.Format16bit:
                        {
                            stream = new byte[4];
                            byte[] d = BitConverter.GetBytes(data);
                            stream[2] = d[0];
                            stream[3] = d[1];
                        }
                        break;
                    case MessageFormat.Format32bit:
                        {
                            stream = new byte[6];
                            byte[] d = BitConverter.GetBytes(data);
                            stream[2] = d[0];
                            stream[3] = d[1];
                            stream[4] = d[2];
                            stream[5] = d[3];
                        }
                        break;
                    default:
                        stream = null;
                        break;
                }
                if (stream != null)
                {
                    stream[0] = (byte)Commands.SendOne;
                    stream[1] = (byte)mFormat;
                }
            }
            catch (Exception ex)
            {
                stream = null;
            }
            return stream;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public byte[] SendMany(int[] data)
        {
            byte[] stream = null;
            try
            {
                switch (mFormat)
                {
                    case MessageFormat.Format8bit:
                        {
                            stream = new byte[3 + data.Length];
                            stream[2] = (byte)data.Length;
                            for (int i = 0; i < data.Length; i++)
                            {
                                stream[3 + i] = (byte)data[i];
                            }
                        }
                        break;
                    case MessageFormat.Format16bit:
                        {
                            stream = new byte[3 + data.Length * 2];
                            stream[2] = (byte)data.Length;
                            for (int i = 0; i < data.Length; i++)
                            {
                                byte[] d = BitConverter.GetBytes(data[i]);
                                stream[3 + i * 2] = d[0];
                                stream[4 + i * 2] = d[1];

                            }
                        }
                        break;
                    case MessageFormat.Format32bit:
                        {
                            stream = new byte[3 + data.Length * 4];
                            stream[2] = (byte)data.Length;
                            for (int i = 0; i < data.Length; i++)
                            {
                                byte[] d = BitConverter.GetBytes(data[i]);
                                stream[3 + i * 4] = d[0];
                                stream[4 + i * 4] = d[1];
                                stream[5 + i * 4] = d[2];
                                stream[6 + i * 4] = d[3];
                            }
                        }
                        break;
                    default:
                        stream = null;
                        break;
                }
                if (stream != null)
                {
                    stream[0] = (byte)Commands.SendOne;
                    stream[1] = (byte)mFormat;
                }
            }
            catch (Exception ex)
            {
                stream = null;
            }
            return stream;
        }

    }
}
