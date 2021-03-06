//
// Tests for System.Web.UI.WebControls.Panel.cs 
//
// Author:
//     Ben Maurer <bmaurer@novell.com>
//     Yoni Klain <yonik@mainsoft.com>
//

//
// Copyright (C) 2005 Novell, Inc (http://www.novell.com)
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

using NUnit.Framework;
using System;
using System.IO;
using System.Globalization;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using MonoTests.stand_alone.WebHarness;
using MonoTests.SystemWeb.Framework;

namespace MonoTests.System.Web.UI.WebControls {
	[TestFixture]
	public class PanelTest
	{
		#region helpclasses
		class Poker : Panel {
			
			public string Render ()
			{
				StringWriter sw = new StringWriter ();
				sw.NewLine = "\n";
				HtmlTextWriter writer = new HtmlTextWriter (sw);
				base.Render (writer);
				return writer.InnerWriter.ToString ();
			}
		}
	
		class PokerS : Panel
		{
			public string Render ()
			{
				StringWriter sw = new StringWriter ();
				sw.NewLine = "\n";
				HtmlTextWriter writer = new HtmlTextWriter (sw);
				base.Render (writer);
				return writer.InnerWriter.ToString ();
			}
#if NET_2_0
			protected override Style CreateControlStyle ()
			{
				Style s = new Style (new StateBag ());
				s.BackColor = Color.Red;
				s.BorderColor = Color.Red;
				return s;
			}

			public override void RenderBeginTag (HtmlTextWriter writer)
			{
				base.RenderBeginTag (writer);
			}

			public override void RenderEndTag (HtmlTextWriter writer)
			{
				base.RenderEndTag (writer);
			}

			public  string RenderBeginTag ()
			{
				StringWriter sw = new StringWriter ();
				sw.NewLine = "\n";
				HtmlTextWriter writer = new HtmlTextWriter (sw);
				base.RenderBeginTag (writer);
				return writer.InnerWriter.ToString ();
			}

			public  string RenderEndTag ()
			{
				StringWriter sw = new StringWriter ();
				sw.NewLine = "\n";
				HtmlTextWriter writer = new HtmlTextWriter (sw);
				base.RenderBeginTag (writer);
				base.RenderEndTag (writer);
				return writer.InnerWriter.ToString ();
			}
#endif
		}

		class PokerR : Panel
		{
			public string Render ()
			{
				StringWriter sw = new StringWriter ();
				sw.NewLine = "\n";
				HtmlTextWriter writer = new HtmlTextWriter (sw);
				sw.Write ("Render");
				base.Render (writer);
				return writer.InnerWriter.ToString ();
			}
#if NET_2_0
			public override void RenderBeginTag (HtmlTextWriter writer)
			{
				writer.Write ("RenderBeginTag");
			}

			public override void RenderEndTag (HtmlTextWriter writer)
			{
				writer.Write ("RenderEndTag");
			}
#endif
		}
		#endregion
#if NET_2_0
		[TestFixtureSetUp]
		public void SetUp ()
		{
#if VISUAL_STUDIO
			WebTest.CopyResource (GetType (), "MonoTests.System.Web.UI.WebControls.Resources.NoEventValidation.aspx", "NoEventValidation.aspx");
#else
			WebTest.CopyResource (GetType (), "NoEventValidation.aspx", "NoEventValidation.aspx");
#endif
		}
#endif
		[Test]
		public void Defaults ()
		{
			Poker p = new Poker ();
#if NET_2_0
			Assert.AreEqual (ContentDirection.NotSet, p.Direction, "Direction"); 
			Assert.AreEqual (string.Empty, p.GroupingText, "GroupingText");
			Assert.AreEqual (ScrollBars.None, p.ScrollBars, "ScrollBars"); 
			Assert.AreEqual (string.Empty, p.DefaultButton, "DefaultButton");
#endif
		}
		
