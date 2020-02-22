using System;
using System.Collections;
using System.Reflection;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Globalization;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace Com.UserControl
{
	/// <summary>
	/// TabPage 的摘要说明。
	/// </summary>
	//	[ParseChildren(true,"Items"),DefaultProperty("Items"),PersistChildren(false),Designer(typeof(TabPageDesigner)),
	//	ToolboxData("<{0}:TabPage runat=\"server\"></{0}:TabPage>")]
	public class TabPage : System.Web.UI.Control
	{
	
		//		public TabPage()
		//		{
		//			_Items = new MappingItemCollection();
		//		}
		//		#region 变量
		//		private MappingItemCollection _Items;
		//		private HtmlImage imgFirst;
		//		private HtmlImage imgPre;
		//		private HtmlImage imgNext;
		//		private HtmlImage imgLast;
		//		private HtmlSelect ddlActor;
		//		#endregion
		//		#region　属性
		//		/// <summary>
		//		/// 
		//		/// </summary>
		//		[Browsable(true),Bindable(false),DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
		//		NotifyParentProperty(true),
		//		PersistenceMode(PersistenceMode.InnerDefaultProperty),Category("MyProperty"),Description("Items"),
		//		Editor(typeof(System.ComponentModel.Design.CollectionEditor),typeof(System.Drawing.Design.UITypeEditor))]
		//		public TabItemCollection Items
		//		{
		//			get
		//			{
		//				if (this._Items == null) 
		//				{ 
		// 
		//					this._Items= new TabItemCollection(); 
		// 
		//				} 
		//				return this._Items;
		//			}
		//		}
		//		#endregion
		//		/// <summary>
		//		/// 
		//		/// </summary>
		//		/// <param name="e"></param>
		//		protected override void OnPreRender(EventArgs e)
		//		{
		//			if(!Page.IsClientScriptBlockRegistered("Style"))
		//			{
		//				Page.RegisterClientScriptBlock("Style",@"<style type='text/css'>TD { FONT-SIZE: 9pt; LINE-HEIGHT: 1.2 }
		//	A:link { COLOR: #003399; TEXT-DECORATION: none }
		//	A:visited { COLOR: #003399; TEXT-DECORATION: none }
		//	A:hover { COLOR: #ff9900; TEXT-DECORATION: underline }
		//	.copyright { FONT-WEIGHT: normal; FONT-SIZE: 12px; COLOR: #ffffff; FONT-FAMILY: 'Arial', 'Helvetica', 'sans-serif'; TEXT-ALIGN: right }
		//	.contentbox { OVERFLOW: auto; BACKGROUND-COLOR: #fcfcfc }
		//	.content { PADDING-RIGHT: 10px; PADDING-LEFT: 10px; PADDING-BOTTOM: 10px; PADDING-TOP: 10px }
		//	.tab-on { BORDER-RIGHT: #cccccc 1px; PADDING-RIGHT: 2px; BORDER-TOP: #cccccc 1px solid; PADDING-LEFT: 2px; PADDING-BOTTOM: 2px; BORDER-LEFT: #cccccc 1px solid; WIDTH: 120px; CURSOR: hand; COLOR: #000000; PADDING-TOP: 2px; BORDER-BOTTOM: #cccccc 1px; BACKGROUND-COLOR: #ffffff }
		//	.tab-off { BORDER-RIGHT: #cccccc 1px; PADDING-RIGHT: 2px; BORDER-TOP: #cccccc 1px solid; PADDING-LEFT: 2px; PADDING-BOTTOM: 2px; BORDER-LEFT: #cccccc 1px solid; WIDTH: 120px; CURSOR: hand; COLOR: #666666; PADDING-TOP: 2px; BORDER-BOTTOM: #cccccc 1px solid; BACKGROUND-COLOR: #f6f6f6 }
		//	.tab-none { BORDER-RIGHT: #cccccc 1px; PADDING-RIGHT: 2px; BORDER-TOP: #cccccc 1px; PADDING-LEFT: 2px; PADDING-BOTTOM: 2px; BORDER-LEFT: #cccccc 1px solid; PADDING-TOP: 2px; BORDER-BOTTOM: #cccccc 1px solid }
		//	.tab-content { BORDER-RIGHT: #cccccc 1px solid; BORDER-TOP: #cccccc 1px; VERTICAL-ALIGN: top; BORDER-LEFT: #cccccc 1px solid; BORDER-BOTTOM: #cccccc 1px solid; BACKGROUND-COLOR: #ffffff }
		//	.td_heading { BORDER-RIGHT: #cccccc 1px; PADDING-RIGHT: 3px; BORDER-TOP: #cccccc 1px; PADDING-LEFT: 10px; PADDING-BOTTOM: 3px; BORDER-LEFT: #cccccc 1px; COLOR: #999999; PADDING-TOP: 3px; BORDER-BOTTOM: #cccccc 1px dashed }
		//	.td_title { BORDER-RIGHT: #e0e0e0 1px solid; BORDER-TOP: #e0e0e0 1px solid; BORDER-LEFT: #e0e0e0 1px solid; COLOR: #666666; BORDER-BOTTOM: #e0e0e0 1px solid; BACKGROUND-COLOR: #f6f6f6 }
		//	.td_text { PADDING-RIGHT: 10px; PADDING-LEFT: 10px; PADDING-BOTTOM: 10px; PADDING-TOP: 10px }
		//	.attrName { FONT-SIZE: 9pt; COLOR: #ff0033 }
		//		</style>");
		//			}
		//			if(!Page.IsClientScriptBlockRegistered("Script"))
		//			{
		//				Page.RegisterClientScriptBlock("Script",@"<SCRIPT language='javascript'>
		//function SelectFirstActor()
		//{
		//	try
		//	{
		//		if(document.all['ddlActor'].options[0]!=null)
		//		{
		//			document.all['ddlActor'].options[0].selected=true;
		//			switchActor();
		//		}
		//	}
		//	catch(e){}
		//}
		//function SelectPreActor()
		//{  
		//    var SelectedIndex;
		//	try
		//	{
		//		for(var i=0;i<document.all['ddlActor'].options.length;i++)
		//		{
		//			if(document.all['ddlActor'].options[i].selected==true)
		//			{
		//				SelectedIndex=i;
		//			}
		//		}
		//		if(SelectedIndex!=0)
		//		{
		//			if(document.all['ddlActor'].options[SelectedIndex-1]!=null)
		//			{
		//				document.all['ddlActor'].options[SelectedIndex-1].selected=true;
		//				switchActor();
		//			}
		//		}
		//	}
		//	catch(e){}
		//}
		//function SelectNextActor()
		//{
		//    var SelectedIndex;
		//	try
		//	{
		//		for(var i=0;i<document.all['ddlActor'].options.length;i++)
		//		{
		//			if(document.all['ddlActor'].options[i].selected==true)
		//			{
		//				SelectedIndex=i;
		//			}
		//		}
		//		if(document.all['ddlActor'].options[SelectedIndex+1]!=null)
		//		{
		//			document.all['ddlActor'].options[SelectedIndex+1].selected=true;
		//			switchActor();
		//		}
		//	}
		//	catch(e)
		//	{}
		//}
		//function SelectLastActor()
		//{
		//	try
		//	{
		//		if(document.all['ddlActor'].options.length>0)
		//		{
		//			document.all['ddlActor'].options[document.all['ddlActor'].options.length-1].selected=true;
		//			switchActor();
		//		}
		//	}
		//	catch(e){}
		//}
		//function switchCell(n,Url) 
		//{
		//	var i,strIDs='';
		//	tb_content.height= screen.availHeight - 150;
		//	try
		//	{
		//		for(i=0;i<document.all['ddlActor'].length;i++)
		//		{
		//			strIDs=strIDs+document.all['ddlActor'].options[i].value+',';
		//		}
		//		
		//		if(strIDs!=',')
		//		{
		//			document.frames['iMainFrame'].location=navcell[n-1].Url+'?ActorID='+document.all['ddlActor'].value+'&ActorIDs='+strIDs;
		//			for(i=0;i<navcell.length;i++)
		//			{
		//				navcell[i].className= 'tab-off';
		//			}
		//			navcell[n-1].className= 'tab-on';
		//			document.all('navcellindex').value=n;
		//		}
		//		else
		//		{
		//		document.frames['iMainFrame'].location='NoActor.htm';
		//		}
		//	}
		//    catch(e){}
		//}
		//function switchActor() 
		//{
		//	switchCell(document.all['navcellindex'].value);
		//}
		//           </Script>");
		//			}
		//		}
		//		/// <summary>
		//		/// 
		//		/// </summary>
		//		/// <param name="e"></param>
		//		protected override void OnLoad(EventArgs e)
		//		{
		//			base.OnLoad (e);
		//		}
		//		#region  OnInit
		//		/// <summary>
		//		/// 
		//		/// </summary>
		//		/// <param name="e"></param>
		//		protected override void OnInit(EventArgs e)
		//		{
		//			base.OnInit (e);
		//			if(this.FindControl(this.UniqueID+"Table1")==null)
		//			{
		//				HtmlTable Table1=new HtmlTable();
		//				Table1.ID=this.UniqueID+"Table1";
		//				Table1.Width = new Unit("100%");
		//
		//			
		//				Table1.Rows.Add(new HtmlTableRow());
		//				HtmlTableCell Cell1=new HtmlTableCell();
		//				Cell1.InnerText="&nbsp;";
		//				Cell1.Attributes.Add("Class","tab-none");
		//				Table1.Rows[0].Cells.Add(Cell1);
		//
		//				foreach(TabItem oItem in this.Items)
		//				{
		//					HtmlTableCell Cell=new HtmlTableCell();
		//					if(oItem.ImageUrl!=null && oItem.ImageUrl!="")
		//					{
		//						Cell.InnerText="<img src='"+oItem.ImageUrl+"' border='0'>"+oItem.Name;
		//					}
		//					else
		//					{
		//						Cell.InnerText=oItem.Name;
		//					}
		//					Cell.Attributes.Add("id","navcell");
		//					Cell.Attributes.Add("Class",oItem.Url);
		//					Table1.Rows[0].Cells.Add(Cell);
		//				}
		//				Table1.Wrap = false;
		//				Table1.Width = new Unit("50%");
		//				Table1.HorizontalAlign=HorizontalAlign.Center;
		//				Table1.Rows[0].Cells.Add(Table1);
		//				Table1.Rows[0].Cells.Add(tcNavigation);
		//				this.Controls.Add(tToolBar);
		//				
		//			}
		//		}
		//		#endregion
	}
	#region TabItem
	/// <summary>
	/// TabItem 的摘要说明。
	/// </summary>
	[ToolboxItem(false)]	
	public class TabItem :IStateManager
	{
		
		#region 构造函数...
		/// <summary>
		/// 
		/// </summary>
		public TabItem()
		{
			
		}
		#endregion
		#region 变量...
		private bool _IsTrackingViewState = false;
		private StateBag _ViewState;
		#endregion
		#region 属性
		/// <summary>
		/// 要连接到的地址
		/// </summary>
		[Description("要连接到的地址"),
		Category("MyProperty")] 
		public string Url
		{
			get
			{
				return (string)ViewState["Url"];
			}
			set
			{ 
				ViewState["Url"] = value; 
			}
		}
		/// <summary>
		/// 要显示的图片地址
		/// </summary>
		[Description("要显示的图片地址"),
		Category("MyProperty"),Editor(typeof(System.Web.UI.Design.ImageUrlEditor), typeof(UITypeEditor))]
		public string ImageUrl
		{
			get
			{
				return (string)ViewState["ImageUrl"];
			}
			set
			{ 
				ViewState["ImageUrl"] = value; 
			}
		}
		/// <summary>
		/// 显示的连接名称
		/// </summary>
		[Description("显示的连接名称"),
		Category("MyProperty")] 
		public string Name
		{
			get
			{
				return (string)ViewState["Name"];
			}
			set
			{ 
				ViewState["Name"] = value; 
			}
		}
		#endregion

		#region IStateManager 成员

		/// <summary>
		/// Sets all items within the StateBag to be dirty
		/// </summary>
		protected void SetViewStateDirty()
		{
			if (_ViewState != null)
			{
				foreach (StateItem item in ViewState.Values)
				{
					item.IsDirty = true;
				}
			}
		}

		/// <summary>
		/// Sets all items within the StateBag to be clean
		/// </summary>
		protected void SetViewStateClean()
		{
			if (_ViewState != null)
			{
				foreach (StateItem item in ViewState.Values)
				{
					item.IsDirty = false;
				}
			}
		}

		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		public object Clone()
		{
			TabItem copy = (TabItem)Activator.CreateInstance(this.GetType(), BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.CreateInstance, null, null, null);

			// Merge in the properties from this object into the copy
			copy._IsTrackingViewState = this._IsTrackingViewState;

			if (this._ViewState != null)
			{
				StateBag viewState = copy.ViewState;
				foreach (string key in this.ViewState.Keys)
				{
					object item = this.ViewState[key];
					if (item is ICloneable)
					{
						item = ((ICloneable)item).Clone();
					}

					viewState[key] = item;
				}
			}

			return copy;
		}

		/// <summary>
		/// An instance of the StateBag class that contains the view state information.
		/// </summary>
		StateBag ViewState
		{
			get
			{
				// To concerve resources, especially on the page,
				// only create the view state when needed.
				if (_ViewState == null)
				{
					_ViewState = new StateBag();
					if (((IStateManager)this).IsTrackingViewState)
					{
						((IStateManager)_ViewState).TrackViewState();
					}
				}

				return _ViewState;
			}
		}

		/// <summary>
		/// Loads the node's previously saved view state.
		/// </summary>
		/// <param name="state">An Object that contains the saved view state values for the node.</param>
		void IStateManager.LoadViewState(object state)
		{
			((TabItem)this).LoadViewState(state);
		}

		/// <summary>
		/// Loads the node's previously saved view state.
		/// </summary>
		/// <param name="state">An Object that contains the saved view state values for the node.</param>
		void LoadViewState(object state)
		{
			if (state != null)
			{
				((IStateManager)ViewState).LoadViewState(state);
			}
		}

		/// <summary>
		/// Saves the changes to the node's view state to an Object.
		/// </summary>
		/// <returns>The Object that contains the view state changes.</returns>
		object IStateManager.SaveViewState()
		{
			return ((TabItem)this).SaveViewState();
		}

		/// <summary>
		/// Saves the changes to the node's view state to an Object.
		/// </summary>
		/// <returns>The Object that contains the view state changes.</returns>
		object SaveViewState()
		{
			if (_ViewState != null)
			{
				return ((IStateManager)_ViewState).SaveViewState();
			}

			return null;
		}

		/// <summary>
		/// Instructs the node to track changes to its view state.
		/// </summary>
		void IStateManager.TrackViewState()
		{
			((TabItem)this).TrackViewState();
		}

		/// <summary>
		/// Instructs the node to track changes to its view state.
		/// </summary>
		void TrackViewState()
		{
			_IsTrackingViewState = true;

			if (_ViewState != null)
			{
				((IStateManager)_ViewState).TrackViewState();
			}
		}

		/// <summary>
		/// Gets a value indicating whether a server control is tracking its view state changes.
		/// </summary>
		bool IStateManager.IsTrackingViewState
		{
			get { return _IsTrackingViewState; }
		}
		#endregion
	}
	#endregion
	#region TabItemCollection
	/// <summary>
	/// TabItemCollection 的摘要说明。
	/// </summary>
	[ToolboxItem(false),Editor(typeof(CollectionEditor),typeof(UITypeEditor))]
	public class TabItemCollection : System.Collections.CollectionBase,IStateManager
	{
		private bool _Tracking = false;
		private bool _Reloading = false;
		/// <summary>
		/// 
		/// </summary>
		public TabItemCollection(): base()
		{
			
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="item"></param>
		public void Add(TabItem item)
		{
			if (!Contains(item))
			{
				List.Add(item);
			}
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="index"></param>
		/// <param name="item"></param>
		public void AddAt(int index, TabItem item)
		{
			if (!Contains(item))
			{
				List.Insert(index, item);
			}
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public bool Contains(TabItem item)
		{
			return List.Contains(item);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public int IndexOf(TabItem item)
		{
			return List.IndexOf(item);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="item"></param>
		public void Remove(TabItem item)
		{
			List.Remove(item);
		}
	
		/// <summary>
		/// 
		/// </summary>
		/// <param name="index"></param>
		public new void RemoveAt(int index)
		{
			if (Contains(this[index]))
			{
				List.RemoveAt(index);
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public TabItem this[int Index]
		{
			get
			{
				if(Index >= Count || Index < 0)
				{
					return null;
				}
				return (TabItem)List[Index];
			}
			set
			{
				List[Index] = value;
			}
		}
		#region IStateManager 成员
		bool Reloading
		{
			get { return _Reloading; }
		}
		/// <summary>
		/// Gets a value indicating whether a server control is tracking its view state changes.
		/// </summary>
		bool IStateManager.IsTrackingViewState
		{
			get { return _Tracking; }
		}
		/// <summary>
		/// Loads the collection's previously saved view state.
		/// </summary>
		/// <param name="state">An Object that contains the saved view state values for the collection.</param>
		void IStateManager.LoadViewState(object state)
		{
			if (state == null)
			{
				return;
			}

			object[] viewState = (object[])state;

			if (viewState[0] != null)
			{
				_Reloading = true;

				//				// Restore and re-do actions
				//				object[] actions = (object[])viewState[0];
				//
				//				ArrayList newActionList = new ArrayList();
				//				foreach (object actionState in actions)
				//				{
				//					Action action = new Action();
				//					action.Load(actionState);
				//
				//					newActionList.Add(action);
				//
				//					switch (action.ActionType)
				//					{
				//						case ActionType.Clear:
				//							List.Clear();
				//							break;
				//
				//						case ActionType.Remove:
				//							List.RemoveAt(action.Index);
				//							break;
				//
				//						case ActionType.Insert:
				//							RedoInsert(action.Index, action.NodeType);
				//							break;
				//					}
				//				}
				//
				//				_Actions = newActionList;
				_Reloading = false;
			}

			if (viewState[1] != null)
			{
				// Load view state changes

				object[] lists = (object[])viewState[1];
				ArrayList indices = (ArrayList)lists[0];
				ArrayList items = (ArrayList)lists[1];

				for (int i = 0; i < indices.Count; i++)
				{
					((IStateManager)List[(int)indices[i]]).LoadViewState(items[i]);
				}
			}
		}

		/// <summary>
		/// Saves the changes to the collection's view state to an Object.
		/// </summary>
		/// <returns>The Object that contains the view state changes.</returns>
		object IStateManager.SaveViewState()
		{
			object[] state = new object[2];

			//			if (Actions.Count > 0)
			//			{
			//				// Save the actions made to the collection
			//				object[] obj = new object[Actions.Count];
			//				for (int i = 0; i < Actions.Count; i++)
			//				{
			//					obj[i] = ((Action)Actions[i]).Save();
			//				}
			//				state[0] = obj;
			//			}

			if (List.Count > 0)
			{
				// Save the view state changes of the child nodes

				ArrayList indices = new ArrayList(4);
				ArrayList items = new ArrayList(4);

				for (int i = 0; i < List.Count; i++)
				{
					object item = ((IStateManager)List[i]).SaveViewState();
					if (item != null)
					{
						indices.Add(i);
						items.Add(item);
					}
				}

				if (indices.Count > 0)
				{
					state[1] = new object[] { indices, items };
				}
			}

			if ((state[0] != null) || (state[1] != null))
			{
				return state;
			}
            
			return null;
		}

		/// <summary>
		/// Instructs the collection to track changes to its view state.
		/// </summary>
		void IStateManager.TrackViewState()
		{
			_Tracking = true;

			// Tracks view state changes in the child nodes
			foreach (TabItem node in List)
			{
				((IStateManager)node).TrackViewState();
			}
		}
		#endregion

	}
	#endregion
}
