using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace ExchangeRate.Persistence.Repository.Base
{
    public abstract class BaseFileRepository
    {
        private static Mutex mutex = new Mutex();
        protected void WriteToBinaryFile<T>(string filePath, T objectToWrite, bool append = false)
        {
            if (mutex.WaitOne())
            {
                try
                {
                    using (Stream stream = File.Open(filePath, append ? FileMode.Append : FileMode.Create))
                    {
                        var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                        stream.Position = 0;
                        binaryFormatter.Serialize(stream, objectToWrite);
                    }

                }
                finally
                {
                    mutex.ReleaseMutex();
                }

            }
        }

        protected T ReadFromBinaryFile<T>(string filePath)
        {
            if (mutex.WaitOne())
            {
                try
                {
                    using (Stream stream = File.Open(filePath, FileMode.Open))
                    {
                        var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                        stream.Position = 0;
                        return (T)binaryFormatter.Deserialize(stream);
                    }

                }
                finally
                {
                    mutex.ReleaseMutex();
                }
            }
            return default(T);
        }
    }
}
