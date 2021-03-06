﻿using System;
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

namespace FontColorControlLibrary
{
    /// <summary>
    /// Interaction logic for FontColorPicker.xaml
    /// </summary>
    public partial class FontColorPicker : UserControl
    {
        public FontColorPicker()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty TheFontSizeProperty;
        public static readonly RoutedEvent TheFontSizeChangedEvent;
        public static readonly DependencyProperty TheFontFamilyProperty;
        public static readonly RoutedEvent TheFontFamilyChangedEvent;
        public static readonly DependencyProperty TheFontStretchProperty;
        public static readonly RoutedEvent TheFontStretchChangedEvent;
        public static readonly DependencyProperty TheFontStyleProperty;
        public static readonly RoutedEvent TheFontStyleChangedEvent;
        public static readonly DependencyProperty TheFontWeightProperty;
        public static readonly RoutedEvent TheFontWeightChangedEvent;
        public static readonly DependencyProperty ColorProperty;
        public static readonly RoutedEvent ColorChangedEvent;
        private static readonly DependencyProperty RedProperty;
        private static readonly DependencyProperty GreenProperty;
        private static readonly DependencyProperty BlueProperty;



        static FontColorPicker()
        {
            TheFontSizeProperty = DependencyProperty.Register("TheFontSize",typeof(double),typeof(FontColorPicker),new FrameworkPropertyMetadata((double)12,new PropertyChangedCallback(TheFontSizeChangedCallback)),new ValidateValueCallback(TheFontSizeValidateCallback));
            TheFontSizeChangedEvent = EventManager.RegisterRoutedEvent("TheFontSizeChanged", RoutingStrategy.Bubble, typeof(RoutedPropertyChangedEventHandler<double>), typeof(FontColorPicker));
            TheFontFamilyProperty = DependencyProperty.Register("TheFontFamily", typeof(FontFamily), typeof(FontColorPicker), new FrameworkPropertyMetadata((FontFamily)new FontFamily("Arial"), new PropertyChangedCallback(TheFontFamilyChangedCallback)), new ValidateValueCallback(TheFontFamilyValidateCallback));
            TheFontFamilyChangedEvent = EventManager.RegisterRoutedEvent("TheFontFamilyChanged", RoutingStrategy.Bubble, typeof(RoutedPropertyChangedEventHandler<FontFamily>), typeof(FontColorPicker));
            TheFontStretchProperty = DependencyProperty.Register("TheFontStretch", typeof(FontStretch), typeof(FontColorPicker), new FrameworkPropertyMetadata((FontStretch)FontStretches.Normal, new PropertyChangedCallback(TheFontStretchChangedCallback)));
            TheFontStretchChangedEvent = EventManager.RegisterRoutedEvent("TheFontStretchChanged", RoutingStrategy.Bubble, typeof(RoutedPropertyChangedEventHandler<FontStretch>), typeof(FontColorPicker));
            TheFontStyleProperty = DependencyProperty.Register("TheFontStyle", typeof(FontStyle), typeof(FontColorPicker), new FrameworkPropertyMetadata((FontStyle)FontStyles.Normal, new PropertyChangedCallback(TheFontStyleChangedCallback)));
            TheFontStyleChangedEvent = EventManager.RegisterRoutedEvent("TheFontStyleChanged", RoutingStrategy.Bubble, typeof(RoutedPropertyChangedEventHandler<FontStyle>), typeof(FontColorPicker));
            TheFontWeightProperty = DependencyProperty.Register("TheFontWeight", typeof(FontWeight), typeof(FontColorPicker), new FrameworkPropertyMetadata((FontWeight)FontWeights.Normal, new PropertyChangedCallback(TheFontWeightChangedCallback)));
            TheFontWeightChangedEvent = EventManager.RegisterRoutedEvent("TheFontWeightChanged", RoutingStrategy.Bubble, typeof(RoutedPropertyChangedEventHandler<FontWeight>), typeof(FontColorPicker));
            ColorProperty = DependencyProperty.Register("Color", typeof(Color), typeof(FontColorPicker), new FrameworkPropertyMetadata((Color)Colors.Black, new PropertyChangedCallback(ColorChangedCallback)));
            ColorChangedEvent = EventManager.RegisterRoutedEvent("ColorChanged", RoutingStrategy.Bubble, typeof(RoutedPropertyChangedEventHandler<Color>), typeof(FontColorPicker));
            RedProperty = DependencyProperty.Register("Red", typeof(byte), typeof(FontColorPicker), new FrameworkPropertyMetadata((byte)0, new PropertyChangedCallback(RGBChangedCallback)));
            GreenProperty = DependencyProperty.Register("Green", typeof(byte), typeof(FontColorPicker), new FrameworkPropertyMetadata((byte)0, new PropertyChangedCallback(RGBChangedCallback)));
            BlueProperty = DependencyProperty.Register("Blue", typeof(byte), typeof(FontColorPicker), new FrameworkPropertyMetadata((byte)0, new PropertyChangedCallback(RGBChangedCallback)));
        }


