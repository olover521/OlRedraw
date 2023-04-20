using System.Drawing;
using System.Windows.Forms;

namespace OlRedraw.Control
{
    public partial class OlTabControl : TabControl
    {
        //Define component
        //定义组件
        public OlTabControl()
        {
            this.Appearance = TabAppearance.Normal;
            this.SizeMode = TabSizeMode.Normal;
        }

        //Rewrite the TabPage display area
        //重写TabPage显示区域
        public override Rectangle DisplayRectangle
        {
            get
            {
                Rectangle rectangle = base.DisplayRectangle;
                return new Rectangle(rectangle.Left - 4, rectangle.Top - 5, rectangle.Width + 8, rectangle.Height + 9);
            }
        }

        //After TabControl to call to hide TabPage title bar
        //调用TabControl之后隐藏TabPage标题栏
        protected override void InitLayout()
        {
            base.InitLayout();
            if (!base.DesignMode)
            {
                Size itemSize = base.ItemSize;
                itemSize.Width = 0;
                itemSize.Height = 1;
                base.ItemSize = itemSize;
            }
        }
    }
}