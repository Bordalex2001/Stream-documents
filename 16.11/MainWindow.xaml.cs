using _16._11;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace TextFormattingApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            List<ColorItem> colorItems = new List<ColorItem> 
            {
                new ColorItem("Black", Colors.Black),
                new ColorItem("Blue", Colors.Blue),
                new ColorItem("Green", Colors.Green),
                new ColorItem("Orange", Colors.Orange),
                new ColorItem("Purple", Colors.Purple),
                new ColorItem("Red", Colors.Red),
                new ColorItem("Yellow", Colors.Yellow)
            };
            
            colorComboBox.ItemsSource = colorItems;
        }

        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            ApplyFormatting();
        }

        private void BoldButton_Click(object sender, RoutedEventArgs e)
        {
            ApplyFormatting(fontWeight: FontWeights.Bold);
        }

        private void ItalicButton_Click(object sender, RoutedEventArgs e)
        {
            ApplyFormatting(fontStyle: FontStyles.Italic);
        }

        private void UnderlineButton_Click(object sender, RoutedEventArgs e)
        {
            ApplyFormatting(textDecoration: TextDecorations.Underline);
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            ApplyFormatting(textColor: Brushes.Black);
        }

        private void colorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (colorComboBox.SelectedItem is ColorItem colorItem)
            {
                ApplyFormatting(textColor: colorItem.ColorBrush);
            }
        }

        private void fontSizeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (fontSizeComboBox.SelectedItem is FontSizeConverter fontSize)
            {
                ApplyFormatting(fontSize: fontSize);
            }
        }

        private void ApplyFormatting(FontWeight? fontWeight = null, FontStyle? fontStyle = null, TextDecorationCollection textDecoration = null, Brush textColor = null, FontSizeConverter fontSize = null)
        {
            int startIndex = int.Parse(startIndexTextBox.Text);
            int endIndex = int.Parse(endIndexTextBox.Text);
            TextRange range = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);
            TextPointer start = range.Start.GetPositionAtOffset(startIndex);
            TextPointer end = range.Start.GetPositionAtOffset(endIndex);
     
            if (start != null && end != null)
            {
                TextRange selectedRange = new TextRange(start, end);
                if (fontWeight != null)
                    selectedRange.ApplyPropertyValue(TextElement.FontWeightProperty, fontWeight);
                if (fontStyle != null)
                    selectedRange.ApplyPropertyValue(TextElement.FontStyleProperty, fontStyle);
                if (textDecoration != null)
                    selectedRange.ApplyPropertyValue(Inline.TextDecorationsProperty, textDecoration);
                if (textColor != null)
                    selectedRange.ApplyPropertyValue(TextElement.ForegroundProperty, textColor);
                if (fontSize != null)
                    selectedRange.ApplyPropertyValue(TextElement.FontSizeProperty, fontSize);
            }
        }
    }
}