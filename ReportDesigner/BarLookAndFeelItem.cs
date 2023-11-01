using System;
using DevExpress.XtraBars;
using DevExpress.LookAndFeel;
using System.ComponentModel;
using DevExpress.Skins;

namespace ReportDesigner
{
	[ToolboxItem(false), DesignTimeVisible(false)]
	public class BarLookAndFeelItem : BarButtonItem {
		public BarLookAndFeelItem(BarManager manager, bool privateItem) : base() {
			fIsPrivateItem = privateItem;
			Manager = manager;
			ButtonStyle = BarButtonStyle.Check;
		}
		public virtual void UpdateState(UserLookAndFeel lookAndFeel) {
		}
		public virtual void ApplyChanges(UserLookAndFeel lookAndFeel) {
		}
	}
	public class BarLookAndFeelStyleItem : BarLookAndFeelItem {
		ActiveLookAndFeelStyle activeStyle;
		LookAndFeelStyle style;
		public BarLookAndFeelStyleItem(BarManager manager, bool privateItem, ActiveLookAndFeelStyle activeStyle, LookAndFeelStyle style) : base(manager, privateItem) {
			this.style = style;
			this.activeStyle = activeStyle;
		}
		public override void UpdateState(UserLookAndFeel lookAndFeel) {
			Down = (lookAndFeel.ActiveStyle == activeStyle);
		}
		public override void ApplyChanges(UserLookAndFeel lookAndFeel) {
			lookAndFeel.UseWindowsXPTheme = false;
			lookAndFeel.Style = style;
		}
	}
	public class BarLookAndFeelSkinNameItem : BarLookAndFeelItem {
		string skinName;
		public BarLookAndFeelSkinNameItem(BarManager manager, bool privateItem, string skinName) : base(manager, privateItem) {
			this.skinName = skinName;
		}
		public override void UpdateState(UserLookAndFeel lookAndFeel) {
			Down = (lookAndFeel.ActiveStyle == ActiveLookAndFeelStyle.Skin && lookAndFeel.SkinName == skinName);
		}
		public override void ApplyChanges(UserLookAndFeel lookAndFeel) {
			lookAndFeel.UseWindowsXPTheme = false;
			lookAndFeel.Style = LookAndFeelStyle.Skin;
			lookAndFeel.SkinName = skinName;
		}
	}
	public class BarLookAndFeelUseWindowsXPThemeItem : BarLookAndFeelItem {
		public BarLookAndFeelUseWindowsXPThemeItem(BarManager manager, bool privateItem) : base(manager, privateItem) {
		}
		public override void UpdateState(UserLookAndFeel lookAndFeel) {
			Down = (lookAndFeel.ActiveStyle == ActiveLookAndFeelStyle.WindowsXP);
			Enabled = DevExpress.Utils.WXPaint.Painter.ThemesEnabled;
		}
		public override void ApplyChanges(UserLookAndFeel lookAndFeel) {
			lookAndFeel.UseWindowsXPTheme = true;
		}
	}
	public class BarLookAndFeelListItem : BarLinkContainerItem 
	{
		UserLookAndFeel lookAndFeel;
		BarSubItem skinSubMenuItem;
		public BarLookAndFeelListItem(UserLookAndFeel lookAndFeel) {
			this.lookAndFeel = lookAndFeel;

			skinSubMenuItem = new BarSubItem();
			skinSubMenuItem.Caption = "Skin";


		}
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
		public override LinksInfo LinksPersistInfo { 
			get { return null; } 
			set { 
			}
		}
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
		public override BarItemLinkCollection ItemLinks {
			get { return base.ItemLinks; }
		}

		protected override void OnManagerChanged() {
			base.OnManagerChanged();
			if(Manager == null) return;
			BeginUpdate();
			ClearLinks();
			try {
				skinSubMenuItem.ClearLinks();
				AddBarLookAndFeelItem(this, new BarLookAndFeelUseWindowsXPThemeItem(Manager, true), "Use WindowsXP Theme");

				AddBarLookAndFeelItem(this, new BarLookAndFeelStyleItem(Manager, true, ActiveLookAndFeelStyle.Flat, LookAndFeelStyle.Flat), "Flat Style");
				AddBarLookAndFeelItem(this, new BarLookAndFeelStyleItem(Manager, true, ActiveLookAndFeelStyle.Office2003, LookAndFeelStyle.Office2003), "Office2003 Style");
				AddBarLookAndFeelItem(this, new BarLookAndFeelStyleItem(Manager, true, ActiveLookAndFeelStyle.Style3D, LookAndFeelStyle.Style3D), "Style3D");
				AddBarLookAndFeelItem(this, new BarLookAndFeelStyleItem(Manager, true, ActiveLookAndFeelStyle.UltraFlat, LookAndFeelStyle.UltraFlat), "UltraFlat Style");
				AddItem(skinSubMenuItem);

				foreach (SkinContainer container in SkinManager.Default.Skins) {
					AddBarLookAndFeelItem(skinSubMenuItem, new BarLookAndFeelSkinNameItem(Manager, true, container.SkinName), container.SkinName);
				}
			} finally {
				CancelUpdate();
			}
		}
		protected override void OnGetItemData() {
			UpdateLookAndFeelItemsState(this);
			base.OnGetItemData();
		}
		void UpdateLookAndFeelItemsState(BarLinksHolder holder) {
			foreach(BarItemLink link in holder.ItemLinks) {
				if(link.Item is BarLookAndFeelItem)
					((BarLookAndFeelItem)link.Item).UpdateState(lookAndFeel);
				if(link.Item is BarLinksHolder)
					UpdateLookAndFeelItemsState(link.Item as BarLinksHolder);
			}
		}
		void AddBarLookAndFeelItem(BarLinksHolder holder, BarLookAndFeelItem item, string caption) {
			item.Caption = caption;
			item.ItemClick += new ItemClickEventHandler(OnItemClick);
			item.UpdateState(lookAndFeel);
			holder.AddItem(item);
		}
		void OnItemClick(object sender, ItemClickEventArgs e) {
			BarLookAndFeelItem item = e.Item as BarLookAndFeelItem;
			if(item != null) item.ApplyChanges(lookAndFeel);
		}
	}
}
