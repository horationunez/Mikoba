
using System.Reflection;
using System.Windows.Input;
using SVG.Forms.Plugin.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Markup;

namespace mikoba.UI.Components
{
    public class KivaSvgImage : SvgImage
    {
        private string _imageKey;
        
        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create("Command", typeof(ICommand), typeof(ActionButton), null);

        public ICommand Command
        {
            get
            {
                var command = (ICommand)GetValue(CommandProperty);
                return command;
            }
            set { SetValue(CommandProperty, value); }
        }

        public KivaSvgImage()
        {
            this.SvgAssembly = typeof(App).GetTypeInfo().Assembly;
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) => {
                if (Command != null)
                {
                    Command.Execute(null);
                }
            };
            this.GestureRecognizers.Add(tapGestureRecognizer);
        }

        public string ImageKey
        {
            set
            {
                _imageKey = value;
                this.SvgPath = "mikoba.Images." + value + ".svg";
            }
            get
            {
                return _imageKey;
            }
        }
    }
}
