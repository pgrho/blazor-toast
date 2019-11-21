using System.IO;
using System.Text;
using System.Text.Json;

namespace Shipwreck.BlazorJqueryToast
{
    public struct ToastPosition
    {
        private ToastPosition(string value)
        {
            Value = value;
            Left = null;
            Top = null;
            Right = null;
            Bottom = null;
        }

        public ToastPosition(string left, string top, string right, string bottom)
        {
            Value = null;
            Left = left;
            Top = top;
            Right = right;
            Bottom = bottom;
        }

        public bool IsEmpty
            => Value == null
            && Left == null
            && Top == null
            && Right == null
            && Bottom == null;

        public string Value { get; }
        public string Left { get; }
        public string Top { get; }
        public string Right { get; }
        public string Bottom { get; }

        public static ToastPosition TopLeft => new ToastPosition("top-left");
        public static ToastPosition TopCenter => new ToastPosition("top-center");
        public static ToastPosition TopRight => new ToastPosition("top-right");

        public static ToastPosition BottomLeft => new ToastPosition("bottom-left");
        public static ToastPosition BottomCenter => new ToastPosition("bottom-center");
        public static ToastPosition BottomRight => new ToastPosition("bottom-right");
        public static ToastPosition MidCenter => new ToastPosition("mid-center");

        public override string ToString()
        {
            using (var ms = new MemoryStream())
            using (var jw = new Utf8JsonWriter(ms))
            {
                WriteTo(jw);

                jw.Flush();

                return Encoding.UTF8.GetString(ms.ToArray());
            }
        }

        internal void WriteTo(Utf8JsonWriter writer)
        {
            if (Value != null)
            {
                writer.WriteStringValue(Value);
            }
            else
            {
                writer.WriteStartObject();

                if (Left != null)
                {
                    writer.WriteString("left", Left);
                }

                if (Top != null)
                {
                    writer.WriteString("top", Top);
                }

                if (Right != null)
                {
                    writer.WriteString("right", Right);
                }

                if (Bottom != null)
                {
                    writer.WriteString("bottom", Bottom);
                }

                writer.WriteEndObject();
            }
        }
    }
}