        private byte Red
        {
            get { return (byte)this.GetValue(RedProperty); }
            set { SetValue(RedProperty, value); }
        }
       
        

        private byte Green
        {
            get { return (byte)this.GetValue(GreenProperty); }
            set { SetValue(GreenProperty, value); }
        }
        

        private byte Blue
        {
            get { return (byte)this.GetValue(BlueProperty); }
            set { SetValue(BlueProperty, value); }
        }
        
        private static void RGBChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if(d is FontColorPicker fontColor)
            {
                if(e.Property == FontColorPicker.RedProperty)
                {
                    fontColor.Color= Color.FromRgb((byte)e.NewValue,fontColor.Green,fontColor.Blue);
                }
                else if (e.Property == FontColorPicker.GreenProperty)
                {
                    fontColor.Color = Color.FromRgb(fontColor.Red, (byte)e.NewValue, fontColor.Blue);
                }
                else if (e.Property == FontColorPicker.BlueProperty)
                {
                    fontColor.Color = Color.FromRgb(fontColor.Red,fontColor.Green , (byte)e.NewValue);
                }
            }
      //      throw new NotImplementedException();
        }





        //TheFontSizeProperty
        public double TheFontSize
        {
            get { return (double)this.GetValue(TheFontSizeProperty); }
            set { SetValue(TheFontSizeProperty, value); }
        }

        public event RoutedPropertyChangedEventHandler<double> TheFontSizeChanged
        {
            add { this.AddHandler(TheFontSizeChangedEvent, value); }
            remove { this.RemoveHandler(TheFontSizeChangedEvent, value); }
        }

