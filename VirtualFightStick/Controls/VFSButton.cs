using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VirtualFightStick.Controls
{
    public class VFSButton : Control
    {
        static VFSButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(VFSButton), new FrameworkPropertyMetadata(typeof(VFSButton)));
        }

        #region Properties

        public static readonly DependencyProperty IsPressedProperty = DependencyProperty.Register(
            nameof(IsPressed), 
            typeof(bool), 
            typeof(VFSButton), 
            new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, IsPressedPropertyChangedCallback)
        );
        public bool IsPressed
        {
            get => (bool)GetValue(IsPressedProperty);
            set => SetValue(IsPressedProperty, value);
        }

        #endregion

        #region Callbacks

        private static void IsPressedPropertyChangedCallback(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var vfsButton = obj as VFSButton;
            if (vfsButton == null)
            {
                return;
            }

            if (vfsButton.IsPressed)
            {
                vfsButton.OnVFSButtonPressed(); 
            }
            else
            {
                vfsButton.OnVFSButtonRelease();
            }
        }

        #endregion

        #region Overrides

        protected override void OnPreviewMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            IsPressed = true;
        }

        protected override void OnPreviewMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            IsPressed = false;
        }

        protected override void OnMouseLeave(MouseEventArgs e)
        {
            IsPressed = false;
        }

        #endregion

        #region Private Methods

        private void OnVFSButtonPressed()
        {

        }

        private void OnVFSButtonRelease()
        {

        }

        #endregion
    }
}
