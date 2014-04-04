namespace NAntGui.Gui
{
    /// <summary>
    /// Summary description for IEditCommands.
    /// </summary>
    internal interface IEditCommands
    {
        void Cut();
        void Copy();
        void Paste();
        void SelectAll();
//		void WordWrap();
//		bool WordWrapped { get; }
        void Delete();
    }
}