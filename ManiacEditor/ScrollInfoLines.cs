namespace ManiacEditor
{
    /// <summary>
    /// Defines the lines to which a ScrollInfo set of horizontal scrolling rules, applies.
    /// </summary>
    public class ScrollInfoLines
    {
        private int _startIndex;
        private int _lineCount;

        /// <summary>
        /// Creates a new mapping with the given values.
        /// </summary>
        /// <param name="startIndex">The line at which any rules start to apply.</param>
        /// <param name="lineCount">The number of lines to which this applies.</param>
        public ScrollInfoLines(int startIndex, int lineCount)
        {
            _startIndex = startIndex;
            _lineCount = lineCount;
        }
        
        /// <summary>
        /// The line at which these rules begin to apply
        /// </summary>
        public int StartIndex
        {
            get => _startIndex;
            set => _startIndex = value;
        }

        /// <summary>
        /// The number of lines to which this set of rules applies.
        /// </summary>
        public int LineCount
        {
            get => _lineCount;
            set => _lineCount = value;
        }

        public override string ToString()
        {
            return $"Start: {_startIndex}, for {_lineCount} lines";
        }
    }
}
