using System;
using System.ComponentModel;
using System.Web.UI;

using JsonFx.Json;

namespace JsonFx.UI.Jbst
{
	[ToolboxData("<{0}:Control runat=\"server\"></{0}:Control>")]
	public class Control : System.Web.UI.Control
	{
		#region Fields

		private string name;
		private string data;
		private string index;

		#endregion Fields

		#region Properties

		public virtual string Name
		{
			get { return this.name; }
			set { this.name = value; }
		}

		public virtual string Data
		{
			get { return this.data; }
			set { this.data = value; }
		}

		public virtual string Index
		{
			get { return this.index; }
			set { this.index = value; }
		}

		#endregion Properties

		#region Page Event Handlers

		protected override void Render(HtmlTextWriter writer)
		{
			if (String.IsNullOrEmpty(this.Name))
			{
				throw new ArgumentNullException("jbst:Control Name cannot be empty.");
			}

			string hook = Guid.NewGuid().ToString("N");

			// render the placeholder hook
			writer.Write("<div class=\"");
			writer.Write(hook);
			writer.Write("\">");

			// render out any children as temp
			base.RenderChildren(writer);

			writer.Write("</div>");

			// render the binding script
			writer.Write("<script type=\"text/javascript\">JsonFx.Bindings.register(\"div\",\"");
			writer.Write(hook);
			writer.Write("\",function(elem){return JsonFx.UI.bind((");
			writer.Write(this.Name);
			writer.Write("),(");
			if (String.IsNullOrEmpty(this.Data))
			{
				writer.Write("{}");
			}
			else
			{
				writer.Write(this.Data);
			}
			writer.Write("))||elem;},null);</script>");
		}

		#endregion Page Event Handlers
	}
}
