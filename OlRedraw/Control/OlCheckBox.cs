using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace OlRedraw.Control
{
    public partial class OlCheckBox : CheckBox
    {
        //Define initialization
        //定义初始化
        private Color onBorderColor = Color.Black;

        private Color onTickColor = Color.White;
        private Color onTickBackColor = Color.Blue;
        private Color offBorderColor = Color.Gray;
        private Color offTickColor = Color.White;
        private Color offTickBackColor = Color.Gray;
        private Color onSelectColor = Color.White;
        private Color offSelectColor = Color.Blue;
        private readonly bool CheckStyle = true;
        private readonly int CheckSize = 20;
        private readonly int W;
        private readonly int H;
        private float strWidth, w;

        public Color OnBorderColor
        {
            get { return onBorderColor; }
            set
            {
                onBorderColor = value;
                this.Invalidate();
            }
        }

        public Color OnTickColor
        {
            get { return onTickColor; }
            set
            {
                onTickColor = value;
                this.Invalidate();
            }
        }

        public Color OnTickBackColor
        {
            get { return onTickBackColor; }
            set
            {
                onTickBackColor = value;
                this.Invalidate();
            }
        }

        public Color OffBorderColor
        {
            get { return offBorderColor; }
            set
            {
                offBorderColor = value;
                this.Invalidate();
            }
        }

        public Color OffTickColor
        {
            get { return offTickColor; }
            set
            {
                offTickColor = value;
                this.Invalidate();
            }
        }

        public Color OffTickBackColor
        {
            get { return offTickBackColor; }
            set
            {
                offTickBackColor = value;
                this.Invalidate();
            }
        }

        public Color OnSelectColor
        {
            get { return onSelectColor; }
            set { onSelectColor = value; }
        }

        public Color OffSelectColor
        {
            get { return offSelectColor; }
            set { offSelectColor = value; }
        }

        public override string Text { get => base.Text; set => base.Text = value; }

        private static readonly Point[] CheckTickLine = { new Point(3, 8), new Point(7, 12), new Point(14, 5) };

        private Bitmap DrawCheckTickBitmap()
        {
            Bitmap CheckTick = new Bitmap(CheckSize, CheckSize);
            Graphics CheckTickGraphics = Graphics.FromImage(CheckTick);
            CheckTickGraphics.Clear(Color.Transparent);
            using (Pen pen = new Pen(OnTickColor, 2))
            {
                CheckTickGraphics.DrawLines(pen, CheckTickLine);
            }

            return CheckTick;
        }

        //Define component
        //定义组件
        public OlCheckBox()
        {
            H = this.Height - 1;
            W = this.Width / 2;
            this.Cursor = Cursors.Hand;
        }

        //Automatically adjust according to the length of the text
        //根据文本长度，自动调整
        public override Size GetPreferredSize(Size proposedSize)
        {
            using (Graphics strgraph = this.CreateGraphics())
            {
                strWidth = strgraph.MeasureString(Text.ToString(), Font).Width;
            }
            w = CheckSize + strWidth + 5;
            if (Appearance == Appearance.Normal)
            {
                this.Size = new Size((int)w, Height);
                this.MinimumSize = new Size(CheckSize + 4, H + 1);
            }
            else
            {
                this.Size = new Size((int)w, Height);
                this.MinimumSize = new Size((int)w, H + 1);
            }
            return CheckStyle ? new Size((int)w, Height) : new Size(W, H + 1);
        }

        protected override void OnAppearanceChanged(EventArgs e)
        {
            base.OnAppearanceChanged(e);
            if (Appearance == Appearance.Normal)
            {
                Appearance = Appearance.Normal;
            }
            else
            {
                Appearance = Appearance.Button;
            }
        }

        //Define the border box
        //定义边框小盒子
        private GraphicsPath GetNormalCheckBorderPath()
        {
            Rectangle NormalCheckBorder = new Rectangle(2, Height / 2 - H / 2 + 1, CheckSize - 1, CheckSize - 1);
            GraphicsPath NormalCheckBorderPath = new GraphicsPath();
            NormalCheckBorderPath.StartFigure();
            NormalCheckBorderPath.AddRectangle(NormalCheckBorder);
            NormalCheckBorderPath.CloseFigure();
            return NormalCheckBorderPath;
        }

        private GraphicsPath GetButtonCheckBorderPath()
        {
            Rectangle ButtonCheckBorder = new Rectangle(2, 2, Width - 4, Height - 4);
            GraphicsPath ButtonCheckBorderPath = new GraphicsPath();
            ButtonCheckBorderPath.StartFigure();
            ButtonCheckBorderPath.AddRectangle(ButtonCheckBorder);
            ButtonCheckBorderPath.CloseFigure();
            return ButtonCheckBorderPath;
        }

        //Define the border box (inside)
        //定义边框小盒子（内部）
        private GraphicsPath GetNormalCheckBackPath()
        {
            Rectangle NormalBackBorder = new Rectangle(2, Height / 2 - H / 2 + 1, CheckSize - 1, CheckSize - 1);
            GraphicsPath NormalBackBorderPath = new GraphicsPath();
            NormalBackBorderPath.StartFigure();
            NormalBackBorderPath.AddRectangle(NormalBackBorder);
            NormalBackBorderPath.CloseFigure();
            return NormalBackBorderPath;
        }

        private GraphicsPath GetButtonCheckBackPath()
        {
            Rectangle ButtonCheckBack = new Rectangle(4, 4, Width - H / 2 + 3, Height - H / 2 + 3);
            GraphicsPath ButtonCheckBackPath = new GraphicsPath();
            ButtonCheckBackPath.StartFigure();
            ButtonCheckBackPath.AddRectangle(ButtonCheckBack);
            ButtonCheckBackPath.CloseFigure();
            return ButtonCheckBackPath;
        }

        //Redraw
        //重绘
        protected override void OnPaint(PaintEventArgs pevent)
        {
            Graphics g = pevent.Graphics;
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            pevent.Graphics.Clear(this.Parent.BackColor);
            if (Appearance == Appearance.Normal)
            {
                if (Enabled)
                {
                    if (Checked)
                    {
                        pevent.Graphics.FillPath(new SolidBrush(OnTickBackColor), GetNormalCheckBackPath());
                        g.DrawImageUnscaledAndClipped(DrawCheckTickBitmap(), new Rectangle(3, Height / 2 - H / 2 + 2, CheckSize - 1, CheckSize - 1));
                    }
                    else
                    {
                        pevent.Graphics.DrawPath(new Pen(OnBorderColor, 1), GetNormalCheckBorderPath());
                    }
                }
                else
                {
                    if (Checked)
                    {
                        pevent.Graphics.FillPath(new SolidBrush(OffTickBackColor), GetNormalCheckBackPath());
                        g.DrawImageUnscaledAndClipped(DrawCheckTickBitmap(), new Rectangle(3, Height / 2 - H / 2 + 2, CheckSize - 1, CheckSize - 1));
                    }
                    else
                    {
                        pevent.Graphics.DrawPath(new Pen(OffBorderColor, 1), GetNormalCheckBorderPath());
                    }
                }

                pevent.Graphics.DrawString(Text, Font, new SolidBrush(ForeColor), CheckSize + 4, Height / 2 - H / 2 + 3);
            }
            else if (Appearance == Appearance.Button)
            {
                if (Enabled)
                {
                    if (Checked)
                    {
                        pevent.Graphics.FillPath(new SolidBrush(OnTickBackColor), GetButtonCheckBackPath());
                        pevent.Graphics.DrawPath(new Pen(OnBorderColor, 2), GetButtonCheckBorderPath());
                        pevent.Graphics.DrawString(Text, Font, new SolidBrush(OnSelectColor), Width / 2 - W + 5, Height / 2 - H / 2 + 3);
                    }
                    else
                    {
                        pevent.Graphics.FillPath(new SolidBrush(OffTickBackColor), GetButtonCheckBackPath());
                        pevent.Graphics.DrawPath(new Pen(OffBorderColor, 2), GetButtonCheckBorderPath());
                        pevent.Graphics.DrawString(Text, Font, new SolidBrush(OffSelectColor), Width / 2 - W + 5, Height / 2 - H / 2 + 3);
                    }
                }
                else
                {
                    if (Checked)
                    {
                        pevent.Graphics.FillPath(new SolidBrush(OnTickBackColor), GetButtonCheckBackPath());
                        pevent.Graphics.DrawPath(new Pen(OnBorderColor, 2), GetButtonCheckBorderPath());
                        pevent.Graphics.DrawString(Text, Font, new SolidBrush(OnSelectColor), Width / 2 - W + 5, Height / 2 - H / 2 + 3);
                    }
                    else
                    {
                        pevent.Graphics.FillPath(new SolidBrush(OffTickBackColor), GetButtonCheckBackPath());
                        pevent.Graphics.DrawPath(new Pen(OffBorderColor, 2), GetButtonCheckBorderPath());
                        pevent.Graphics.DrawString(Text, Font, new SolidBrush(OffSelectColor), Width / 2 - W + 5, Height / 2 - H / 2 + 3);
                    }
                }
            }
        }
    }
}