using System.Collections.Specialized;
using System.Windows.Input;
using Android.Views;
using Android.Widget;

namespace RecipePal.Droid
{
    public class LinkerPleaseInclude
    {
        public void Include(Button button)
        {
            button.Click += (s, e) => button.Text = button.Text + string.Empty;
        }

        public void Include(CheckBox checkBox)
        {
            checkBox.CheckedChange += (sender, args) => checkBox.Checked = !checkBox.Checked;
        }

        public void Include(View view)
        {
            view.Click += (s, e) => view.ContentDescription = view.ContentDescription + string.Empty;
        }

        /// <summary>
        /// Includes the specified textView.
        /// </summary>
        /// <param name="textView">The textView.</param>
        public void Include(TextView textView)
        {
            textView.TextChanged += (sender, args) => textView.Text = string.Empty + textView.Text;
            textView.Hint = string.Empty + textView.Hint;
        }

        public void Include(CompoundButton compoundButton)
        {
            compoundButton.CheckedChange += (sender, args) => compoundButton.Checked = !compoundButton.Checked;
        }

        public void Include(SeekBar seekBar)
        {
            seekBar.ProgressChanged += (sender, args) => seekBar.Progress = seekBar.Progress + 1;
        }

        public void Include(INotifyCollectionChanged changed)
        {
            changed.CollectionChanged += (s, e) =>
            {
                string test = string.Format("{0}{1}{2}{3}{4}", e.Action, e.NewItems, e.NewStartingIndex, e.OldItems,
                    e.OldStartingIndex);
            };
        }

        public void Include(ICommand command)
        {
            command.CanExecuteChanged += (s, e) =>
            {
                if (command.CanExecute(null))
                {
                    command.Execute(null);
                }
            };
        }
    }
}