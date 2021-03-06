#region License
/* 
 *
 * Open3270 - A C# implementation of the TN3270/TN3270E protocol
 *
 * Copyright (c) 2004-2020 Michael Warriner
 * Modifications (c) as per Git change history
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy of this software
 * and associated documentation files (the "Software"), to deal in the Software without restriction,
 * including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense,
 * and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so,
 * subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all copies or substantial 
 * portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT 
 * LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. 
 * IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, 
 * WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE 
 * SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 */
 
#endregion
using System;

namespace Open3270.Library
{
	internal class ByteHandler
	{
		static public int ToBytes(byte[] buffer, int offset, int data)
		{
			buffer[offset++] = (byte)(data & 0xff);
			buffer[offset++] = (byte)((data & 0xff00) / 0x100);
			buffer[offset++] = (byte)((data & 0xff0000) / 0x10000);
			buffer[offset++] = (byte)((data & 0xff000000) / 0x1000000);
			return offset;
		}
		static public int FromBytes(byte[] buffer, int offset, out int data)
		{
			data = 0;
			data = (int)(buffer[offset++]);
			data += (int)(buffer[offset++] * 0x100);
			data += (int)(buffer[offset++] * 0x10000);
			data += (int)(buffer[offset++] * 0x1000000);
			return offset;
		}
	}
}
