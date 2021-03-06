// TypeToken.cs
//
// (C) 2001 Ximian, Inc.  http://www.ximian.com

//
// Copyright (C) 2004 Novell, Inc (http://www.novell.com)
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

using System.Runtime.InteropServices;

namespace System.Reflection.Emit {


	/// <summary>
	///  Represents the Token returned by the metadata to represent a Type.
	/// </summary>
	[Serializable]
#if NET_2_0
	[ComVisible (true)]
#endif
	public struct TypeToken {

		internal int tokValue;

		public static readonly TypeToken Empty;


		static TypeToken ()
		{
			Empty = new TypeToken ();
		}


		internal TypeToken (int val)
		{
			tokValue = val;
		}

		/// <summary>
		/// </summary>
		public override bool Equals (object obj)
		{
			bool res = obj is TypeToken;

			if (res) {
				TypeToken that = (TypeToken) obj;
				res = (this.tokValue == that.tokValue);
			}

			return res;
		}

#if NET_2_0
		public bool Equals (TypeToken obj)
		{
			return (this.tokValue == obj.tokValue);
		}

		public static bool operator == (TypeToken a, TypeToken b)
		{
			return Equals (a, b);
		}

		public static bool operator != (TypeToken a, TypeToken b)
		{
			return !Equals (a, b);
		}
#endif

		/// <summary>
		///  Tests whether the given object is an instance of
		///  TypeToken and has the same token value.
		/// </summary>
		public override int GetHashCode ()
		{
			return tokValue;
		}


		/// <summary>
		///  Returns the metadata token for this Type.
		/// </summary>
		public int Token {
			get {
				return tokValue;
			}
		}

	}

}