        static void TheFontSizeChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if(d is FontColorPicker fontColor)
            {
                RoutedPropertyChangedEventArgs<double> args = new RoutedPropertyChangedEventArgs<double>((double)e.OldValue, (double)e.NewValue, FontColorPicker.TheFontSizeChangedEvent);
                fontColor.RaiseEvent(args);
            }
        }
        
        private static bool TheFontSizeValidateCallback(object value)
        {
            if (value is double d)
            {
                if (d < 0)
                    return false;
                return true;
            }
            return false;   
        }


        //TheFontFamilyProperty

        public FontFamily TheFontFamily
        {
            get { return (FontFamily)this.GetValue(TheFontFamilyProperty); }
            set { SetValue(TheFontFamilyProperty, value); }
        }

        public event RoutedPropertyChangedEventHandler<FontFamily> TheFontFamilyChanged
        {
            add { this.AddHandler(TheFontFamilyChangedEvent, value); }
            remove { this.RemoveHandler(TheFontFamilyChangedEvent, value); }
        }

        private static void TheFontFamilyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is FontColorPicker fontColor)
            {
                RoutedPropertyChangedEventArgs<FontFamily> args = new RoutedPropertyChangedEventArgs<FontFamily>((FontFamily)e.OldValue, (FontFamily)e.NewValue, FontColorPicker.TheFontFamilyChangedEvent);
                fontColor.RaiseEvent(args);
            }
            //  throw new NotImplementedException();
        }

         private static bool TheFontFamilyValidateCallback(object value)
        {
            if(value is FontFamily family)
                {
                if (Fonts.SystemFontFamilies.Contains(family))
                    return true;
                else
                    return false;
                }
            return false;
        }


        //TheFontStretch

        public FontStretch TheFontStretch
        {
            get { return (FontStretch)this.GetValue(TheFontStretchProperty); }
         //   set { SetValue(TheFontStretchProperty, value); }
        }

        public event RoutedPropertyChangedEventHandler<FontStretch> TheFontStretchChanged
        {
            add { this.AddHandler(TheFontStretchChangedEvent, value); }
            remove { this.RemoveHandler(TheFontStretchChangedEvent, value); }
        }

        private static void TheFontStretchChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is FontColorPicker fontColor)
            {
                RoutedPropertyChangedEventArgs<FontStretch> args = new RoutedPropertyChangedEventArgs<FontStretch>((FontStretch)e.OldValue, (FontStretch)e.NewValue, FontColorPicker.TheFontStretchChangedEvent);
                fontColor.RaiseEvent(args);
            }
            //throw new NotImplementedException();
        }

        

        //TheFontStyle

        public FontStyle TheFontStyle
        {
            get { return (FontStyle)this.GetValue(TheFontStyleProperty); }
            //   set { SetValue(TheFontStretchProperty, value); }
        }

        public event RoutedPropertyChangedEventHandler<FontStyle> TheFontStyleChanged
        {
            add { this.AddHandler(TheFontStyleChangedEvent, value); }
            remove { this.RemoveHandler(TheFontStyleChangedEvent, value); }
        }
        private static void TheFontStyleChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is FontColorPicker fontColor)
            {
                RoutedPropertyChangedEventArgs<FontStyle> args = new RoutedPropertyChangedEventArgs<FontStyle>((FontStyle)e.OldValue, (FontStyle)e.NewValue, FontColorPicker.TheFontStyleChangedEvent);
                fontColor.RaiseEvent(args);
            }
            //  throw new NotImplementedException();
        }

        //TheFontWeight
        public FontWeight TheFontWeight
        {
            get { return (FontWeight)this.GetValue(TheFontWeightProperty); }
            //   set { SetValue(TheFontStretchProperty, value); }
        }

        public event RoutedPropertyChangedEventHandler<FontWeight> TheFontWeightChanged
        {
            add { this.AddHandler(TheFontWeightChangedEvent, value); }
            remove { this.RemoveHandler(TheFontWeightChangedEvent, value); }
        }

        private static void TheFontWeightChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is FontColorPicker fontColor)
            {
                RoutedPropertyChangedEventArgs<FontWeight> args = new RoutedPropertyChangedEventArgs<FontWeight>((FontWeight)e.OldValue, (FontWeight)e.NewValue, FontColorPicker.TheFontWeightChangedEvent);
                fontColor.RaiseEvent(args);
            }
            // throw new NotImplementedException();
        }

        //Color
        public Color Color
        {
            get { return (Color)this.GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }

        public event RoutedPropertyChangedEventHandler<Color> ColorChanged
        {
            add { this.AddHandler(ColorChangedEvent, value); }
            remove { this.RemoveHandler(ColorChangedEvent, value); }
        }

        private static void ColorChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is FontColorPicker fontColor)
            {
                fontColor.Red = ((Color)e.NewValue).R;
                fontColor.Green = ((Color)e.NewValue).G;
                fontColor.Blue = ((Color)e.NewValue).B;
                RoutedPropertyChangedEventArgs<Color> args = new RoutedPropertyChangedEventArgs<Color>((Color)e.OldValue, (Color)e.NewValue, FontColorPicker.ColorChangedEvent);
                fontColor.RaiseEvent(args);
            }
        }



        private void typefaceslistbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems[0] is FamilyTypeface t)
            {
                this.SetValue(TheFontStretchProperty, t.Stretch);
                this.SetValue(TheFontStyleProperty, t.Style);
                this.SetValue(TheFontWeightProperty, t.Weight);
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.Fontsizecombobox.ItemsSource = Enumerable.Range(1, 36).Select(i=> { return (double)i; });
           // this.TheFontSize = 12;
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            Binding binding = new Binding("Red");
            binding.RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(UserControl), 1);
            this.redslider.SetBinding(Slider.ValueProperty, binding);
            binding = new Binding("Green");
            binding.RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(UserControl), 1);
            this.greenslider.SetBinding(Slider.ValueProperty, binding);
            binding = new Binding("Blue");
            binding.RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(UserControl), 1);
            this.blueslider.SetBinding(Slider.ValueProperty, binding);
        }
    }
}
