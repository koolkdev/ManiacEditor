using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ManiacEditor
{
    // NOTE: This class is incomplete 
    public class ProcessMemory
    {
        // Handle used to Read or Write to
        public IntPtr ProcessHandle;

        public ProcessMemory(Process process) : this(process.Handle) { }

        public ProcessMemory(IntPtr processHandle)
        {
            ProcessHandle = processHandle;
        }

        public ProcessMemory()
        {
        }

        public void Attach(Process process)
        { Attach(process.Handle); }
        public void Attach(IntPtr processHandle)
        { ProcessHandle = processHandle; }


        private byte[] Read(int Address, int Length)
        {
            byte[] Buffer = new byte[Length];
            IntPtr Zero = IntPtr.Zero;
            ReadProcessMemory(ProcessHandle, (IntPtr)Address, Buffer, (UInt32)Buffer.Length, out Zero);
            return Buffer;
        }

        private void Write(int address, byte[] bytes)
        {
            IntPtr Zero = IntPtr.Zero;
            WriteProcessMemory(ProcessHandle, (IntPtr)address, bytes, (UInt32)bytes.Length, out Zero);
        }


        // Writing Methods
        // 1 Byte
        public void WriteByte(int address, byte value)
        {
            Write(address, new byte[] { value });
        }

        // 2 Bytes
        public void WriteInt16(int address, short value)
        {
            Write(address, BitConverter.GetBytes(value));
        }

        // Reading Methods
        // 1 Byte
        public byte ReadByte(int address)
        {
            return Read(address, 1)[0];
        }


        // Other Types
        public void WriteString(int address, string text)
        {
            byte[] Buffer = Encoding.ASCII.GetBytes(text);
            IntPtr Zero = IntPtr.Zero;
            WriteProcessMemory(ProcessHandle, (IntPtr)address, Buffer, (UInt32)Buffer.Length, out Zero);
        }

        public void WriteBytes(int address, byte[] bytes)
        {
            IntPtr Zero = IntPtr.Zero;
            WriteProcessMemory(ProcessHandle, (IntPtr)address, bytes, (uint)bytes.Length, out Zero);
        }


        // P/Invokes
        [DllImport("kernel32.dll")]
        private static extern Int32 ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [In, Out] byte[] buffer, UInt32 size, out IntPtr lpNumberOfBytesWritten);
        [DllImport("kernel32.dll")]
        private static extern Int32 WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [In, Out] byte[] buffer, UInt32 size, out IntPtr lpNumberOfBytesWritten);


    }
}
