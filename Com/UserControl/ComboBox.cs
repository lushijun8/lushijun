using System;
using System.Xml;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.Text;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;

namespace Com.UserControl
{
	#region ComboBox
	/// <summary>
	/// 
	/// </summary>
	[
	Designer(typeof(ComboBoxDesigner)),
	ValidationProperty("Text"),
	]
	public class ComboBox : System.Web.UI.WebControls.ListControl, IPostBackDataHandler, INamingContainer 
	{

		/// <summary>
		/// Creates a new instance of the ComboBox control.
		/// </summary>
		public ComboBox() : base() {}
        
		#region Events
		/// <summary>
		/// The event which occurs when the <see cref="Text"/> property is changed.
		/// </summary>
		public event EventHandler TextChanged;
		/// <summary>
		/// Raises the <see cref="TextChanged"/> event.
		/// </summary>
		/// <param name="e">The data for the event.</param>
		protected virtual void OnTextChanged( EventArgs e ) 
		{
			if ( TextChanged != null ) 
			{
				TextChanged( this, e );
			}
		}
		#endregion

		#region Implementation of IPostBackDataHandler
		void IPostBackDataHandler.RaisePostDataChangedEvent() 
		{
			OnSelectedIndexChanged(System.EventArgs.Empty);
		}

		bool IPostBackDataHandler.LoadPostData(string postDataKey, System.Collections.Specialized.NameValueCollection postCollection) 
		{
			// No need to check for the text portion changing. That is handled automagically

			bool listIndexChanged = false;
		    
			if( TextIsInList ) 
			{
		        
				ListItem selectedItem = this.Items.FindByText(text.Text);
				Int32 selectedIndex = Items.IndexOf( selectedItem );
	            
				if ( this.SelectedIndex != selectedIndex ) 
				{
					listIndexChanged = true;
					this.SelectedIndex = selectedIndex;
				}
			} 
			else 
			{
				if ( this.SelectedIndex != -1  ) 
				{
					listIndexChanged = true;
					this.SelectedIndex = -1;
				}
			}
			isLoaded = true;
			return listIndexChanged;
		}
		#endregion
        
		#region New Properties
		/// <summary>
		/// Gets or sets the number of rows displayed in the dropdown portion of the <see cref="ComboBox"/> control.
		/// </summary>
		/// <value>
		/// The number of rows displayed in the <see cref="ComboBox"/> control. The default value is 4.
		/// </value>
		[
		Description("Gets or sets the number of rows of the dropdown portion of the ComboBox control."),
		Category("Appearance"),
		DefaultValue(4),
		Bindable(true),
		]
		public virtual Int32 Rows 
		{
			get 
			{
				object savedRows;

				savedRows = this.ViewState["Rows"];
				if (savedRows != null)
					return (Int32) savedRows;
				return 4;
			}
			set 
			{
				if ( value < 1 ) 
				{
					throw new ArgumentOutOfRangeException();
				}
				this.ViewState["Rows"] = value;
			}

		}

		/// <summary>
		/// Gets or sets the text content of the text box portion of the <see cref="ComboBox"/> control.
		/// </summary>
		[
		Description("Gets or sets the text content of the text box portion of the ComboBox control."),
		Category("Appearance"),
		Bindable(true),
		DefaultValue("")
		]
		public virtual String Text 
		{
			get 
			{
				this.EnsureChildControls();
				if ( text.Text == null ) 
				{
					return String.Empty;
				}
				return text.Text;
			}
			set 
			{
				this.EnsureChildControls();
				text.Text = value;
			}
		}

		/// <summary>
		/// Gets a boolean value indicating whether the string in the text portion of the <see cref="ComboBox"/>
		/// can be found in the text property of any of the ListItems in the Items collection.
		/// </summary>
		[
		Browsable(false),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)
		]
		public virtual bool TextIsInList 
		{
			get 
			{
				this.EnsureChildControls();
				return ( Items.FindByText( text.Text ) != null );
			}
		}
	    
