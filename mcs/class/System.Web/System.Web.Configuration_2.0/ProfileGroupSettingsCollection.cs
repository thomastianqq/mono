//
// System.Web.Configuration.ProfileGroupSettingsCollection
//
// Authors:
//	Chris Toshok (toshok@ximian.com)
//
// (C) 2005 Novell, Inc (http://www.novell.com)
//

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

#if NET_2_0

using System;
using System.Configuration;

namespace System.Web.Configuration
{
	[ConfigurationCollection (typeof (ProfileGroupSettings), AddItemName = "group", CollectionType = ConfigurationElementCollectionType.AddRemoveClearMap)]
	public sealed class ProfileGroupSettingsCollection : ConfigurationElementCollection
	{
		[MonoTODO]
		public ProfileGroupSettingsCollection ()
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public void Add (ProfileGroupSettings group)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public void Clear ()
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		protected override ConfigurationElement CreateNewElement ()
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public ProfileGroupSettings Get (int index)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public ProfileGroupSettings Get (string name)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		protected override object GetElementKey (ConfigurationElement element)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public string GetKey (int index)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public int IndexOf (ProfileGroupSettings group)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		protected override bool IsModified ()
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public void Remove (string name)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public void RemoveAt (int index)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		protected override void ResetModified ()
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public void Set (ProfileGroupSettings group)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public string[ ] AllKeys {
			get {
				throw new NotImplementedException ();
			}
		}

		[MonoTODO]
		protected override ConfigurationPropertyCollection Properties {
			get {
				throw new NotImplementedException ();
			}
		}

		[MonoTODO]
		public ProfileGroupSettings this[int index] {
			get {
				throw new NotImplementedException ();
			}
			set {
				throw new NotImplementedException ();
			}
		}

		[MonoTODO]
		public new ProfileGroupSettings this[string name] {
			get {
				throw new NotImplementedException ();
			}
		}

	}

}

#endif
