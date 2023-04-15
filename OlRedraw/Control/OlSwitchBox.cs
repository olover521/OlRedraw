using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OlRedraw.Control
{
    public partial class OlSwitchBox : CheckBox
    {
        //Define initialization
        //定义初始化
        private Color onForeColor = Color.White;

        private Color offForeColor = Color.White;
        private Color onBackColor = Color.Green;
        private Color offBackColor = Color.Gray;
        private Color onBorderColor = Color.Green;
        private Color offBorderColor = Color.Gray;
        private Color onEnabledForeColor = Color.Gray;
        private Color offEnabledForeColor = Color.LightGray;
        private Color onEnabledBackColor = Color.LightGray;
        private Color offEnabledBackColor = Color.DarkGray;
        private Color onEnabledBorderColor = Color.LightGray;
        private Color offEnabledBorderColor = Color.LightGray;
        private bool toggleStyle = true;
        private readonly int W;
        private readonly int H;
        private float strWidth, w;

        public Color OnForeColor
        {
            get { return onForeColor; }
            set
            {
                onForeColor = value;
                this.Invalidate();
            }
        }

        public Color OffForeColor
        {
            get { return offForeColor; }
            set
            {
                offForeColor = value;
                this.Invalidate();
            }
        }

        public Color OnBackColor
        {
            get { return onBackColor; }
            set
            {
                onBackColor = value;
                this.Invalidate();
            }
        }

        public Color OffBackColor
        {
            get { return offBackColor; }
            set
            {
                offBackColor = value;
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

        public Color OnBorderColor
        {
            get { return onBorderColor; }
            set
            {
                onBorderColor = value;
                this.Invalidate();
            }
        }

        public Color OnEnabledForeColor
        {
            get { return onEnabledForeColor; }
            set
            {
                onEnabledForeColor = value;
                this.Invalidate();
            }
        }

        public Color OffEnabledForeColor
        {
            get { return offEnabledForeColor; }
            set
            {
                offEnabledForeColor = value;
                this.Invalidate();
            }
        }

        public Color OnEnabledBackColor
        {
            get { return onEnabledBackColor; }
            set
            {
                onEnabledBackColor = value;
                this.Invalidate();
            }
        }

        public Color OffEnabledBackColor
        {
            get { return offEnabledBackColor; }
            set
            {
                offEnabledBackColor = value;
                this.Invalidate();
            }
        }

        public Color OffEnabledBorderColor
        {
            get { return offEnabledBorderColor; }
            set
            {
                offEnabledBorderColor = value;
                this.Invalidate();
            }
        }

        public Color OnEnabledBorderColor
        {
            get { return onEnabledBorderColor; }
            set
            {
                onEnabledBorderColor = value;
                this.Invalidate();
            }
        }

        public override string Text { get => base.Text; set => base.Text = value; }

        [DefaultValue(true)]
        public bool ToggleStyle
        {
            get { return toggleStyle; }
            set
            {
                toggleStyle = value;
                this.Invalidate();
            }
        }

        //Define component
        //定义组件
        public OlSwitchBox()
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
            w = W + strWidth + 5;
            if (Appearance == Appearance.Normal)
            {
                this.Size = new Size((int)w, Height);
                this.MinimumSize = new Size(W, H + 1);
            }
            else
            {
                this.Size = new Size(W, Height);
                this.MinimumSize = new Size((int)w, H + 1);
            }
            return ToggleStyle ? new Size((int)w, Height) : new Size((int)w, H + 1);
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

        //Define "Toggle" without borders background path components
        //定义无Border的《Toggle》组件的BackGround路径
        private GraphicsPath GetNormalToggleBackPath()
        {
            Rectangle NormalBackLeft = new Rectangle(0, Height / 2 - H / 2 - 1, H, H);
            Rectangle NormalBackRight = new Rectangle(W - H - 2, Height / 2 - H / 2 - 1, H, H);
            GraphicsPath NormalToggleBackPath = new GraphicsPath();
            NormalToggleBackPath.StartFigure();
            NormalToggleBackPath.AddArc(NormalBackLeft, 90, 180);
            NormalToggleBackPath.AddArc(NormalBackRight, 270, 180);
            NormalToggleBackPath.CloseFigure();
            return NormalToggleBackPath;
        }

        private GraphicsPath GetButtonToggleBackPath()
        {
            Rectangle ButtonToggleBack = new Rectangle(0, 0, Width - 1, Height - 1);
            GraphicsPath ButtonToggleBackPath = new GraphicsPath();
            ButtonToggleBackPath.StartFigure();
            ButtonToggleBackPath.AddRectangle(ButtonToggleBack);
            ButtonToggleBackPath.CloseFigure();
            return ButtonToggleBackPath;
        }

        //Defined with the outer border of the frame of the switch component path (border)
        //定义带有Border的《Toggle》组件的OutSideBorder路径(边框)
        private GraphicsPath GetNormalToggleOutSideBorderPath()
        {
            Rectangle NormalOutSideBorderLeft = new Rectangle(0, Height / 2 - H / 2 - 1, H, H);
            Rectangle NormalOutSideBorderRight = new Rectangle(W - H - 2, Height / 2 - H / 2 - 1, H, H);
            GraphicsPath NormalToggleOutSideBorderPath = new GraphicsPath();
            NormalToggleOutSideBorderPath.StartFigure();
            NormalToggleOutSideBorderPath.AddArc(NormalOutSideBorderLeft, 90, 180);
            NormalToggleOutSideBorderPath.AddArc(NormalOutSideBorderRight, 270, 180);
            NormalToggleOutSideBorderPath.CloseFigure();
            return NormalToggleOutSideBorderPath;
        }

        private GraphicsPath GetButtonToggleOutSideBorderPath()
        {
            Rectangle ButtonOutSideBorder = new Rectangle(0, 0, Width - 1, Height - 1);
            GraphicsPath ButtonToggleOutSideBorderPath = new GraphicsPath();
            ButtonToggleOutSideBorderPath.StartFigure();
            ButtonToggleOutSideBorderPath.AddRectangle(ButtonOutSideBorder);
            ButtonToggleOutSideBorderPath.CloseFigure();
            return ButtonToggleOutSideBorderPath;
        }

        //Defined with the outer border of the frame of the switch component path(Border internal)
        //定义带有Border的《Toggle》组件的InSideBorder路径(边框内部)
        private GraphicsPath GetNormalToggleInSideBorderPath()
        {
            Rectangle NormalInsideBorderLeft = new Rectangle(1, Height / 2 - H / 2, H - 2, H - 2);
            Rectangle NormalInsideBorderRight = new Rectangle(W - H - 1, Height / 2 - H / 2, H - 2, H - 2);
            GraphicsPath NormalToggleInSideBorderPath = new GraphicsPath();
            NormalToggleInSideBorderPath.StartFigure();
            NormalToggleInSideBorderPath.AddArc(NormalInsideBorderLeft, 90, 180);
            NormalToggleInSideBorderPath.AddArc(NormalInsideBorderRight, 270, 180);
            NormalToggleInSideBorderPath.CloseFigure();
            return NormalToggleInSideBorderPath;
        }

        private GraphicsPath GetButtonToggleInSideBorderPath()
        {
            Rectangle ButtonOutSideBorder = new Rectangle(2, 2, Width - 5, Height - 5);
            GraphicsPath ButtonToggleInSideBorderPath = new GraphicsPath();
            ButtonToggleInSideBorderPath.StartFigure();
            ButtonToggleInSideBorderPath.AddRectangle(ButtonOutSideBorder);
            ButtonToggleInSideBorderPath.CloseFigure();
            return ButtonToggleInSideBorderPath;
        }

        //Redraw
        //重绘
        protected override void OnPaint(PaintEventArgs pevent)
        {
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            pevent.Graphics.Clear(this.Parent.BackColor);
            if (Appearance == Appearance.Normal)
            {
                if (Enabled)
                {
                    if (Checked)
                    {
                        if (ToggleStyle)
                        {
                            pevent.Graphics.FillPath(new SolidBrush(OnBackColor), GetNormalToggleInSideBorderPath());
                            pevent.Graphics.DrawPath(new Pen(OnBorderColor, 2), GetNormalToggleOutSideBorderPath());
                        }
                        else
                        {
                            pevent.Graphics.FillPath(new SolidBrush(OnBackColor), GetNormalToggleBackPath());
                        }
                        pevent.Graphics.FillEllipse(new SolidBrush(OnForeColor), new Rectangle(H + H / 3 - 1, Height / 2 - H / 2 + 1, H - 4, H - 4));
                        pevent.Graphics.DrawString(Text, Font, new SolidBrush(ForeColor), 55, Height / 2 - H / 2 + 4);
                    }
                    else
                    {
                        if (ToggleStyle)
                        {
                            pevent.Graphics.FillPath(new SolidBrush(OffBackColor), GetNormalToggleInSideBorderPath());
                            pevent.Graphics.DrawPath(new Pen(OffBorderColor, 2), GetNormalToggleOutSideBorderPath());
                        }
                        else
                        {
                            pevent.Graphics.FillPath(new SolidBrush(OffBackColor), GetNormalToggleBackPath());
                        }
                        pevent.Graphics.FillEllipse(new SolidBrush(OffForeColor), new Rectangle(H / 2 - H / 3 - 2, Height / 2 - H / 2 + 1, H - 4, H - 4));
                        pevent.Graphics.DrawString(Text, Font, new SolidBrush(ForeColor), 55, Height / 2 - H / 2 + 4);
                    }
                }
                else
                {
                    if (Checked)
                    {
                        if (ToggleStyle)
                        {
                            pevent.Graphics.FillPath(new SolidBrush(OnEnabledBackColor), GetNormalToggleInSideBorderPath());
                            pevent.Graphics.DrawPath(new Pen(OnEnabledBorderColor, 2), GetNormalToggleOutSideBorderPath());
                        }
                        else
                        {
                            pevent.Graphics.FillPath(new SolidBrush(OnEnabledBackColor), GetNormalToggleBackPath());
                        }
                        pevent.Graphics.FillEllipse(new SolidBrush(OnEnabledForeColor), new Rectangle(H + H / 3 - 1, Height / 2 - H / 2 + 1, H - 4, H - 4));
                        pevent.Graphics.DrawString(Text, Font, new SolidBrush(ForeColor), 55, Height / 2 - H / 2 + 4);
                    }
                    else
                    {
                        if (ToggleStyle)
                        {
                            pevent.Graphics.FillPath(new SolidBrush(OffEnabledBackColor), GetNormalToggleInSideBorderPath());
                            pevent.Graphics.DrawPath(new Pen(OffEnabledBorderColor, 2), GetNormalToggleOutSideBorderPath());
                        }
                        else
                        {
                            pevent.Graphics.FillPath(new SolidBrush(OffEnabledBackColor), GetNormalToggleBackPath());
                        }
                        pevent.Graphics.FillEllipse(new SolidBrush(OffEnabledForeColor), new Rectangle(H / 2 - H / 3 - 2, Height / 2 - H / 2 + 1, H - 4, H - 4));
                        pevent.Graphics.DrawString(Text, Font, new SolidBrush(ForeColor), 55, Height / 2 - H / 2 + 4);
                    }
                }
            }
            else if (Appearance == Appearance.Button)
            {
                if (Enabled)
                {
                    if (Checked)
                    {
                        if (ToggleStyle)
                        {
                            pevent.Graphics.FillPath(new SolidBrush(OnBackColor), GetButtonToggleInSideBorderPath());
                            pevent.Graphics.DrawPath(new Pen(OnBorderColor, 2), GetButtonToggleOutSideBorderPath());
                        }
                        else
                        {
                            pevent.Graphics.FillPath(new SolidBrush(OnBackColor), GetButtonToggleBackPath());
                        }
                        pevent.Graphics.DrawString(Text, Font, new SolidBrush(ForeColor), Width / 2 - W, Height / 2 - H / 2 + 4);
                    }
                    else
                    {
                        if (ToggleStyle)
                        {
                            pevent.Graphics.FillPath(new SolidBrush(OffBackColor), GetButtonToggleInSideBorderPath());
                            pevent.Graphics.DrawPath(new Pen(OffBorderColor, 2), GetButtonToggleOutSideBorderPath());
                        }
                        else
                        {
                            pevent.Graphics.FillPath(new SolidBrush(OffBackColor), GetButtonToggleBackPath());
                        }
                        pevent.Graphics.DrawString(Text, Font, new SolidBrush(OffForeColor), Width / 2 - W, Height / 2 - H / 2 + 4);
                    }
                }
                else
                {
                    if (Checked)
                    {
                        if (ToggleStyle)
                        {
                            pevent.Graphics.FillPath(new SolidBrush(OnEnabledBackColor), GetButtonToggleInSideBorderPath());
                            pevent.Graphics.DrawPath(new Pen(OnEnabledBorderColor, 2), GetButtonToggleOutSideBorderPath());
                        }
                        else
                        {
                            pevent.Graphics.FillPath(new SolidBrush(OnEnabledBackColor), GetButtonToggleBackPath());
                        }
                        pevent.Graphics.DrawString(Text, Font, new SolidBrush(ForeColor), Width / 2 - W, Height / 2 - H / 2 + 4);
                    }
                    else
                    {
                        if (ToggleStyle)
                        {
                            pevent.Graphics.FillPath(new SolidBrush(OffEnabledBackColor), GetButtonToggleInSideBorderPath());
                            pevent.Graphics.DrawPath(new Pen(OffEnabledBorderColor, 2), GetButtonToggleOutSideBorderPath());
                        }
                        else
                        {
                            pevent.Graphics.FillPath(new SolidBrush(OffEnabledBackColor), GetButtonToggleBackPath());
                        }
                        pevent.Graphics.DrawString(Text, Font, new SolidBrush(ForeColor), Width / 2 - W, Height / 2 - H / 2 + 4);
                    }
                }
            }
        }
    }
}