		/// <summary>
		/// Gets a boolean value indicating whether an external script library should be used,
		/// instead of the library being emitted as a whole.
		/// </summary>
		protected virtual bool UseReferenceLibrary 
		{
			get 
			{
				return ( ReferenceLibraryUrl != String.Empty );
			}
		}
	    
		/// <summary>
		/// Queries the web.config file to get the external reference script library path, if available.
		/// </summary>
		protected virtual String ReferenceLibraryUrl 
		{
			get 
			{
				NameValueCollection config = ConfigurationSettings.GetConfig("MetaBuilders.WebControls.ComboBox") as NameValueCollection;
				if( config != null ) 
				{
					return config["ReferenceLibraryUrl"];
				}
				return String.Empty;
			}
		}
	    

		#endregion

		#region Hidden Base Properties
		/// <summary>
		/// Hides the BorderColor property, as it not relevant on this control.
		/// </summary>
		[
		EditorBrowsableAttribute(EditorBrowsableState.Never),
		BindableAttribute(BindableSupport.No),
		BrowsableAttribute(false),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)
		]
		public override System.Drawing.Color BorderColor 
		{
			get 
			{
				return base.BorderColor;
			}
			set 
			{
				
			}
		}

		/// <summary>
		/// Hides the BorderStyle property, as it not relevant on this control.
		/// </summary>
		[
		EditorBrowsableAttribute(EditorBrowsableState.Never),
		BindableAttribute(BindableSupport.No),
		BrowsableAttribute(false),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)
		]
		public override System.Web.UI.WebControls.BorderStyle BorderStyle 
		{
			get 
			{
				return base.BorderStyle;
			}
			set 
			{
				
			}
		}

		/// <summary>
		/// Hides the BorderWidth property, as it not relevant on this control.
		/// </summary>
		[
		EditorBrowsableAttribute(EditorBrowsableState.Never),
		BindableAttribute(BindableSupport.No),
		BrowsableAttribute(false),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)
		]
		public override System.Web.UI.WebControls.Unit BorderWidth 
		{
			get 
			{
				return base.BorderWidth;
			}
			set 
			{
				
			}
		}

		/// <summary>
		/// Hides the ToolTip property, as it not relevant on this control.
		/// </summary>
		[
		EditorBrowsableAttribute(EditorBrowsableState.Never),
		BindableAttribute(BindableSupport.No),
		BrowsableAttribute(false),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)
		]
		public override string ToolTip 
		{
			get 
			{
				return base.ToolTip;
			}
			set 
			{
				
			}
		}

		/// <summary>
		/// Hides the Height property, as it not relevant on this control.
		/// </summary>
		[
		EditorBrowsableAttribute(EditorBrowsableState.Never),
		BindableAttribute(BindableSupport.No),
		BrowsableAttribute(false),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)
		]
		public override Unit Height 
		{
			get 
			{
				return Unit.Empty;
			}
			set 
			{
				base.Height = Unit.Empty;
			}
		}
		#endregion

		
		#region Render Overrides
		/// <summary>
		/// Overrides the LoadViewState method.
		/// </summary>
		protected override void LoadViewState(object savedState) 
		{
			base.LoadViewState(savedState);
			if ( this.ViewState["-1Saved"] != null && (Boolean)this.ViewState["-1Saved"] ) 
			{ // not really sure why I have to do this
				this.SelectedIndex = -1;
			}
		}

		/// <summary>
		/// Overrides the CreateChildControls method.
		/// </summary>
		protected override void CreateChildControls() 
		{
			container = new WebControl();
			container.ID = "Container";
			this.Controls.Add( container );
            
			text = new TextBox();
			text.ID = "Text";
			text.Attributes["autocomplete"] = "off";
			container.Controls.Add( text );
			text.TextChanged += new EventHandler( this.raiseTextChanged );
            
			button = new WebControl();
			button.ID = "Button";
			container.Controls.Add( button );
		}

		/// <summary>
		/// Overrides the OnPreRender method.
		/// </summary>
		protected override void OnPreRender(System.EventArgs e) 
		{

			base.OnPreRender(e);

			if( this.AutoPostBack ) 
			{
				this.AutoPostBack = false;
				this.text.AutoPostBack = true;
			}
		    
			if( !Page.IsClientScriptBlockRegistered( "MetaBuilders.WebControls.ComboBox Library" ) ) 
			{
				if( UseReferenceLibrary ) 
				{
					Page.RegisterClientScriptBlock( "MetaBuilders.WebControls.ComboBox Library", "<script language=\"javascript\" src=\"" + ResolveUrl( ReferenceLibraryUrl ) + "\"></script>" );
				} 
				else 
				{
					//					ResourceManager manager = new ResourceManager( this.GetType() );
					//					String script = manager.GetResourceSet(System.Globalization.CultureInfo.CurrentCulture, true, true).GetString("ClientScript");
					//					ResourceManager manager = new ResourceManager( this.GetType() );
					String script = "<script language=\"javascript\">\n"+
						"<!--\n"+
						"function ComboBox_Init() {\n"+
						"if ( ComboBox_UplevelBrowser() ) {\n"+
						"for( var i = 0; i < ComboBoxes.length; i++ ) {\n"+
						"ComboBox_Load( ComboBoxes[i] );\n"+
						"}\n"+
						"}\n"+
						"}\n"+
						"function ComboBox_UplevelBrowser() {\n"+
						"if( typeof( document.getElementById ) == \"undefined\" ) return false;\n"+
						"var combo = document.getElementById( ComboBoxes[0] + \"_Container\" );\n"+
						"if( combo == null || typeof( combo ) == \"undefined\" ) return false;\n"+
						"if( typeof( combo.style ) == \"undefined\" ) return false;\n"+
						"if( typeof( combo.innerHTML ) == \"undefined\" ) return false;\n"+
						"return true;\n"+
						"}\n"+
						"function ComboBox_Load( comboId ) {\n"+
						"var combo  = document.getElementById( comboId + \"_Container\" );\n"+
						"var button = document.getElementById( comboId + \"_Button\" );\n"+
						"var list   = document.getElementById( comboId );\n"+
						"var text   = document.getElementById( comboId + \"_Text\" );\n"+

						"combo.List = list;\n"+
						"combo.Button = button;\n"+
						"combo.Text = text;\n"+
						"combo.style.border = \"2px inset ButtonFace\";\n"+
						"combo.style.padding = \"0px\";\n"+
						"combo.style.margin = \"0px\";\n"+
      
						"button.Container = combo;\n"+
						"button.Toggle = ComboBox_ToggleList;\n"+
						"button.onclick = button.Toggle;\n"+
						"button.onmouseover = function(e) { this.Container.List.DisableBlur(e); };\n"+
						"button.onmouseout = function(e) { this.Container.List.EnableBlur(e); };\n"+
						"button.style.padding = \"0px\";\n"+
						"button.style.margin = \"0px\";\n"+
						"button.style.background = \"ButtonFace\";\n"+
						"button.style.color = \"ButtonText\";\n"+
						"button.style.borderLeft = \"1px outset ButtonFace\";\n"+
						"button.style.cursor = \"default\";\n"+
						"button.style.fontFamily = \"webdings\";\n"+
						"button.style.fontSize = \"8pt\";\n"+
						"button.innerHTML = \"6\";\n"+
						"button.onselectstart = function(e){ return false; };\n"+
						   
						"text.Container = combo;\n"+
						"text.TypeDown = ComboBox_TextTypeDown;\n"+
						"text.KeyAccess = ComboBox_TextKeyAccess;\n"+
						"text.onkeyup = function(e) { this.KeyAccess(e); this.TypeDown(e); };\n"+
						"text.style.border = \"none\";\n"+
						"text.style.margin = \"0px\";\n"+
						"text.style.padding = \"0px\";\n"+
						"text.style.width = ( list.offsetWidth ) + \"px\";\n"+
					    
						"list.Container = combo;\n"+
						"list.Show = ComboBox_ShowList;\n"+
						"list.Hide = ComboBox_HideList;\n"+
						"list.EnableBlur = ComboBox_ListEnableBlur;\n"+
						"list.DisableBlur = ComboBox_ListDisableBlur;\n"+
						"list.Select = ComboBox_ListItemSelect;\n"+
						"list.ClearSelection = ComboBox_ListClearSelection;\n"+
						"list.KeyAccess = ComboBox_ListKeyAccess;\n"+
						"list.FireTextChange = ComboBox_ListFireTextChange;\n"+
						"list.onchange = null;\n"+
						"list.onclick = function(e){ this.Select(e); this.ClearSelection(); this.FireTextChange(); };\n"+
						"list.onkeyup = function(e) { this.KeyAccess(e); };\n"+
						"list.EnableBlur(null);\n"+
						"list.style.position = \"absolute\";\n"+
						"list.style.zIndex = 200;\n"+
						"list.size = ComboBox_GetListSize( list );\n"+
						"list.IsShowing = true;\n"+
						"list.Hide();\n"+
        
						"}\n"+
						"function ComboBox_InitEvent( e ) {\n"+
						"if( typeof( e ) == \"undefined\" && typeof( window.event ) != \"undefined\" ) e = window.event;\n"+
						"if( e == null ) e = new Object();\n"+
						"return e;\n"+
						"}\n"+
						"function ComboBox_ListClearSelection() {\n"+
						"if ( typeof( this.Container.Text.createTextRange ) == \"undefined\" ) return;\n"+
						"var rNew = this.Container.Text.createTextRange();\n"+
						"rNew.moveStart('character', this.Container.Text.value.length) ;\n"+
						"rNew.select();\n"+
						"}\n"+
						"function ComboBox_GetListSize( theList ) {\n"+
						"ComboBox_EnsureListSize( theList );\n"+
						"return theList.listSize;\n"+
						"}\n"+
						"function ComboBox_EnsureListSize( theList ) {\n"+
						"if ( typeof( theList.listSize ) == \"undefined\" ) {\n"+
						"if( typeof( theList.getAttribute ) != \"undefined\" ) {\n"+
						"if( theList.getAttribute( \"listSize\" ) != null && theList.getAttribute( \"listSize\" ) != \"\" ) {\n"+
						"theList.listSize = theList.getAttribute( \"listSize\" );\n"+
						"return;\n"+
						"}\n"+
						"}\n"+
						"if( theList.options.length > 0 ) {\n"+
						"theList.listSize = theList.options.length;\n"+
						"return;\n"+
						"}\n"+
						"theList.listSize = 4;\n"+
						"}\n"+
						"}\n"+
						"function ComboBox_ListKeyAccess(e) {\n"+ 
						"e = ComboBox_InitEvent( e );\n"+
						"if( e.keyCode == 13 || e.keyCode == 32 ) {\n"+
						"this.Select();\n"+
						"return;\n"+
						"}\n"+
						"if( e.keyCode == 27 ) {\n"+
						"this.Hide();\n"+
						"this.Container.Text.focus();\n"+
						"return;\n"+
						"}\n"+
						"}\n"+
						"function ComboBox_TextKeyAccess(e) {\n"+
						"e = ComboBox_InitEvent( e );\n"+
						"if( e.altKey && (e.keyCode == 38 || e.keyCode == 40) ) {\n"+
						"this.Container.List.Show();\n"+
						"}\n"+
						"}\n"+
						"function ComboBox_TextTypeDown(e) { \n"+
						"e = ComboBox_InitEvent( e );\n"+
						"var items = this.Container.List.options;\n"+
						"if( this.value == \"\" ) return;\n"+
						"var ctrlKeys = Array( 8, 46, 37, 38, 39, 40, 33, 34, 35, 36, 45, 16, 20 );\n"+
						"for( var i = 0; i < ctrlKeys.length; i++ ) {\n"+
						"if( e.keyCode == ctrlKeys[i] ) return;\n"+
						"}\n"+
						"for( var i = 0; i < items.length; i++ ) {\n"+
						"var item = items[i];\n"+
						"if( item.text.toLowerCase().indexOf( this.value.toLowerCase() ) == 0 ) {\n"+
						"this.Container.List.selectedIndex = i;\n"+
						"if ( typeof( this.Container.Text.createTextRange ) != \"undefined\" ) {\n"+
						"this.Container.List.Select();\n"+
						"}\n"+
						"break;\n"+
						"}\n"+
						"}\n"+
						"}\n"+
						"function ComboBox_ListFireTextChange() {\n"+
						"var textOnChange = this.Container.Text.onchange;\n"+
						"if ( textOnChange != null && typeof(textOnChange) == \"function\" ) {\n"+
						"textOnChange();\n"+
						"}\n"+
						"}\n"+
						"function ComboBox_ListEnableBlur(e) {\n"+
						"this.onblur = this.Hide;\n"+
						"}\n"+
						"function ComboBox_ListDisableBlur(e) {\n"+
						"this.onblur = null;\n"+
						"}\n"+
						"function ComboBox_ListItemSelect(e) {\n"+
						"if( this.options.length > 0 ) {\n"+
						"var text = this.Container.Text;\n"+
						"var oldValue = text.value;\n"+
						"var newValue = this.options[ this.selectedIndex ].text;\n"+
						"text.value = newValue;\n"+
						"if ( typeof( text.createTextRange ) != \"undefined\" ) {\n"+
						"if (newValue != oldValue) {\n"+
						"var rNew = text.createTextRange();\n"+
						"rNew.moveStart('character', oldValue.length) ;\n"+
						"rNew.select();\n"+
						"}\n"+
						"}\n"+
						"}\n"+
						"this.Hide();\n"+
						"this.Container.Text.focus();\n"+
						"}\n"+
						"function ComboBox_ToggleList(e) {\n"+
						"if( this.Container.List.IsShowing == true ) {\n"+
						"this.Container.List.Hide();\n"+
						"} else {\n"+
						"this.Container.List.Show();\n"+
						"}\n"+
						"}\n"+
						"function ComboBox_ShowList(e) {\n"+
						"if ( !this.IsShowing && !this.disabled ) {\n"+
						"this.style.width = ( this.Container.offsetWidth ) + \"px\";\n"+
						"this.style.top = ( this.Container.offsetHeight + ComboBox_RecursiveOffsetTop(this.Container,true) ) + \"px\";\n"+
						"this.style.left = ( ComboBox_RecursiveOffsetLeft(this.Container,true) ) + \"px\";\n"+
						"ComboBox_SetVisibility(this,true);\n"+
						"this.focus();\n"+
						"this.IsShowing = true;\n"+
						"}\n"+
						"}\n"+
						"function ComboBox_HideList(e) {\n"+
						"if( this.IsShowing ) {\n"+
						"ComboBox_SetVisibility(this,false);\n"+
						"this.IsShowing = false;\n"+
						"}\n"+
						"}\n"+
						"function ComboBox_SetVisibility(theList,isVisible) {\n"+
						"var isIE = ( typeof( theList.dataSrc ) != \"undefined\" ); \n"+
						"if ( isIE ) {\n"+
						"if ( isVisible ) {\n"+
						"theList.style.visibility = \"visible\";\n"+
						"} else {\n"+
						"theList.style.visibility = \"hidden\";\n"+
						"}\n"+
						"} else { \n"+
						"if ( isVisible ) {\n"+
						"theList.style.display = \"block\";\n"+
						"} else {\n"+
						"theList.style.display = \"none\";\n"+
						"}\n"+
						"}\n"+
						"}\n"+
						"function ComboBox_RecursiveOffsetTop(thisObject,isFirst) {\n"+
						"if(thisObject.offsetParent) {\n"+
						"if ( thisObject.style.position == \"absolute\" && !isFirst && typeof(document.designMode) != \"undefined\" ) {\n"+
						"return 0;\n"+
						"}\n"+
						"return (thisObject.offsetTop + ComboBox_RecursiveOffsetTop(thisObject.offsetParent,false));\n"+
						"} else {\n"+
						"return thisObject.offsetTop;\n"+
						"}\n"+
						"}\n"+
						"function ComboBox_RecursiveOffsetLeft(thisObject,isFirst) {\n"+
						"if(thisObject.offsetParent) {\n"+
						"if ( thisObject.style.position == \"absolute\" && !isFirst && typeof(document.designMode) != \"undefined\" ) {\n"+
						"return 0;\n"+
						"}\n"+
						"return (thisObject.offsetLeft + ComboBox_RecursiveOffsetLeft(thisObject.offsetParent,false));\n"+
						"} else {\n"+
						"return thisObject.offsetLeft;\n"+
						"}\n"+
						"}\n"+
						"function ComboBox_SimpleAttach(selectElement,textElement) {\n"+
						"textElement.value = selectElement.options[ selectElement.options.selectedIndex ].text;\n"+
						"var textOnChange = textElement.onchange;\n"+
						"if ( textOnChange != null && typeof( textOnChange ) == \"function\" ) {\n"+
						"textOnChange();\n"+
						"}\n"+
						"}\n"+
						"//-->\n"+
						"</script>";
					this.Page.RegisterClientScriptBlock("MetaBuilders.WebControls.ComboBox Library", script );
				}
			}
            
			if( !Page.IsStartupScriptRegistered( "MetaBuilders.WebControls.ComboBox Init" ) ) 
			{
				Page.RegisterStartupScript( "MetaBuilders.WebControls.ComboBox Init", "<script language=\"javascript\">\n<!--\nComboBox_Init();\n//-->\n</script>" );
			}
            
			Page.RegisterArrayDeclaration( "ComboBoxes", "'" + this.ClientID + "'" );

		}

		/// <summary>
		/// Overrides the AddAttributesToRender method.
		/// </summary>
		protected override void AddAttributesToRender( HtmlTextWriter writer ) 
		{

			if (this.Page != null) 
			{
				this.Page.VerifyRenderingInServerForm(this);
			}

			writer.AddAttribute(HtmlTextWriterAttribute.Name, this.UniqueID);
			writer.AddAttribute( HtmlTextWriterAttribute.Onchange, "ComboBox_SimpleAttach(this, this.form['" + this.text.UniqueID + "']); " );
			writer.AddAttribute( "listSize", this.Rows.ToString() );

			base.AddAttributesToRender(writer);
		}
        
		/// <summary>
		/// Overrides the Render method.
		/// </summary>
		protected override void Render( HtmlTextWriter writer ) 
		{
			this.EnsureChildControls();
			this.TextControl.ControlStyle.CopyFrom(this.ControlStyle);
			this.ContainerControl.ControlStyle.CopyFrom(this.ControlStyle);

			this.TextControl.Enabled = this.Enabled;
			this.ContainerControl.Style["POSITION"] = this.Style["POSITION"];
			this.ContainerControl.Style["TOP"] = this.Style["TOP"];
			this.ContainerControl.Style["LEFT"] = this.Style["LEFT"];
			this.ContainerControl.Style["Z-INDEX"] = this.Style["Z-INDEX"];

			base.Render( getCorrectTagWriter( writer )  );
		}
		
		/// <summary>
		/// Overrides the RenderBeginTag method.
		/// </summary>
		public override void RenderBeginTag(System.Web.UI.HtmlTextWriter writer) 
		{
			container.RenderControl( writer );
			base.RenderBeginTag( writer );
		}
		
		/// <summary>
		/// Overrides the RenderContents method.
		/// </summary>
		protected override void RenderContents(System.Web.UI.HtmlTextWriter writer) 
		{
			Boolean oneSelected = false;

			foreach( ListItem item in this.Items ) 
			{
				writer.WriteBeginTag("option");
				if ( item.Selected ) 
				{
					if ( !oneSelected ) 
					{
						writer.WriteAttribute( "selected", "selected", false );
					}
					oneSelected = true;
				}

				writer.WriteAttribute( "value", item.Value, true );
				writer.Write(">");
				HttpUtility.HtmlEncode(item.Text, writer );
				writer.WriteEndTag("option");
				writer.WriteLine();
			}

		}

		/// <summary>
		/// Overrides the SaveViewState method.
		/// </summary>
		protected override object SaveViewState() 
		{
			this.ViewState["-1Saved"] = ( this.SelectedIndex == -1 ); // not really sure why I have to do this
			return  base.SaveViewState();
		}

		#endregion
		
		#region Util
		private HtmlTextWriter getCorrectTagWriter( HtmlTextWriter writer ) 
		{

			HtmlTextWriter tagWriter = writer;

			if ( writer is System.Web.UI.Html32TextWriter ) 
			{
				HttpBrowserCapabilities browser = this.Page.Request.Browser;
				if( browser.W3CDomVersion.Major > 0 ) 
				{
					tagWriter =  new HtmlTextWriter( writer.InnerWriter );
				} 
				else if ( String.Compare( browser.Browser, "netscape", true ) == 0 ) 
				{
					if ( browser.MajorVersion >= 5 ) 
					{
						tagWriter = new HtmlTextWriter( writer.InnerWriter );
					}
				}
			}

			return tagWriter;
		}

		private void raiseTextChanged( Object sender, EventArgs e )
		{
			OnTextChanged( e );
		}

		/// <summary>
		/// The container control of ComboBox's controls.
		/// </summary>
		/// <remarks>
		/// This is used by the designer.
		/// </remarks>
		protected internal WebControl ContainerControl 
		{
			get 
			{
				EnsureChildControls();
				return container;
			}
		}

		/// <summary>
		/// The button which activates the dropdownlist portion of the ComboBox.
		/// </summary>
		/// <remarks>This is used by the designer.</remarks>
		protected internal WebControl ButtonControl 
		{
			get 
			{
				EnsureChildControls();
				return button;
			}
		}

		/// <summary>
		/// The text area of the ComboBox.
		/// </summary>
		/// <remarks>This is used by the designer.</remarks>
		protected internal TextBox TextControl 
		{
			get 
			{
				EnsureChildControls();
				return text;
			}
		}

		private WebControl container;
		private WebControl button;
		private TextBox text;

		private Boolean isLoaded = false;
		#endregion

		/// <summary>
		/// Overrides <see cref="ListControl.SelectedIndex"/>.
		/// </summary>
		public override int SelectedIndex 
		{
			get 
			{
				return base.SelectedIndex;
			}
			set 
			{
				base.SelectedIndex = value;
				if ( this.isLoaded ) 
				{
					if ( this.SelectedItem != null ) 
					{
						this.Text = this.SelectedItem.Text;
					} 
					else 
					{
						this.Text = String.Empty;
					}
				}
			}
		}

		/// <summary>
		/// Overrides 
		/// </summary>
		protected override void OnLoad(System.EventArgs e) 
		{
			this.isLoaded = true;
			base.OnLoad(e);
		}
	}
	#endregion
	#region ComboBoxDesigner
	/// <summary>
	/// The designer for the 
	/// </summary>
	public class ComboBoxDesigner: System.Web.UI.Design.WebControls.ListControlDesigner 
	{

		/// <summary>
		/// Overrides <see cref="ListControlDesigner.GetDesignTimeHtml"/>.
		/// </summary>
		public override String GetDesignTimeHtml() 
		{
			try 
			{
				combo.TextControl.Visible = false;
				combo.TextControl.BackColor = combo.BackColor;
				combo.ContainerControl.Visible = false;

				Int32 oldSelectedIndex = -1;
				if ( combo.Text != String.Empty ) 
				{
					oldSelectedIndex = combo.SelectedIndex;
					combo.Items.Insert( 0, new ListItem( combo.Text, combo.Text ) );
					combo.SelectedIndex = 0;
				}
				String result = base.GetDesignTimeHtml();
				if ( combo.Text != String.Empty ) 
				{
					combo.Items.RemoveAt(0);
					combo.SelectedIndex = oldSelectedIndex;
				}
				
				combo.TextControl.Visible = true;
				combo.ContainerControl.Visible = true;
				return result;
			} 
			catch ( Exception ex ) 
			{
				return this.GetErrorDesignTimeHtml(ex);
			}
		}

		/// <summary>
		/// Overrides <see cref="ListControlDesigner.Initialize"/>.
		/// </summary>
		public override void Initialize(System.ComponentModel.IComponent component) 
		{
			base.Initialize( component );
			this.combo = (ComboBox)component;
		}

		/// <summary>
		/// The ComboBox for this designer.
		/// </summary>
		protected ComboBox combo;
	}
	#endregion
}
