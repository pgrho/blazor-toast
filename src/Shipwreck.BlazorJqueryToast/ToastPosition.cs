using Newtonsoft.Json;
using System.IO;

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
            using (var sw = new StringWriter())
            using (var jtw = new JsonTextWriter(sw))
            {
                WriteTo(jtw);

                jtw.Flush();

                return sw.ToString();
            }
        }

        internal void WriteTo(JsonWriter writer)
        {
            if (Value != null)
            {
                writer.WriteValue(Value);
            }
            else
            {
                writer.WriteStartObject();

                if (Left != null)
                {
                    writer.WritePropertyName("left");
                    writer.WriteValue(Left);
                }

                if (Top != null)
                {
                    writer.WritePropertyName("top");
                    writer.WriteValue(Top);
                }

                if (Right != null)
                {
                    writer.WritePropertyName("right");
                    writer.WriteValue(Right);
                }

                if (Bottom != null)
                {
                    writer.WritePropertyName("bottom");
                    writer.WriteValue(Bottom);
                }

                writer.WriteEndObject();
            }
        }
    }
}
