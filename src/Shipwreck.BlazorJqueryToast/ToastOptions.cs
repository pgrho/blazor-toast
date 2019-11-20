using Newtonsoft.Json;
using System;
using System.IO;

namespace Shipwreck.BlazorJqueryToast
{
    public sealed class ToastOptions
    {
        public string Text { get; set; }
        public string Heading { get; set; }
        public ToastTransition Transition { get; set; }

        public bool? AllowToastClose { get; set; }
        public TimeSpan HideAfter { get; set; }

        public int StackLength { get; set; }

        public ToastPosition Position { get; set; }

        public ToastIcon Icon { get; set; }
        public TextAlignment TextAlign { get; set; }

        public bool? ShowLoader { get; set; }
        public string LoaderBackground { get; set; }

        public override string ToString()
        {
            using (var sw = new StringWriter())
            using (var jtw = new JsonTextWriter(sw))
            {
                jtw.WriteStartObject();
                {
                    if (Text != null)
                    {
                        jtw.WritePropertyName("text");
                        jtw.WriteValue(Text);
                    }
                    if (Heading != null)
                    {
                        jtw.WritePropertyName("heading");
                        jtw.WriteValue(Heading);
                    }
                    switch (Transition)
                    {
                        case ToastTransition.Fade:
                            jtw.WritePropertyName("showHideTransition");
                            jtw.WriteValue("fade");
                            break;

                        case ToastTransition.Slide:
                            jtw.WritePropertyName("showHideTransition");
                            jtw.WriteValue("slide");
                            break;

                        case ToastTransition.Plain:
                            jtw.WritePropertyName("showHideTransition");
                            jtw.WriteValue("plain");
                            break;
                    }

                    if (AllowToastClose != null)
                    {
                        jtw.WritePropertyName("allowToastClose");
                        jtw.WriteValue(AllowToastClose.Value);
                    }

                    if (HideAfter > TimeSpan.Zero)
                    {
                        jtw.WritePropertyName("hideAfter");
                        jtw.WriteValue(HideAfter.TotalMilliseconds);
                    }
                    else if (HideAfter < TimeSpan.Zero)
                    {
                        jtw.WritePropertyName("hideAfter");
                        jtw.WriteValue(false);
                    }

                    if (StackLength > 0)
                    {
                        jtw.WritePropertyName("stack");
                        jtw.WriteValue(StackLength);
                    }
                    else if (StackLength < 0)
                    {
                        jtw.WritePropertyName("stack");
                        jtw.WriteValue(false);
                    }

                    var p = Position;
                    if (!p.IsEmpty)
                    {
                        jtw.WritePropertyName("position");
                        p.WriteTo(jtw);
                    }

                    switch (Icon)
                    {
                        case ToastIcon.Warning:
                            jtw.WritePropertyName("icon");
                            jtw.WriteValue("warning");
                            break;

                        case ToastIcon.Success:
                            jtw.WritePropertyName("icon");
                            jtw.WriteValue("success");
                            break;

                        case ToastIcon.Error:
                            jtw.WritePropertyName("icon");
                            jtw.WriteValue("error");
                            break;

                        case ToastIcon.Information:
                            jtw.WritePropertyName("icon");
                            jtw.WriteValue("information");
                            break;
                    }

                    switch (TextAlign)
                    {
                        case TextAlignment.Left:
                            jtw.WritePropertyName("textAlign");
                            jtw.WriteValue("left");
                            break;

                        case TextAlignment.Center:
                            jtw.WritePropertyName("textAlign");
                            jtw.WriteValue("center");
                            break;

                        case TextAlignment.Right:
                            jtw.WritePropertyName("textAlign");
                            jtw.WriteValue("right");
                            break;
                    }

                    if (ShowLoader != null)
                    {
                        jtw.WritePropertyName("loader");
                        jtw.WriteValue(ShowLoader.Value);
                    }

                    if (LoaderBackground != null)
                    {
                        jtw.WritePropertyName("loaderBg");
                        jtw.WriteValue(LoaderBackground);
                    }
                }
                jtw.WriteEndObject();

                jtw.Flush();

                return sw.ToString();
            }
        }
    }
}