		[Test]
		public void NoWrap ()
		{
			Poker p = new Poker ();
			p.Wrap = false;
			p.Controls.Add (new LiteralControl ("TEXT"));
#if NET_2_0
			const string html ="<div style=\"white-space:nowrap;\">\n\tTEXT\n</div>";
#elif NET_1_1
			const string html ="<div nowrap=\"nowrap\">\n\tTEXT\n</div>";
#endif
			Assert.AreEqual (html, p.Render ());
		}

#if NET_2_0
		[Test]
		public void CreateControlStyle ()
		{
			PokerS p = new PokerS ();
			Style s = p.ControlStyle;
			Assert.AreEqual (Color.Red, s.BackColor, "CreateControlStyle#1");
			Assert.AreEqual (Color.Red, s.BorderColor, "CreateControlStyle#2");
			p.ApplyStyle (s);
			string html = p.Render ();
			HtmlDiff.AssertAreEqual ("<div style=\"background-color:Red;border-color:Red;\"></div>", html, "CreateControlStyle");
		}

		[Test]
		[Category ("NunitWeb")]
		public void DefaultButton ()
		{
			WebTest t = new WebTest ("NoEventValidation.aspx");
			t.Invoker = PageInvoker.CreateOnInit (DefaultButton__Init);
			t.Run ();
		}

		public static void DefaultButton__Init (Page p)
		{
			Poker pl = new Poker ();
			pl.DefaultButton = "MyButton";
			Button b = new Button ();
			b.ID = "MyButton";
			p.Form.Controls.Add (b);
			p.Form.Controls.Add (pl);
			string html = pl.Render ();
			if (html.IndexOf ("onkeypress") == -1)
				Assert.Fail ("Default button script not created #1");
			if (html.IndexOf ("MyButton") == -1)
				Assert.Fail ("Default button script not created #2");
		}
		
		[Test]
		[Category("NunitWeb")]
		[ExpectedException(typeof(InvalidOperationException))]
		public void DefaultButton_Exception ()
		{
			WebTest t = new WebTest ("NoEventValidation.aspx");
			t.Invoker = PageInvoker.CreateOnInit (DefaultButton_Init);
			t.Run ();

		}

		public static void DefaultButton_Init (Page p)
		{
			Poker pl = new Poker ();
			pl.DefaultButton = "test";
			p.Form.Controls.Add (pl);
			pl.Render ();

		}

		[Test]
		public void Direction ()
		{
			Poker p = new Poker ();
			p.Direction = ContentDirection.LeftToRight;
			string html = p.Render();
			HtmlDiff.AssertAreEqual ("<div dir=\"ltr\"></div>", html, "Direction");
		}

		[Test]
		public void GroupingText ()
		{
			Poker p = new Poker ();
			p.GroupingText = "MyNameText";
			string html = p.Render ();
			HtmlDiff.AssertAreEqual ("<div><fieldset><legend>MyNameText</legend></fieldset></div>", html, "GroupingText");

		}

		[Test]
		public void RenderBeginTag ()
		{
			PokerS p = new PokerS ();
			string html = p.RenderBeginTag ();
			HtmlDiff.AssertAreEqual ("<div>\n", html, "RenderBeginTag");
		}

		[Test]
		public void RenderEndTag ()
		{
			PokerS p = new PokerS ();
			string html = p.RenderEndTag ();
			HtmlDiff.AssertAreEqual ("<div>\n\n</div>", html, "RenderBeginTag");
		}

		[Test]
		public void RenderFlow ()
		{
			PokerR p = new PokerR ();
			string html = p.Render ();
			Assert.AreEqual ("RenderRenderBeginTagRenderEndTag", html, "RenderFlow");
		}

		[Test]
		public void Scroll_Bars ()
		{
			Poker p = new Poker ();
			p.ScrollBars = ScrollBars.Horizontal;
			string html = p.Render ();
			HtmlDiff.AssertAreEqual ("<div style=\"overflow-x:scroll;\"></div>", html, "ScrollBars.Horizontal");
			p.ScrollBars = ScrollBars.Vertical;
			html = p.Render ();
			HtmlDiff.AssertAreEqual ("<div style=\"overflow-y:scroll;\"></div>", html, "ScrollBars.Vertical");
			p.ScrollBars = ScrollBars.Both;
			html = p.Render ();
			HtmlDiff.AssertAreEqual ("<div style=\"overflow:scroll;\"></div>", html, "ScrollBars.Both");
		}

		[TestFixtureTearDown]
		public void TearDown ()
		{
			WebTest.Unload ();
		}
#endif
	}
}

		
