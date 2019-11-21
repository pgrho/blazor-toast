using System;
using System.IO;
using System.Text;
using System.Text.Json;

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
            using (var ms = new MemoryStream())
            using (var jw = new Utf8JsonWriter(ms))
            {
                jw.WriteStartObject();
                {
                    if (Text != null)
                    {
                        jw.WriteString("text", Text);
                    }
                    if (Heading != null)
                    {
                        jw.WriteString("heading", Heading);
                    }
                    switch (Transition)
                    {
                        case ToastTransition.Fade:
                            jw.WriteString("showHideTransition", "fade");
                            break;

                        case ToastTransition.Slide:
                            jw.WriteString("showHideTransition", "slide");
                            break;

                        case ToastTransition.Plain:
                            jw.WriteString("showHideTransition", "plain");
                            break;
                    }

                    if (AllowToastClose != null)
                    {
                        jw.WriteBoolean("allowToastClose", AllowToastClose.Value);
                    }

                    if (HideAfter > TimeSpan.Zero)
                    {
                        jw.WriteNumber("hideAfter", HideAfter.TotalMilliseconds);
                    }
                    else if (HideAfter < TimeSpan.Zero)
                    {
                        jw.WriteBoolean("hideAfter", false);
                    }

                    if (StackLength > 0)
                    {
                        jw.WriteNumber("stack", StackLength);
                    }
                    else if (StackLength < 0)
                    {
                        jw.WriteBoolean("stack", false);
                    }

                    var p = Position;
                    if (!p.IsEmpty)
                    {
                        jw.WritePropertyName("position");
                        p.WriteTo(jw);
                    }

                    switch (Icon)
                    {
                        case ToastIcon.Warning:
                            jw.WriteString("icon", "warning");
                            break;

                        case ToastIcon.Success:
                            jw.WriteString("icon", "success");
                            break;

                        case ToastIcon.Error:
                            jw.WriteString("icon", "error");
                            break;

                        case ToastIcon.Information:
                            jw.WriteString("icon", "information");
                            break;
                    }

                    switch (TextAlign)
                    {
                        case TextAlignment.Left:
                            jw.WriteString("textAlign", "left");
                            break;

                        case TextAlignment.Center:
                            jw.WriteString("textAlign", "center");
                            break;

                        case TextAlignment.Right:
                            jw.WriteString("textAlign", "right");
                            break;
                    }

                    if (ShowLoader != null)
                    {
                        jw.WriteBoolean("loader", ShowLoader.Value);
                    }

                    if (LoaderBackground != null)
                    {
                        jw.WriteString("loaderBg", LoaderBackground);
                    }
                }
                jw.WriteEndObject();

                jw.Flush();

                return Encoding.UTF8.GetString(ms.ToArray());
            }
        }
    }
}