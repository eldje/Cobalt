using System.Windows.Input;
using Prism.Commands;

namespace Cobalt.Modules.ToolBars.ViewModels
{
    public class MenuToolBarViewModel
    {
        public MenuToolBarViewModel()
        {
            UndoCommand = new DelegateCommand(delegate { ApplicationCommands.Undo.Execute(null, null); });
            RedoCommand = new DelegateCommand(delegate { ApplicationCommands.Redo.Execute(null, null); });
            PasteCommand = new DelegateCommand(delegate { ApplicationCommands.Paste.Execute(null, null); });
            CutCommand = new DelegateCommand(delegate { ApplicationCommands.Cut.Execute(null, null); });
            CopyCommand = new DelegateCommand(delegate { ApplicationCommands.Copy.Execute(null, null); });
        }

        public DelegateCommand UndoCommand { get; set; }
        public DelegateCommand RedoCommand { get; set; }
        public DelegateCommand PasteCommand { get; set; }
        public DelegateCommand CutCommand { get; set; }
        public DelegateCommand CopyCommand { get; set; }
    }
}