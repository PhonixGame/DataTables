using System;
using System.Buffers;
using System.IO;
using DataTables;

namespace ConsoleApp
{
    public enum CardType
    {
        HQCards,
    }

    class ByteBufferWriter : IBufferWriter<byte>
    {
        byte[] buffer;
        int index;

        public int CurrentOffset => index;
        public ReadOnlySpan<byte> WrittenSpan => buffer.AsSpan(0, index);
        public ReadOnlyMemory<byte> WrittenMemory => new ReadOnlyMemory<byte>(buffer, 0, index);

        public ByteBufferWriter()
        {
            buffer = new byte[1024];
            index = 0;
        }

        public void Advance(int count)
        {
            index += count;
        }

        public Memory<byte> GetMemory(int sizeHint = 0)
        {
            AGAIN:
            var nextSize = index + sizeHint;
            if (buffer.Length < nextSize)
            {
                Array.Resize(ref buffer, Math.Max(buffer.Length * 2, nextSize));
            }

            if (sizeHint == 0)
            {
                var result = new Memory<byte>(buffer, index, buffer.Length - index);
                if (result.Length == 0)
                {
                    sizeHint = 1024;
                    goto AGAIN;
                }
                return result;
            }
            else
            {
                return new Memory<byte>(buffer, index, sizeHint);
            }
        }

        public Span<byte> GetSpan(int sizeHint = 0)
        {
            return GetMemory(sizeHint).Span;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            var manager = new DataTableManager();

            var raw = File.ReadAllBytes("Generated\\card.bin");
            var card = manager.CreateDataTable<Card>("card", raw, 0, raw.Length);

            manager.HasDataTable<Card>();

        }

    }


}


